namespace RuLaw
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Serialization;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Law workflow stage.</para>
  /// </summary>
  [XmlType("stage")]
  public sealed class PhaseStage : NameableEntity<PhaseStage>, IPhaseStage
  {
    /// <summary>
    ///   <para>Workflow events that are part of the stage.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<IStagePhase> Phases
    {
      get { return PhasesOriginal.Cast<IStagePhase>(); }
    }

    /// <summary>
    ///   <para>Workflow events that are part of the stage.</para>
    /// </summary>
    [JsonProperty("phases")]
    [XmlElement("phase")]
    public List<StagePhase> PhasesOriginal { get; set; }

    /// <summary>
    ///   <para>Creates new law workflow stage.</para>
    /// </summary>
    public PhaseStage()
    {
      PhasesOriginal = new List<StagePhase>();
    }
  }
}