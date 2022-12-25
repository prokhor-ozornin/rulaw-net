namespace RuLaw;

/// <summary>
///   <para>Phase of law's review process.</para>
/// </summary>
public interface ILawEventPhase : IEntity, INameable, IComparable<ILawEventPhase>, IEquatable<ILawEventPhase>
{
}