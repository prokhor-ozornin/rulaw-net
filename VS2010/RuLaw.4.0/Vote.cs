using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Laws voting.</para>
  /// </summary>
  [XmlType("vote")]
  public class Vote : IComparable<Vote>, IEquatable<Vote>, IRuLawEntity, IDateable
  {
    /// <summary>
    ///   <para>Identifier of vote.</para>
    /// </summary>
    [JsonProperty("id")]
    [XmlElement("id")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Count of absent (non-voted) deputies in a faction.</para>
    /// </summary>
    [JsonProperty("absentCount")]
    [XmlElement("absentCount")]
    public virtual int? AbsentVotesCount { get; set; }

    /// <summary>
    ///   <para>Count of abstained deputies in a faction.</para>
    /// </summary>
    [JsonProperty("abstainCount")]
    [XmlElement("abstainCount")]
    public virtual int? AbstainVotesCount { get; set; }

    /// <summary>
    ///   <para>Count of deputies in a faction who have voted against.</para>
    /// </summary>
    [JsonProperty("againstCount")]
    [XmlElement("againstCount")]
    public virtual int? AgainstVotesCount { get; set; }

    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [JsonProperty("voteDate")]
    [XmlElement("voteDate")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string DateString
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Count of deputies in a faction who have voted for.</para>
    /// </summary>
    [JsonProperty("forCount")]
    [XmlElement("forCount")]
    public virtual int? ForVotesCount { get; set; }

    /// <summary>
    ///   <para>Whether the vote represents a faction (false), or a deputy (true) result.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual bool Personal
    {
      get { return !this.PersonResult.IsEmpty(); }
    }

    /// <summary>
    ///   <para>Result of deputy voting.</para>
    /// </summary>
    [JsonProperty("personResult")]
    [XmlElement("personResult")]
    public virtual string PersonResult { get; set; }

    /// <summary>
    ///   <para>Type of voting result.</para>
    /// </summary>
    [JsonProperty("resultType")]
    [XmlElement("resultType")]
    public virtual string ResultType { get; set; }

    /// <summary>
    ///   <para>Subject of convocation.</para>
    /// </summary>
    [JsonProperty("subject")]
    [XmlElement("subject")]
    public virtual string Subject { get; set; }

    /// <summary>
    ///   <para>Whether the law passed (true) or not (false) according to voting.</para>
    /// </summary>
    [JsonProperty("result")]
    [XmlElement("result")]
    public virtual bool Successful { get; set; }

    /// <summary>
    ///   <para>Number of voted deputies in faction.</para>
    /// </summary>
    [JsonProperty("voteCount")]
    [XmlElement("voteCount")]
    public virtual int? TotalVotesCount { get; set; }

    /// <summary>
    ///   <para>Returns result of deputy voting as instance of <see cref="VotePersonResult"/> enumeration.</para>
    /// </summary>
    /// <returns>Result of deputy voting, or a <c>null</c> reference if <see cref="PersonResult"/> property was not yet set.</returns>
    public virtual VotePersonResult? GetPersonResult()
    {
      if (this.PersonResult.IsEmpty())
      {
        return null;
      }

      switch (this.PersonResult.ToLowerInvariant())
      {
        case "for":
          return VotePersonResult.For;

        case "against":
          return VotePersonResult.Against;

        case "abstain":
          return VotePersonResult.Abstain;

        case "absent":
          return VotePersonResult.Absent;

        default:
          throw new InvalidOperationException();
      }
    }

    /// <summary>
    ///   <para>Returns type of voting result as instance of <see cref="VoteResultType"/> enumeration.</para>
    /// </summary>
    /// <returns>Type of voting result, or a <c>null</c> reference if <see cref="ResultType"/> property was not yet set.</returns>
    public virtual VoteResultType? GetResultType()
    {
      if (this.ResultType.IsEmpty())
      {
        return null;
      }

      switch (this.ResultType.ToLowerInvariant())
      {
        case "количественное":
          return VoteResultType.Quantitative;

        case "рейтинговое":
          return VoteResultType.Rating;

        case "качественное":
          return VoteResultType.Qualitative;

        case "альтернативное":
          return VoteResultType.Alternative;

        default:
          throw new InvalidOperationException();
      }
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Vote"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Vote"/> to compare with this instance.</param>
    public virtual int CompareTo(Vote other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="Vote"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Vote other)
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
      return this.Equals(other as Vote);
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
      return this.Subject;
    }
  }
}