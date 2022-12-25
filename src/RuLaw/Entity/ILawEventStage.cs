namespace RuLaw;

/// <summary>
///   <para>Stage of law's review process.</para>
/// </summary>
public interface ILawEventStage : IEntity, INameable, IComparable<ILawEventStage>, IEquatable<ILawEventStage>
{
}