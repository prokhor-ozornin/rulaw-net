namespace RuLaw
{
  using System;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Laws voting.</para>
  /// </summary>
  [XmlType("vote")]
  public sealed class Vote : IComparable<IVote>, IEquatable<IVote>, IVote
  {
    /// <summary>
    ///   <para>Identifier of vote.</para>
    /// </summary>
    [JsonProperty("id")]
    [XmlElement("id")]
    public long Id { get; set; }

    /// <summary>
    ///   <para>Count of absent (non-voted) deputies in a faction.</para>
    /// </summary>
    [JsonProperty("absentCount")]
    [XmlElement("absentCount")]
    public int? AbsentVotesCount { get; set; }

    /// <summary>
    ///   <para>Count of abstained deputies in a faction.</para>
    /// </summary>
    [JsonProperty("abstainCount")]
    [XmlElement("abstainCount")]
    public int? AbstainVotesCount { get; set; }

    /// <summary>
    ///   <para>Count of deputies in a faction who have voted against.</para>
    /// </summary>
    [JsonProperty("againstCount")]
    [XmlElement("againstCount")]
    public int? AgainstVotesCount { get; set; }

    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [JsonProperty("voteDate")]
    [XmlElement("voteDate")]
    public string DateOriginal
    {
      get { return Date.ISO8601(); }
      set { Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Count of deputies in a faction who have voted for.</para>
    /// </summary>
    [JsonProperty("forCount")]
    [XmlElement("forCount")]
    public int? ForVotesCount { get; set; }

    /// <summary>
    ///   <para>Result of deputy voting.</para>
    /// </summary>
    [JsonProperty("personResult")]
    [XmlElement("personResult")]
    public string PersonResult { get; set; }

    /// <summary>
    ///   <para>Type of voting result.</para>
    /// </summary>
    [JsonProperty("resultType")]
    [XmlElement("resultType")]
    public string ResultType { get; set; }

    /// <summary>
    ///   <para>Subject of convocation.</para>
    /// </summary>
    [JsonProperty("subject")]
    [XmlElement("subject")]
    public string Subject { get; set; }

    /// <summary>
    ///   <para>Whether the law passed (true) or not (false) according to voting.</para>
    /// </summary>
    [JsonProperty("result")]
    [XmlElement("result")]
    public bool Successful { get; set; }

    /// <summary>
    ///   <para>Number of voted deputies in faction.</para>
    /// </summary>
    [JsonProperty("voteCount")]
    [XmlElement("voteCount")]
    public int? TotalVotesCount { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="IVote"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IVote"/> to compare with this instance.</param>
    public int CompareTo(IVote other)
    {
      return Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="IVote"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(IVote other)
    {
      return this.Equality(other, vote => vote.Id);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return Equals(other as IVote);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(vote => vote.Id);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Vote"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Vote"/>.</returns>
    public override string ToString()
    {
      return Subject;
    }
  }
}