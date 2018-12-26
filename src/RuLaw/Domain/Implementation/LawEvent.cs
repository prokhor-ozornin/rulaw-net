namespace RuLaw
{
  using System;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Event, associated with a law.</para>
  /// </summary>
  [XmlType("lastEvent")]
  public sealed class LawEvent : IComparable<ILawEvent>, ILawEvent
  {
    /// <summary>
    ///   <para>Date of event occurrence.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of event occurrence.</para>
    /// </summary>
    [JsonProperty("date")]
    [XmlElement("date")]
    public string DateOriginal
    {
      get { return Date.ISO8601(); }
      set { Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Document, associated with a law's event.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public ILawEventDocument Document
    {
      get { return DocumentOriginal; }
    }

    /// <summary>
    ///   <para>Document, associated with a law's event.</para>
    /// </summary>
    [JsonProperty("document")]
    [XmlElement("document")]
    public LawEventDocument DocumentOriginal { get; set; }

    /// <summary>
    ///   <para>Phase of law's review process.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public ILawEventPhase Phase
    {
      get { return PhaseOriginal; }
    }

    /// <summary>
    ///   <para>Phase of law's review process.</para>
    /// </summary>
    [JsonProperty("phase")]
    [XmlElement("phase")]
    public LawEventPhase PhaseOriginal { get; set; }

    /// <summary>
    ///   <para>Accepted decision (formulation).</para>
    /// </summary>
    [JsonProperty("solution")]
    [XmlElement("solution")]
    public string Solution { get; set; }

    /// <summary>
    ///   <para>Stage of law's review process.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public ILawEventStage Stage
    {
      get { return StageOriginal; }
    }

    /// <summary>
    ///   <para>Stage of law's review process.</para>
    /// </summary>
    [JsonProperty("stage")]
    [XmlElement("stage")]
    public LawEventStage StageOriginal { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="ILawEvent"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="ILawEvent"/> to compare with this instance.</param>
    public int CompareTo(ILawEvent other)
    {
      return Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="LawEvent"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="LawEvent"/>.</returns>
    public override string ToString()
    {
      return Solution;
    }
  }
}