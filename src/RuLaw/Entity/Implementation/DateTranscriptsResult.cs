using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcripts search result.</para>
/// </summary>
public sealed class DateTranscriptsResult : IDateTranscriptsResult
{
  /// <summary>
  ///   <para>Date of meetings.</para>
  /// </summary>
  public DateTimeOffset? Date { get; }

  /// <summary>
  ///   <para>List of meetings transcripts.</para>
  /// </summary>
  public IEnumerable<IDateTranscriptMeeting> Meetings { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="date"></param>
  /// <param name="meetings"></param>
  public DateTranscriptsResult(DateTimeOffset? date = null,
                               IEnumerable<IDateTranscriptMeeting> meetings = null)
  {
    Date = date;
    Meetings = meetings ?? new List<IDateTranscriptMeeting>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DateTranscriptsResult(Info info)
  {
    Date = info.Date != null ? DateTimeOffset.Parse(info.Date) : null;
    Meetings = info.Meetings ?? new List<DateTranscriptMeeting>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DateTranscriptsResult(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="DateTranscriptsResult"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="DateTranscriptsResult"/> to compare with this instance.</param>
  public int CompareTo(IDateTranscriptsResult other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="IDateTranscriptsResult"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IDateTranscriptsResult other) => this.Equality(other, nameof(Date));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IDateTranscriptsResult);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Date));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DateTranscriptsResult"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="DateTranscriptsResult"/>.</returns>
  public override string ToString() => Date != null ? Date.Value.AsString() : string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "result")]
  public sealed record Info : IResultable<IDateTranscriptsResult>
  {
    /// <summary>
    ///   <para>Date of meetings.</para>
    /// </summary>
    [DataMember(Name = "date", IsRequired = true)]
    public string Date { get; init; }

    /// <summary>
    ///   <para>List of meetings transcripts.</para>
    /// </summary>
    [DataMember(Name = "meetings", IsRequired = true)]
    public List<DateTranscriptMeeting> Meetings { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IDateTranscriptsResult ToResult() => new DateTranscriptsResult(this);
  }
}