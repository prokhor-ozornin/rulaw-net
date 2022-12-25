using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Laws voting.</para>
/// </summary>
public sealed class Vote : IVote
{
  /// <summary>
  ///   <para>Identifier of vote.</para>
  /// </summary>
  public long? Id { get; }

  /// <summary>
  ///   <para>Date of voting.</para>
  /// </summary>
  public DateTimeOffset? Date { get; }

  /// <summary>
  ///   <para>Subject of convocation.</para>
  /// </summary>
  public string? Subject { get; }

  /// <summary>
  ///   <para>Whether the law passed (true) or not (false) according to voting.</para>
  /// </summary>
  public bool? Successful { get; }

  /// <summary>
  ///   <para>Type of voting result.</para>
  /// </summary>
  public string? ResultType { get; }

  /// <summary>
  ///   <para>Result of deputy voting.</para>
  /// </summary>
  public string? PersonResult { get; }

  /// <summary>
  ///   <para>Number of voted deputies in faction.</para>
  /// </summary>
  public int? TotalVotesCount { get; }

  /// <summary>
  ///   <para>Count of deputies in a faction who have voted for.</para>
  /// </summary>
  public int? ForVotesCount { get; }

  /// <summary>
  ///   <para>Count of deputies in a faction who have voted against.</para>
  /// </summary>
  public int? AgainstVotesCount { get; }

  /// <summary>
  ///   <para>Count of abstained deputies in a faction.</para>
  /// </summary>
  public int? AbstainVotesCount { get; }

  /// <summary>
  ///   <para>Count of absent (non-voted) deputies in a faction.</para>
  /// </summary>
  public int? AbsentVotesCount { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="date"></param>
  /// <param name="subject"></param>
  /// <param name="successful"></param>
  /// <param name="resultType"></param>
  /// <param name="personResult"></param>
  /// <param name="totalVotesCount"></param>
  /// <param name="forVotesCount"></param>
  /// <param name="againstVotesCount"></param>
  /// <param name="abstainVotesCount"></param>
  /// <param name="absentVotesCount"></param>
  public Vote(long? id = null,
              DateTimeOffset? date = null,
              string? subject = null,
              bool? successful = null,
              string? resultType = null,
              string? personResult = null,
              int? totalVotesCount = null,
              int? forVotesCount = null,
              int? againstVotesCount = null,
              int? abstainVotesCount = null,
              int? absentVotesCount = null)
  {
    Id = id;
    Date = date;
    Subject = subject;
    Successful = successful;
    ResultType = resultType;
    PersonResult = personResult;
    TotalVotesCount = totalVotesCount;
    ForVotesCount = forVotesCount;
    AgainstVotesCount = againstVotesCount;
    AbstainVotesCount = abstainVotesCount;
    AbsentVotesCount = absentVotesCount;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Vote(Info info)
  {
    Id = info.Id;
    Date = info.Date != null ? DateTimeOffset.Parse(info.Date) : null;
    Subject = info.Subject;
    Successful = info.Successful;
    ResultType = info.ResultType;
    PersonResult = info.PersonResult;
    TotalVotesCount = info.TotalVotesCount;
    ForVotesCount = info.ForVotesCount;
    AgainstVotesCount = info.AgainstVotesCount;
    AbstainVotesCount = info.AbstainVotesCount;
    AbsentVotesCount = info.AbsentVotesCount;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Vote(object info) : this(new Info().Properties(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="IVote"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IVote"/> to compare with this instance.</param>
  public int CompareTo(IVote? other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="IVote"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IVote? other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object? other) => Equals(other as IVote);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Id));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Vote"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Vote"/>.</returns>
  public override string ToString() => Subject ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "vote")]
  public sealed record Info : IResultable<IVote>
  {
    /// <summary>
    ///   <para>Date of voting.</para>
    /// </summary>
    [DataMember(Name = "voteDate", IsRequired = true)]
    public string? Date { get; init; }

    /// <summary>
    ///   <para>Identifier of vote.</para>
    /// </summary>
    [DataMember(Name = "id", IsRequired = true)]
    public long? Id { get; init; }

    /// <summary>
    ///   <para>Subject of convocation.</para>
    /// </summary>
    [DataMember(Name = "subject", IsRequired = true)]
    public string? Subject { get; init; }

    /// <summary>
    ///   <para>Whether the law passed (true) or not (false) according to voting.</para>
    /// </summary>
    [DataMember(Name = "result", IsRequired = true)]
    public bool? Successful { get; init; }

    /// <summary>
    ///   <para>Type of voting result.</para>
    /// </summary>
    [DataMember(Name = "resultType", IsRequired = true)]
    public string? ResultType { get; init; }

    /// <summary>
    ///   <para>Result of deputy voting.</para>
    /// </summary>
    [DataMember(Name = "personResult", IsRequired = true)]
    public string? PersonResult { get; init; }

    /// <summary>
    ///   <para>Number of voted deputies in faction.</para>
    /// </summary>
    [DataMember(Name = "voteCount", IsRequired = true)]
    public int? TotalVotesCount { get; init; }

    /// <summary>
    ///   <para>Count of deputies in a faction who have voted for.</para>
    /// </summary>
    [DataMember(Name = "forCount", IsRequired = true)]
    public int? ForVotesCount { get; init; }

    /// <summary>
    ///   <para>Count of deputies in a faction who have voted against.</para>
    /// </summary>
    [DataMember(Name = "againstCount", IsRequired = true)]
    public int? AgainstVotesCount { get; init; }

    /// <summary>
    ///   <para>Count of abstained deputies in a faction.</para>
    /// </summary>
    [DataMember(Name = "abstainCount", IsRequired = true)]
    public int? AbstainVotesCount { get; init; }

    /// <summary>
    ///   <para>Count of absent (non-voted) deputies in a faction.</para>
    /// </summary>
    [DataMember(Name = "absentCount", IsRequired = true)]
    public int? AbsentVotesCount { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IVote Result() => new Vote(this);
  }
}