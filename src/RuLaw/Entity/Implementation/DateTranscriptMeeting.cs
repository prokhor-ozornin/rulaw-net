using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma's meeting.</para>
/// </summary>
[DataContract(Name = "meeting")]
public sealed class DateTranscriptMeeting : IDateTranscriptMeeting
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
  ///   <para>Transcript's text lines.</para>
  /// </summary>
  [DataMember(Name = "lines", IsRequired = true)]
  public IEnumerable<string> Lines { get; set; }

  /// <summary>
  ///   <para>Meeting's votes.</para>
  /// </summary>
  [DataMember(Name = "votes", IsRequired = true)]
  public IEnumerable<ITranscriptVote> Votes { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="IDateTranscriptMeeting"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IDateTranscriptMeeting"/> to compare with this instance.</param>
  public int CompareTo(IDateTranscriptMeeting other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="IDateTranscriptMeeting"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IDateTranscriptMeeting other) => this.Equality(other, nameof(Date));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IDateTranscriptMeeting);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Date));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DateTranscriptMeeting"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="DateTranscriptMeeting"/>.</returns>
  public override string ToString() => (this as IDateTranscriptMeeting).Text;
}