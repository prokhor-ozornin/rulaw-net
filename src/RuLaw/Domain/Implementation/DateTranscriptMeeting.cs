namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Transcript of Duma's meeting.</para>
  /// </summary>
  [XmlType("meeting")]
  public sealed class DateTranscriptMeeting : IComparable<IDateTranscriptMeeting>, IEquatable<IDateTranscriptMeeting>, IDateTranscriptMeeting
  {
    /// <summary>
    ///   <para>Date of meeting.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of meeting.</para>
    /// </summary>
    [JsonProperty("date")]
    [XmlElement("date")]
    public string DateOriginal
    {
      get => Date.ISO8601();
      set => Date = DateTime.Parse(value);
    }

    /// <summary>
    ///   <para>Transcript's text lines.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<string> Lines => LinesOriginal;

    /// <summary>
    ///   <para>Transcript's text lines.</para>
    /// </summary>
    [JsonProperty("lines")]
    [XmlElement("line")]
    public List<string> LinesOriginal { get; set; }

    /// <summary>
    ///   <para>Number of meeting.</para>
    /// </summary>
    [JsonProperty("number")]
    [XmlElement("number")]
    public int Number { get; set; }

    /// <summary>
    ///   <para>Meeting's votes.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<ITranscriptVote> Votes => VotesOriginal;

    /// <summary>
    ///   <para>Meeting's votes.</para>
    /// </summary>
    [JsonProperty("votes")]
    [XmlElement("vote")]
    public List<TranscriptVote> VotesOriginal { get; set; }

    /// <summary>
    ///   <para>Creates new transcript of Duma's meeting.</para>
    /// </summary>
    public DateTranscriptMeeting()
    {
      LinesOriginal = new List<string>();
      VotesOriginal = new List<TranscriptVote>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="IDateTranscriptMeeting"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IDateTranscriptMeeting"/> to compare with this instance.</param>
    public int CompareTo(IDateTranscriptMeeting other)
    {
      return Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="IDateTranscriptMeeting"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(IDateTranscriptMeeting other)
    {
      return this.Equality(other, meeting => meeting.Date);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return Equals(other as IDateTranscriptMeeting);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(meeting => meeting.Date);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DateTranscriptMeeting"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="DateTranscriptMeeting"/>.</returns>
    public override string ToString()
    {
      return this.Text();
    }
  }
}