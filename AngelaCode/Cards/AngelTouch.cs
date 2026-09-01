using Angela.AngelaCode.Powers;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Commands;

namespace Angela.AngelaCode.Cards;

public class AngelTouch() : AngelaCard(3,
    CardType.Power, CardRarity.Uncommon,
    TargetType.AnyAlly)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new PowerVar<AngelicTouch>(1),
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await PowerCmd.Apply<AngelicTouch>(choiceContext, play.Target,
            base.DynamicVars["AngelicTouch"].BaseValue,
            base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        this.EnergyCost.UpgradeBy(-1);
    }
}