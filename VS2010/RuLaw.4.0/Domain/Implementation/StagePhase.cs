using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Phase of law's workflow stage.</para>
  /// </summary>
  [XmlType("phase")]
  public sealed class StagePhase : NameableEntity<StagePhase>, IStagePhase
  {
    /// <summary>
    ///  <para>Law workflow instance.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IInstance Instance
    {
      get { return this.InstanceOriginal; }
    }

    /// <summary>
    ///  <para>Law workflow instance.</para>
    /// </summary>
    [JsonProperty("instance")]
    [XmlElement("instance")]
    public Instance InstanceOriginal { get; set; }
  }
}