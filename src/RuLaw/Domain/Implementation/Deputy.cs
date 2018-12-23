using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Deputy/member of Council of Federation.</para>
  /// </summary>
  [XmlType("deputy")]
  public sealed class Deputy : NameableEntity<Deputy>, IDeputy
  {
    /// <summary>
    ///   <para>Whether the deputy is working at present or not.</para>
    /// </summary>
    [JsonProperty("isCurrent")]
    [XmlElement("isCurrent")]
    public bool Active { get; set; }

    /// <summary>
    ///   <para>Work position of deputy.</para>
    /// </summary>
    [JsonProperty("position")]
    [XmlElement("position")]
    public string Position { get; set; }
  }
}