using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Law authority.</para>
  /// </summary>
  [Description("Law authority")]
  [XmlType("department")]
  public class Authority : NameableEntity<Authority>, IActive, IPeriodable
  {
    /// <summary>
    ///   <para>Whether the authority is active at present or not.</para>
    /// </summary>
    [Description("Whether the authority is active at present or not")]
    [JsonProperty("isCurrent")]
    [XmlElement("isCurrent")]
    public virtual bool Active { get; set; }

    /// <summary>
    ///   <para>Start date of authority functioning.</para>
    /// </summary>
    [Description("Start date of authority functioning")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime FromDate { get; set; }

    /// <summary>
    ///   <para>Start date of authority functioning.</para>
    /// </summary>
    [Description("Start date of authority functioning")]
    [JsonProperty("startDate")]
    [XmlElement("startDate")]
    public virtual string FromDateString
    {
      get { return this.FromDate.ISO8601(); }
      set { this.FromDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>End date of authority functioning.</para>
    /// </summary>
    [Description("End date of authority functioning")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime? ToDate { get; set; }

    /// <summary>
    ///   <para>End date of authority functioning.</para>
    /// </summary>
    [Description("End date of authority functioning")]
    [JsonProperty("stopDate")]
    [XmlElement("stopDate")]
    public virtual string ToDateString
    {
      get { return this.ToDate != null ? this.ToDate.Value.ISO8601() : null; }
      set { this.ToDate = value.IsEmpty() ? (DateTime?)null : DateTime.Parse(value); }
    }
  }
}