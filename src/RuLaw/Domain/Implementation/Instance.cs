using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Law workflow instance.</para>
  /// </summary>
  [XmlType("instance")]
  public sealed class Instance : NameableEntity<Instance>, IInstance
  {
    /// <summary>
    ///   <para>Whether the instance is active at present or not.</para>
    /// </summary>
    [JsonProperty("isCurrent")]
    [XmlElement("isCurrent")]
    public bool Active { get; set; }
  }
}