using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript's vote.</para>
  /// </summary>
  [XmlType("vote")]
  public class TranscriptVote : IComparable<TranscriptVote>, IEquatable<TranscriptVote>, IDateable
  {
    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of voting.</para>
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
    ///   <para>Transcript's line number.</para>
    /// </summary>
    [JsonProperty("line")]
    [XmlElement("line")]
    public virtual int Line { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="TranscriptVote"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="TranscriptVote"/> to compare with this instance.</param>
    public virtual int CompareTo(TranscriptVote other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="TranscriptVote"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(TranscriptVote other)
    {
      return this.Equality(other, vote => vote.Date, vote => vote.Line);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as TranscriptVote);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(vote => vote.Date, vote => vote.Line);
    }
  }
}