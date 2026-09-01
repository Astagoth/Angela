using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using Angela.AngelaCode.Character;
using Angela.AngelaCode.Extensions;

namespace Angela.AngelaCode.Potions;

[Pool(typeof(AngelaPotionPool))]
public abstract class AngelaPotion : CustomPotionModel
{
    public override string? CustomPackedImagePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PotionImagePath();

    public override string? CustomPackedOutlinePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PotionOutlineImagePath();
}