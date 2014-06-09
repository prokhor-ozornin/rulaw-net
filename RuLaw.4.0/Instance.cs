using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Law workflow instance.</para>
  /// </summary>
  [Description("Law workflow instance")]
  [XmlType("instance")]
  public class Instance : NameableEntity<Instance>, IActive
  {
    /// <summary>
    ///   <para>Whether the instance is active at present or not.</para>
    /// </summary>
    [Description("Whether the instance is active at present or not")]
    [JsonProperty("isCurrent")]
    [XmlElement("isCurrent")]
    public virtual bool Active { get; set; }
  }
}