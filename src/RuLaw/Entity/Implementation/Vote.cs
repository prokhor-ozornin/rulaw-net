using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Laws voting.</para>
/// </summary>
[DataContract(Name = "vote")]
public sealed class Vote : IVote
{
  /// <summary>
  ///   <para>Identifier of vote.</para>
  /// </summary>
  [DataMember(Name = "id", IsRequired = true)]
  public long? Id { get; set; }

  /// <summary>
  ///   <para>Date of voting.</para>
  /// </summary>
  [DataMember(Name = "voteDate", IsRequired = true)]
  public DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Subject of convocation.</para>
  /// </summary>
  [DataMember(Name = "subject", IsRequired = true)]
  public string Subject { get; set; }

  /// <summary>
  ///   <para>Whether the law passed (true) or not (false) according to voting.</para>
  /// </summary>
  [DataMember(Name = "result", IsRequired = true)]
  public bool? Successful { get; set; }

  /// <summary>
  ///   <para>Type of voting result.</para>
  /// </summary>
  [DataMember(Name = "resultType", IsRequired = true)]
  public string ResultType { get; set; }

  /// <summary>
  ///   <para>Result of deputy voting.</para>
  /// </summary>
  [DataMember(Name = "personResult", IsRequired = true)]
  public string PersonResult { get; set; }

  /// <summary>
  ///   <para>Number of voted deputies in faction.</para>
  /// </summary>
  [DataMember(Name = "voteCount", IsRequired = true)]
  public int? TotalVotesCount { get; set; }

  /// <summary>
  ///   <para>Count of deputies in a faction who have voted for.</para>
  /// </summary>
  [DataMember(Name = "forCount", IsRequired = true)]
  public int? ForVotesCount { get; set; }

  /// <summary>
  ///   <para>Count of deputies in a faction who have voted against.</para>
  /// </summary>
  [DataMember(Name = "againstCount", IsRequired = true)]
  public int? AgainstVotesCount { get; set; }

  /// <summary>
  ///   <para>Count of abstained deputies in a faction.</para>
  /// </summary>
  [DataMember(Name = "abstainCount", IsRequired = true)]
  public int? AbstainVotesCount { get; set; }

  /// <summary>
  ///   <para>Count of absent (non-voted) deputies in a faction.</para>
  /// </summary>
  [DataMember(Name = "absentCount", IsRequired = true)]
  public int? AbsentVotesCount { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="IVote"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IVote"/> to compare with this instance.</param>
  public int CompareTo(IVote other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="IVote"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IVote other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IVote);

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
}