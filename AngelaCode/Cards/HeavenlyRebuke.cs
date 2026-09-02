using Angela.AngelaCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.MonsterMoves.Intents;
using MegaCrit.Sts2.Core.ValueProps;

namespace Angela.AngelaCode.Cards;

public class HeavenlyRebuke() : AngelaCard(1,
    CardType.Attack, CardRarity.Basic,
    TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new DamageVar(7M, ValueProp.Move)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        ArgumentNullException.ThrowIfNull(play.Target);
        try
        {
            decimal _dmg = DynamicVars.Damage.BaseValue;
            if (play.Target?.Monster?.NextMove?.Intents?.Any(i => i is AttackIntent) == true)
            {
                _dmg += 5M
            }
            await DamageCmd.Attack(_dmg).FromCard(this).Targeting(play.Target)
                .WithHitFx("vfx/vfx_attack_slash", null, "blunt_attack.mp3")
                .Execute(choiceContext);
        }
        catch (Exception e)
        {
            Godot.GD.PrintErr($"[HeavenlyRebuke] Error in OnPlay: {e}");
        }
    }

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}