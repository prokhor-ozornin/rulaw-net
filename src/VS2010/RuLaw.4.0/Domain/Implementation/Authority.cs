using System;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Law authority.</para>
  /// </summary>
  [XmlType("department")]
  public class Authority : NameableEntity<Authority>, IAuthority
  {
    /// <summary>
    ///   <para>Whether the authority is active at present or not.</para>
    /// </summary>
    [JsonProperty("isCurrent")]
    [XmlElement("isCurrent")]
    public bool Active { get; set; }

    /// <summary>
    ///   <para>Start date of authority functioning.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime FromDate { get; set; }

    /// <summary>
    ///   <para>Start date of authority functioning.</para>
    /// </summary>
    [JsonProperty("startDate")]
    [XmlElement("startDate")]
    public string FromDateOriginal
    {
      get { return this.FromDate.ISO8601(); }
      set { this.FromDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>End date of authority functioning.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime? ToDate { get; set; }

    /// <summary>
    ///   <para>End date of authority functioning.</para>
    /// </summary>
    [JsonProperty("stopDate")]
    [XmlElement("stopDate")]
    public string ToDateOriginal
    {
      get { return this.ToDate != null ? this.ToDate.Value.ISO8601() : null; }
      set { this.ToDate = value.IsEmpty() ? (DateTime?)null : DateTime.Parse(value); }
    }
  }
}