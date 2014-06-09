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
  [Description("Event, associated with a law")]
  [XmlType("lastEvent")]
  public class LawEvent : IComparable<LawEvent>, IDateable
  {
    /// <summary>
    ///   <para>Date of event occurrence.</para>
    /// </summary>
    [Description("Date of event occurrence")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of event occurrence.</para>
    /// </summary>
    [Description("Date of event occurrence")]
    [JsonProperty("date")]
    [XmlElement("date")]
    public virtual string DateString
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Document, associated with a law's event.</para>
    /// </summary>
    [Description("Document, associated with a law's event")]
    [JsonProperty("document")]
    [XmlElement("document")]
    public virtual LawEventDocument Document { get; set; }

    /// <summary>
    ///   <para>Phase of law's review process.</para>
    /// </summary>
    [Description("Phase of law's review process")]
    [JsonProperty("phase")]
    [XmlElement("phase")]
    public virtual LawEventPhase Phase { get; set; }

    /// <summary>
    ///   <para>Accepted decision (formulation).</para>
    /// </summary>
    [Description("Accepted decision (formulation)")]
    [JsonProperty("solution")]
    [XmlElement("solution")]
    public virtual string Solution { get; set; }

    /// <summary>
    ///   <para>Stage of law's review process.</para>
    /// </summary>
    [Description("Stage of law's review process")]
    [JsonProperty("stage")]
    [XmlElement("stage")]
    public virtual LawEventStage Stage { get; set; }
    
    /// <summary>
    ///   <para>Compares the current event with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="LawEvent"/> to compare with this instance.</param>
    [Description()]
    public virtual int CompareTo(LawEvent other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current event.</para>
    /// </summary>
    /// <returns>A string that represents the current event.</returns>
    public override string ToString()
    {
      return this.Solution;
    }
  }
}