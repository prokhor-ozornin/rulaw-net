using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcript's vote.</para>
/// </summary>
[DataContract(Name = "vote")]
public sealed class TranscriptVote : ITranscriptVote
{
  /// <summary>
  ///   <para>Date of voting.</para>
  /// </summary>
  [DataMember(Name = "date", IsRequired = true)]
  public DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Transcript's line number.</para>
  /// </summary>
  [DataMember(Name = "line", IsRequired = true)]
  public int? Line { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="ITranscriptVote"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ITranscriptVote"/> to compare with this instance.</param>
  public int CompareTo(ITranscriptVote other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="ITranscriptVote"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(ITranscriptVote other) => this.Equality(other, nameof(Date), nameof(Line));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as ITranscriptVote);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Date), nameof(Line));
}