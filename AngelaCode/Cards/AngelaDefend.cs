using Angela.AngelaCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Entities.Creatures;

namespace Angela.AngelaCode.Cards;

public class AngelaDefend() : AngelaCard(1,
    CardType.Skill, CardRarity.Basic,
    TargetType.AllAllies)
{
    public override bool GainsBlock => true;

    protected override HashSet<CardTag> CanonicalTags => [CardTag.Defend];
    
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new BlockVar(5M, ValueProp.Move),
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        
        foreach (Creature creature in (IEnumerable<Creature>) this.CombatState.PlayerCreatures.Where<Creature>((Func<Creature, bool>) (c => c != null && c.IsAlive)).ToList<Creature>())
        {
            await CreatureCmd.GainBlock(creature, this.DynamicVars.Block, play);
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Block.UpgradeValueBy(2M);
    }
}