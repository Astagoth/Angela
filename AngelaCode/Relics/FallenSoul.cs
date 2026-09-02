using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Rooms;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Angela.AngelaCode.Relics;

public class FallenSoul() : AngelaRelic
{
    public override RelicRarity Rarity =>
        RelicRarity.Starter;

    public RelicMultiplayerConstraint MultiplayerConstraint
    {
        get => RelicMultiplayerConstraint.None;
    }
    
    
    public override async Task AfterCombatVictory(CombatRoom room)
    {
        if (base.Owner?.Creature?.CombatState == null) return;
        try
        {
            foreach (var _ally in base.Owner.Creature.CombatState.GetTeammatesOf(base.Owner.Creature).ToList())
            {
                await CreatureCmd.GainMaxHp(_ally, 2M);
            }
            
        }
        catch (Exception e)
        {
            Godot.GD.PrintErr($"[FallenSoul] Error in combatEnd: {e}");
        }
        
    }
}