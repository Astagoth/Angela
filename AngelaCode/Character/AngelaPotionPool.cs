using BaseLib.Abstracts;
using Angela.AngelaCode.Extensions;
using Godot;

namespace Angela.AngelaCode.Character;

public class AngelaPotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => Angela.Color;


    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}