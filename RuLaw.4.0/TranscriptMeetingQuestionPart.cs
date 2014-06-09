using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Part of meeting question's transcript.</para>
  /// </summary>
  [Description("Part of meeting question's transcript")]
  [XmlType("part")]
  public class TranscriptMeetingQuestionPart : IComparable<TranscriptMeetingQuestionPart>, IEquatable<TranscriptMeetingQuestionPart>
  {
    /// <summary>
    ///   <para>End line of transcript's text fragment.</para>
    /// </summary>
    [Description("End line of transcript's text fragment")]
    [JsonProperty("endLine")]
    [XmlElement("endLine")]
    public virtual int EndLine { get; set; }

    /// <summary>
    ///   <para>Lines of transcript's fragment.</para>
    /// </summary>
    [Description("Lines of transcript's fragment")]
    [JsonProperty("lines")]
    [XmlElement("line")]
    public virtual List<string> Lines { get; set; }

    /// <summary>
    ///   <para>Start line of transcript's text fragment.</para>
    /// </summary>
    [Description("Start line of transcript's text fragment")]
    [JsonProperty("startLine")]
    [XmlElement("startLine")]
    public virtual int StartLine { get; set; }

    /// <summary>
    ///   <para>Full text of transcript.</para>
    /// </summary>
    [Description("Full text of transcript")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual string Text
    {
      get { return this.Lines.Join(Environment.NewLine); }
    }

    /// <summary>
    ///   <para>List of question' votes.</para>
    /// </summary>
    [Description("List of question' votes")]
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
    ///   <para>Compares the current question's part with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="TranscriptMeetingQuestionPart"/> to compare with this instance.</param>
    public virtual int CompareTo(TranscriptMeetingQuestionPart other)
    {
      return this.StartLine.CompareTo(other.StartLine);
    }

    /// <summary>
    ///   <para>Determines whether two question's parts instances are equal.</para>
    /// </summary>
    /// <param name="other">The question's part to compare with the current one.</param>
    /// <returns><c>true</c> if specified question's part is equal to the current, <c>false</c> otherwise.</returns>
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
    ///   <para>Returns a <see cref="string"/> that represents the current question's part.</para>
    /// </summary>
    /// <returns>A string that represents the current question's part.</returns>
    public override string ToString()
    {
      return this.Text;
    }
  }
}