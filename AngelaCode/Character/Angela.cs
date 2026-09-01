using Angela.AngelaCode.Cards;
using BaseLib.Abstracts;
using BaseLib.Utils.NodeFactories;
using Angela.AngelaCode.Extensions;
using Angela.AngelaCode.Relics;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Relics;

namespace Angela.AngelaCode.Character;

public class Angela : PlaceholderCharacterModel
{
    public const string CharacterId = "Angela";

    public static readonly Color Color = new("fffac4");

    public override Color NameColor => Color;
    public override CharacterGender Gender => CharacterGender.Feminine;
    public override int StartingHp => 70;

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<AngelaStrike>(),
        ModelDb.Card<AngelaStrike>(),
        ModelDb.Card<AngelaStrike>(),
        ModelDb.Card<AngelaStrike>(),
        ModelDb.Card<AngelaStrike>(),
        ModelDb.Card<AngelaDefend>(),
        ModelDb.Card<AngelaDefend>(),
        ModelDb.Card<AngelaDefend>(),
        ModelDb.Card<AngelaDefend>(),
        ModelDb.Card<AngelaDefend>()
    ];

    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<FallenSoul>()
    ];

    public override CardPoolModel CardPool => ModelDb.CardPool<AngelaCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<AngelaRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<AngelaPotionPool>();

    /*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
        override all the other methods that define those assets.
        These are just some of the simplest assets, given some placeholders to differentiate your character with.
        You don't have to, but you're suggested to rename these images. */
    public override Control CustomIcon
    {
        get
        {
            var icon = NodeFactory<Control>.CreateFromResource(CustomIconTexturePath);
            icon.SetAnchorsAndOffsetsPreset(Control.LayoutPreset.FullRect);
            return icon;
        }
    }

    public override string CustomIconTexturePath => "character_icon_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectIconPath => "char_select_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectLockedIconPath => "char_select_char_name_locked.png".CharacterUiPath();
    public override string CustomMapMarkerPath => "map_marker_char_name.png".CharacterUiPath();
}