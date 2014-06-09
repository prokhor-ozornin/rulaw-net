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
  [Description("Laws voting")]
  [XmlType("vote")]
  public class Vote : IComparable<Vote>, IEquatable<Vote>, IRuLawEntity, IDateable
  {
    /// <summary>
    ///   <para>Identifier of vote.</para>
    /// </summary>
    [Description("Identifier of vote")]
    [JsonProperty("id")]
    [XmlElement("id")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Count of absent (non-voted) deputies in a faction.</para>
    /// </summary>
    [Description("Count of absent (non-voted) deputies in a faction")]
    [JsonProperty("absentCount")]
    [XmlElement("absentCount")]
    public virtual int? AbsentVotesCount { get; set; }

    /// <summary>
    ///   <para>Count of abstained deputies in a faction.</para>
    /// </summary>
    [Description("Count of abstained deputies in a faction")]
    [JsonProperty("abstainCount")]
    [XmlElement("abstainCount")]
    public virtual int? AbstainVotesCount { get; set; }

    /// <summary>
    ///   <para>Count of deputies in a faction who have voted against.</para>
    /// </summary>
    [Description("Count of deputies in a faction who have voted against")]
    [JsonProperty("againstCount")]
    [XmlElement("againstCount")]
    public virtual int? AgainstVotesCount { get; set; }

    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [Description("Date of voting")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [Description("Date of voting")]
    [JsonProperty("voteDate")]
    [XmlElement("voteDate")]
    public virtual string DateString
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Count of deputies in a faction who have voted for.</para>
    /// </summary>
    [Description("Count of deputies in a faction who have voted for")]
    [JsonProperty("forCount")]
    [XmlElement("forCount")]
    public virtual int? ForVotesCount { get; set; }

    /// <summary>
    ///   <para>Whether the vote represents a faction (false), or a deputy (true) result.</para>
    /// </summary>
    [Description("Whether the vote represents a faction (false), or a deputy (true) result")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual bool Personal
    {
      get { return !this.PersonResult.IsEmpty(); }
    }

    /// <summary>
    ///   <para>Result of deputy voting.</para>
    /// </summary>
    [Description("Result of deputy voting")]
    [JsonProperty("personResult")]
    [XmlElement("personResult")]
    public virtual string PersonResult { get; set; }

    /// <summary>
    ///   <para>Type of voting result.</para>
    /// </summary>
    [Description("Type of voting result")]
    [JsonProperty("resultType")]
    [XmlElement("resultType")]
    public virtual string ResultType { get; set; }

    /// <summary>
    ///   <para>Subject of convocation.</para>
    /// </summary>
    [Description("Subject of convocation")]
    [JsonProperty("subject")]
    [XmlElement("subject")]
    public virtual string Subject { get; set; }

    /// <summary>
    ///   <para>Whether the law passed (true) or not (false) according to voting.</para>
    /// </summary>
    [Description("Whether the law passed (true) or not (false) according to voting")]
    [JsonProperty("result")]
    [XmlElement("result")]
    public virtual bool Successful { get; set; }

    /// <summary>
    ///   <para>Number of voted deputies in faction.</para>
    /// </summary>
    [Description("Number of voted deputies in faction")]
    [JsonProperty("voteCount")]
    [XmlElement("voteCount")]
    public virtual int? TotalVotesCount { get; set; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
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
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
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
    ///   <para>Compares the current vote with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Vote"/> to compare with this instance.</param>
    public virtual int CompareTo(Vote other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two votes instances are equal.</para>
    /// </summary>
    /// <param name="other">The vote to compare with the current one.</param>
    /// <returns><c>true</c> if specified vote is equal to the current, <c>false</c> otherwise.</returns>
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
    ///   <para>Returns a <see cref="string"/> that represents the current vote.</para>
    /// </summary>
    /// <returns>A string that represents the current vote.</returns>
    public override string ToString()
    {
      return this.Subject;
    }
  }
}