using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma's meeting.</para>
/// </summary>
[DataContract(Name = "meeting")]
public sealed class TranscriptMeeting : ITranscriptMeeting
{
  /// <summary>
  ///   <para>Date of meeting.</para>
  /// </summary>
  [DataMember(Name = "date", IsRequired = true)]
  public DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Number of meeting.</para>
  /// </summary>
  [DataMember(Name = "number", IsRequired = true)]
  public int? Number { get; set; }

  /// <summary>
  ///   <para>Number of lines in transcript.</para>
  /// </summary>
  [DataMember(Name = "maxNumber", IsRequired = true)]
  public int? LinesCount { get; set; }

  /// <summary>
  ///   <para>Questions that were discussed during the meeting.</para>
  /// </summary>
  [DataMember(Name = "questions", IsRequired = true)]
  public IEnumerable<ITranscriptMeetingQuestion> Questions { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="ITranscriptMeeting"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ITranscriptMeeting"/> to compare with this instance.</param>
  public int CompareTo(ITranscriptMeeting other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="ITranscriptMeeting"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(ITranscriptMeeting other) => this.Equality(other, nameof(Date), nameof(Number));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as ITranscriptMeeting);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Date), nameof(Number));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="TranscriptMeeting"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="TranscriptMeeting"/>.</returns>
  public override string ToString() => Date is not null ? Date.Value.ToIsoString() : string.Empty;
}