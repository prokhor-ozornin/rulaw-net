using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Duma's convocation.</para>
  /// </summary>
  [XmlType("period")]
  public sealed class Convocation : NameableEntity<Convocation>, IConvocation
  {
    /// <summary>
    ///   <para>Date when convocation was started.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime FromDate { get; set; }

    /// <summary>
    ///   <para>Date when convocation was started.</para>
    /// </summary>
    [JsonProperty("startDate")]
    [XmlElement("startDate")]
    public string FromDateOriginal
    {
      get { return this.FromDate.ISO8601(); }
      set { this.FromDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Collection of sessions which are part of the convocation.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<ISession> Sessions
    {
      get { return this.SessionsOriginal.Cast<ISession>(); }
    }

    /// <summary>
    ///   <para>Collection of sessions which are part of the convocation.</para>
    /// </summary>
    [JsonProperty("sessions")]
    [XmlElement("session")]
    public List<Session> SessionsOriginal { get; set; }

    /// <summary>
    ///   <para>Date when convocation was ended.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime? ToDate { get; set; }

    /// <summary>
    ///   <para>Date when convocation was ended.</para>
    /// </summary>
    [JsonProperty("endDate")]
    [XmlElement("endDate")]
    public string ToDateOriginal
    {
      get { return this.ToDate != null ? this.ToDate.Value.ISO8601() : null; }
      set { this.ToDate = value.IsEmpty() ? (DateTime?) null : DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Creates new convocation.</para>
    /// </summary>
    public Convocation()
    {
      this.SessionsOriginal = new List<Session>();
    }
  }
}