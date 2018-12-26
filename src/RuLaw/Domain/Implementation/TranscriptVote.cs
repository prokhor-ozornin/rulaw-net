namespace RuLaw
{
  using System;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Transcript's vote.</para>
  /// </summary>
  [XmlType("vote")]
  public sealed class TranscriptVote : IComparable<ITranscriptVote>, IEquatable<ITranscriptVote>, ITranscriptVote
  {
    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [JsonProperty("date")]
    [XmlElement("date")]
    public string DateOriginal
    {
      get { return Date.ISO8601(); }
      set { Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Transcript's line number.</para>
    /// </summary>
    [JsonProperty("line")]
    [XmlElement("line")]
    public int Line { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="ITranscriptVote"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="ITranscriptVote"/> to compare with this instance.</param>
    public int CompareTo(ITranscriptVote other)
    {
      return Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="ITranscriptVote"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(ITranscriptVote other)
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
      return Equals(other as ITranscriptVote);
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