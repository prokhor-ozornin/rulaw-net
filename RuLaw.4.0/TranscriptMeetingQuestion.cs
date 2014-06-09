using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript's question.</para>
  /// </summary>
  [Description("Transcript's question")]
  [XmlType("question")]
  public class TranscriptMeetingQuestion : IComparable<TranscriptMeetingQuestion>, IEquatable<TranscriptMeetingQuestion>, INameable
  {
    /// <summary>
    ///   <para>Title of question.</para>
    /// </summary>
    [Description("Title of question")]
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>List of transcript's fragments.</para>
    /// </summary>
    [Description("List of transcript's fragments")]
    [JsonProperty("parts")]
    [XmlElement("part")]
    public virtual List<TranscriptMeetingQuestionPart> Parts { get; set; }

    /// <summary>
    ///   <para>Question's review stage.</para>
    /// </summary>
    [Description("Question's review stage")]
    [JsonProperty("stage")]
    [XmlElement("stage")]
    public virtual string Stage { get; set; }

    /// <summary>
    ///   <para>Creates new transcript's question.</para>
    /// </summary>
    public TranscriptMeetingQuestion()
    {
      this.Parts = new List<TranscriptMeetingQuestionPart>();
    }

    /// <summary>
    ///   <para>Compares the current question with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="TranscriptMeetingQuestion"/> to compare with this instance.</param>
    public virtual int CompareTo(TranscriptMeetingQuestion other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two questions instances are equal.</para>
    /// </summary>
    /// <param name="other">The question to compare with the current one.</param>
    /// <returns><c>true</c> if specified question is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(TranscriptMeetingQuestion other)
    {
      return this.Equality(other, question => question.Name, question => question.Stage);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as TranscriptMeetingQuestion);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(question => question.Name, question => question.Stage);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current question.</para>
    /// </summary>
    /// <returns>A string that represents the current question.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}