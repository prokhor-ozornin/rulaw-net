namespace RuLaw;

/// <summary>
///   <para>Phase of law's workflow stage.</para>
/// </summary>
public interface IStagePhase : IEntity, INameable, IComparable<IStagePhase>, IEquatable<IStagePhase>
{
  /// <summary>
  ///  <para>Law workflow instance.</para>
  /// </summary>
  IInstance Instance { get; }
}