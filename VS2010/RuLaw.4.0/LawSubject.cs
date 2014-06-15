using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Subject of law.</para>
  /// </summary>
  [XmlType("subject")]
  public class LawSubject
  {
    /// <summary>
    ///   <para>Departments that are subjects of law.</para>
    /// </summary>
    [JsonProperty("departments")]
    [XmlElement("department")]
    public virtual List<Authority> Departments { get; set; }

    /// <summary>
    ///   <para>Deputies that are subjects of law.</para>
    /// </summary>
    [JsonProperty("deputies")]
    [XmlElement("deputy")]
    public virtual List<Deputy> Deputies { get; set; }

    /// <summary>
    ///   <para>Creates new subject of law.</para>
    /// </summary>
    public LawSubject()
    {
      this.Departments = new List<Authority>();
      this.Deputies = new List<Deputy>();
    }
  }
}