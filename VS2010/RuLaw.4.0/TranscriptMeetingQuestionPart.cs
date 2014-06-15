using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Part of meeting question's transcript.</para>
  /// </summary>
  [XmlType("part")]
  public class TranscriptMeetingQuestionPart : IComparable<TranscriptMeetingQuestionPart>, IEquatable<TranscriptMeetingQuestionPart>
  {
    /// <summary>
    ///   <para>End line of transcript's text fragment.</para>
    /// </summary>
    [JsonProperty("endLine")]
    [XmlElement("endLine")]
    public virtual int EndLine { get; set; }

    /// <summary>
    ///   <para>Lines of transcript's fragment.</para>
    /// </summary>
    [JsonProperty("lines")]
    [XmlElement("line")]
    public virtual List<string> Lines { get; set; }

    /// <summary>
    ///   <para>Start line of transcript's text fragment.</para>
    /// </summary>
    [JsonProperty("startLine")]
    [XmlElement("startLine")]
    public virtual int StartLine { get; set; }

    /// <summary>
    ///   <para>Full text of transcript.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual string Text
    {
      get { return this.Lines.Join(Environment.NewLine); }
    }

    /// <summary>
    ///   <para>List of question' votes.</para>
    /// </summary>
    [JsonProperty("votes")]
    [XmlElement("vote")]
    public virtual List<TranscriptVote> Votes { get; set; }

    /// <summary>
    ///   <para>Creates new question's part.</para>
    /// </summary>
    public TranscriptMeetingQuestionPart()
    {
      this.Lines = new List<string>();
      this.Votes = new List<TranscriptVote>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="TranscriptMeetingQuestionPart"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="TranscriptMeetingQuestionPart"/> to compare with this instance.</param>
    public virtual int CompareTo(TranscriptMeetingQuestionPart other)
    {
      return this.StartLine.CompareTo(other.StartLine);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="TranscriptMeetingQuestionPart"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(TranscriptMeetingQuestionPart other)
    {
      return this.Equality(other, part => part.StartLine, part => part.EndLine);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as TranscriptMeetingQuestionPart);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(part => part.StartLine, part => part.EndLine);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="TranscriptMeetingQuestionPart"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="TranscriptMeetingQuestionPart"/>.</returns>
    public override string ToString()
    {
      return this.Text;
    }
  }
}