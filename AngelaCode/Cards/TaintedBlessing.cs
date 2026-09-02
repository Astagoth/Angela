using Angela.AngelaCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;

namespace Angela.AngelaCode.Cards;

public class TaintedBlessing() : AngelaCard(2,
    CardType.Skill, CardRarity.Uncommon,
    TargetType.AllAllies)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        try
        {
            foreach (Creature creature in CombatState.GetTeammatesOf(Owner.Creature).ToList())
            {
                foreach (PowerModel debuff in creature.Powers.Where(p => p.TypeForCurrentAmount == PowerType.Debuff).ToList())
                {
                    await PowerCmd.Remove((debuff));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"[TaintedBlessing] Error in OnPlay: {e}");
            throw;
        }
    }

    protected override void OnUpgrade()
    {

    }
}