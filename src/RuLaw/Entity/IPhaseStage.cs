namespace RuLaw;

/// <summary>
///   <para>Law workflow stage.</para>
/// </summary>
public interface IPhaseStage : IEntity, INameable, IComparable<IPhaseStage>, IEquatable<IPhaseStage>
{
  /// <summary>
  ///   <para>Workflow events that are part of the stage.</para>
  /// </summary>
  IEnumerable<IStagePhase> Phases { get; }
}