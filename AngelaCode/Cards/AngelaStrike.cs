using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace Angela.AngelaCode.Cards;

public class AngelaStrike() : AngelaCard(1,
    CardType.Attack, CardRarity.Basic,
    TargetType.AnyEnemy)
{
    protected override HashSet<CardTag> CanonicalTags => [CardTag.Strike];
    
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new DamageVar(3M, ValueProp.Move),
        new PowerVar<WeakPower>(1M),
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        ArgumentNullException.ThrowIfNull(play.Target, "play.Target");

        try
        {
            await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
                .FromCard(this).Targeting(play.Target)
                .WithHitFx("vfx/vfx_bloody_impact", null, "blunt_attack.mp3")
                .Execute(choiceContext);

            await PowerCmd.Apply<WeakPower>(choiceContext, play.Target,
                base.DynamicVars["WeakPower"].BaseValue,
                base.Owner.Creature, this);
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[AngelaStrike] Error in OnPlay: {ex}");
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(3m);
        base.DynamicVars["WeakPower"].UpgradeValueBy(2m);
    }
}