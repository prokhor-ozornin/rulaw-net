namespace RuLaw
{
  using System;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Committee.</para>
  /// </summary>
  [XmlType("committee")]
  public sealed class Committee : NameableEntity<Committee>, ICommittee
  {
    /// <summary>
    ///   <para>Whether the committee is active at present or not.</para>
    /// </summary>
    [JsonProperty("isCurrent")]
    [XmlElement("isCurrent")]
    public bool Active { get; set; }

    /// <summary>
    ///   <para>Start date of committee functioning.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime FromDate { get; set; }

    /// <summary>
    ///   <para>Start date of committee functioning.</para>
    /// </summary>
    [JsonProperty("startDate")]
    [XmlElement("startDate")]
    public string FromDateOriginal
    {
      get { return FromDate.ISO8601(); }
      set { FromDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>End date of committee functioning.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime? ToDate { get; set; }

    /// <summary>
    ///   <para>End date of committee functioning.</para>
    /// </summary>
    [JsonProperty("stopDate")]
    [XmlElement("stopDate")]
    public string ToDateOriginal
    {
      get { return ToDate != null ? ToDate.Value.ISO8601() : null; }
      set { ToDate = value.IsEmpty() ? (DateTime?)null : DateTime.Parse(value); }
    }
  }
}