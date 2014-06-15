using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Event, associated with a law.</para>
  /// </summary>
  [XmlType("lastEvent")]
  public class LawEvent : IComparable<LawEvent>, IDateable
  {
    /// <summary>
    ///   <para>Date of event occurrence.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of event occurrence.</para>
    /// </summary>
    [JsonProperty("date")]
    [XmlElement("date")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string DateString
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Document, associated with a law's event.</para>
    /// </summary>
    [JsonProperty("document")]
    [XmlElement("document")]
    public virtual LawEventDocument Document { get; set; }

    /// <summary>
    ///   <para>Phase of law's review process.</para>
    /// </summary>
    [JsonProperty("phase")]
    [XmlElement("phase")]
    public virtual LawEventPhase Phase { get; set; }

    /// <summary>
    ///   <para>Accepted decision (formulation).</para>
    /// </summary>
    [JsonProperty("solution")]
    [XmlElement("solution")]
    public virtual string Solution { get; set; }

    /// <summary>
    ///   <para>Stage of law's review process.</para>
    /// </summary>
    [JsonProperty("stage")]
    [XmlElement("stage")]
    public virtual LawEventStage Stage { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="LawEvent"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="LawEvent"/> to compare with this instance.</param>
    public virtual int CompareTo(LawEvent other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="LawEvent"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="LawEvent"/>.</returns>
    public override string ToString()
    {
      return this.Solution;
    }
  }
}