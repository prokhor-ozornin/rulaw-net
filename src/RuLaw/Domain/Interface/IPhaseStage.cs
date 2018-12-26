namespace RuLaw
{
  using System.Collections.Generic;

  /// <summary>
  ///   <para>Law workflow stage.</para>
  /// </summary>
  public interface IPhaseStage : IEntity, INameable
  {
    /// <summary>
    ///   <para>Workflow events that are part of the stage.</para>
    /// </summary>
    IEnumerable<IStagePhase> Phases { get; }
  }
}