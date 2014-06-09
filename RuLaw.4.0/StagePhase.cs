using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Phase of law's workflow stage.</para>
  /// </summary>
  [Description("Phase of law's workflow stage")]
  [XmlType("phase")]
  public class StagePhase : NameableEntity<StagePhase>
  {
    /// <summary>
    ///  <para>Law workflow instance.</para>
    /// </summary>
    [Description("Law workflow instance")]
    [JsonProperty("instance")]
    [XmlElement("instance")]
    public virtual Instance Instance { get; set; }
  }
}