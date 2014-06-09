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
  public class TranscriptMeeting : IComparable<TranscriptMeeting>, IEquatable<TranscriptMeeting>, IDateable
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
    ///   <para>Number of lines in transcript.</para>
    /// </summary>
    [Description("Number of lines in transcript")]
    [JsonProperty("maxNumber")]
    [XmlElement("maxNumber")]
    public virtual int LinesCount { get; set; }
    
    /// <summary>
    ///   <para>Number of meeting.</para>
    /// </summary>
    [Description("Number of meeting")]
    [JsonProperty("number")]
    [XmlElement("number")]
    public virtual int Number { get; set; }

    /// <summary>
    ///   <para>Questions that were discussed during the meeting.</para>
    /// </summary>
    [Description("Questions that were discussed during the meeting")]
    [JsonProperty("questions")]
    [XmlElement("question")]
    public virtual List<TranscriptMeetingQuestion> Questions { get; set; }

    /// <summary>
    ///   <para>Creates new transcript of Duma's meeting.</para>
    /// </summary>
    public TranscriptMeeting()
    {
      this.Questions = new List<TranscriptMeetingQuestion>();
    }

    /// <summary>
    ///   <para>Compares the current meeting with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="TranscriptMeeting"/> to compare with this instance.</param>
    public virtual int CompareTo(TranscriptMeeting other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two meetings instances are equal.</para>
    /// </summary>
    /// <param name="other">The meeting to compare with the current one.</param>
    /// <returns><c>true</c> if specified meeting is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(TranscriptMeeting other)
    {
      return this.Equality(other, meeting => meeting.Date, meeting => meeting.Number);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as TranscriptMeeting);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(meeting => meeting.Date, meeting => meeting.Number);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current transcript.</para>
    /// </summary>
    /// <returns>A string that represents the current transcript.</returns>
    public override string ToString()
    {
      return this.Date.ISO8601();
    }
  }
}