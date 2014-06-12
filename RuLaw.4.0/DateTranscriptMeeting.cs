using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of Duma's meeting.</para>
  /// </summary>
  [Description("Transcript of Duma's meeting")]
  [XmlType("meeting")]
  public class DateTranscriptMeeting : IComparable<DateTranscriptMeeting>, IEquatable<DateTranscriptMeeting>, IDateable
  {
    /// <summary>
    ///   <para>Date of meeting.</para>
    /// </summary>
    [Description("Date of meeting")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of meeting.</para>
    /// </summary>
    [Description("Date of meeting")]
    [JsonProperty("date")]
    [XmlElement("date")]
    public virtual string DateString
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Transcript's text lines.</para>
    /// </summary>
    [Description("Transcript's text lines")]
    [JsonProperty("lines")]
    [XmlElement("line")]
    public virtual List<string> Lines { get; set; }

    /// <summary>
    ///   <para>Number of meeting.</para>
    /// </summary>
    [Description("Number of meeting")]
    [JsonProperty("number")]
    [XmlElement("number")]
    public virtual int Number { get; set; }

    /// <summary>
    ///   <para>Transcript's full text.</para>
    /// </summary>
    [Description("Transcript's full text")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual string Text
    {
      get  { return this.Lines.Join(Environment.NewLine); }
    }

    /// <summary>
    ///   <para>Meeting's votes.</para>
    /// </summary>
    [Description("Meeting's votes")]
    [JsonProperty("votes")]
    [XmlElement("vote")]
    public virtual List<TranscriptVote> Votes { get; set; }

    /// <summary>
    ///   <para>Creates new transcript of Duma's meeting.</para>
    /// </summary>
    public DateTranscriptMeeting()
    {
      this.Lines = new List<string>();
      this.Votes = new List<TranscriptVote>();
    }

    /// <summary>
    ///   <para>Compares the current meeting with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="DateTranscriptMeeting"/> to compare with this instance.</param>
    public virtual int CompareTo(DateTranscriptMeeting other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="DateTranscriptMeeting"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(DateTranscriptMeeting other)
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
      return this.Equals(other as DateTranscriptMeeting);
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
    ///   <para>Returns a <see cref="string"/> that represents the current meeting.</para>
    /// </summary>
    /// <returns>A string that represents the current meeting.</returns>
    public override string ToString()
    {
      return this.Text;
    }
  }
}