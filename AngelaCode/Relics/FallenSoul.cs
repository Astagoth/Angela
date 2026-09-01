using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Rooms;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;

namespace Angela.AngelaCode.Relics;

public class FallenSoul() : AngelaRelic
{
    public override RelicRarity Rarity =>
        RelicRarity.Starter;

    public RelicMultiplayerConstraint MultiplayerConstraint
    {
        get => RelicMultiplayerConstraint.MultiplayerOnly;
    }
    
    public override async Task AfterCombatVictory(CombatRoom room)
    {
        foreach (Creature creature in (IEnumerable<Creature>) Creature.CombatState.PlayerCreatures.Where<Creature>((Func<Creature, bool>) (c => c != null && c.IsAlive)).ToList<Creature>())
        {
            await CreatureCmd.GainMaxHp(creature, 1M);
        }
        
    }
}