using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Angela.AngelaCode.Cards;

public class Judgment() : AngelaCard(3, CardType.Skill,
    CardRarity.Rare, TargetType.AllEnemies)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new PowerVar<MagicBombPower>(7M),
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        ArgumentNullException.ThrowIfNull(play.Target);
        
        try
        {
            await PowerCmd.Apply<MagicBombPower>(choiceContext, play.Target,
                DynamicVars["MagicBombPower"].BaseValue,
                Owner.Creature, this);
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[AngelaStrike] Error in OnPlay: {ex}");
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars["MagicBombPower"].UpgradeValueBy(2M);
        EnergyCost.UpgradeBy(-1);
    }
}