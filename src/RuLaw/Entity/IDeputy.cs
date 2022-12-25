namespace RuLaw;

/// <summary>
///   <para>Deputy/member of Council of Federation.</para>
/// </summary>
public interface IDeputy : IEntity, INameable, IActive, IComparable<IDeputy>, IEquatable<IDeputy>
{
  /// <summary>
  ///   <para>Work position of deputy.</para>
  /// </summary>
  string? Position { get; }
}