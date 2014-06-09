using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Law workflow stage.</para>
  /// </summary>
  [Description("Law workflow stage")]
  [XmlType("stage")]
  public class PhaseStage : NameableEntity<PhaseStage>
  {
    /// <summary>
    ///   <para>Workflow events that are part of the stage.</para>
    /// </summary>
    [Description("Workflow events that are part of the stage")]
    [JsonProperty("phases")]
    [XmlElement("phase")]
    public virtual List<StagePhase> Phases { get; set; }

    /// <summary>
    ///   <para>Creates new law workflow stage.</para>
    /// </summary>
    public PhaseStage()
    {
      this.Phases = new List<StagePhase>();
    }
  }
}