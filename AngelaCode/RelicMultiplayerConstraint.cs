#nullable disable
namespace Angela.AngelaCode;

/// <summary>
/// Manages relic restrictions based on how many players there are in a run.
/// </summary>
public enum RelicMultiplayerConstraint
{
    None,
    MultiplayerOnly,
    SingleplayerOnly,
}