using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma's meeting.</para>
/// </summary>
public sealed class TranscriptMeeting : ITranscriptMeeting
{
  /// <summary>
  ///   <para>Date of meeting.</para>
  /// </summary>
  public DateTimeOffset? Date { get; }

  /// <summary>
  ///   <para>Number of meeting.</para>
  /// </summary>
  public int? Number { get; }

  /// <summary>
  ///   <para>Number of lines in transcript.</para>
  /// </summary>
  public int? LinesCount { get; }

  /// <summary>
  ///   <para>Questions that were discussed during the meeting.</para>
  /// </summary>
  public IEnumerable<ITranscriptMeetingQuestion> Questions { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="date"></param>
  /// <param name="number"></param>
  /// <param name="linesCount"></param>
  /// <param name="questions"></param>
  public TranscriptMeeting(DateTimeOffset? date = null,
                           int? number = null,
                           int? linesCount = null,
                           IEnumerable<ITranscriptMeetingQuestion> questions = null)
  {
    Date = date;
    Number = number;
    LinesCount = linesCount;
    Questions = questions ?? new List<ITranscriptMeetingQuestion>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public TranscriptMeeting(Info info)
  {
    Date = info.Date;
    Number = info.Number;
    LinesCount = info.LinesCount;
    Questions = info.Questions ?? new List<TranscriptMeetingQuestion>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public TranscriptMeeting(object info) : this(new Info().SetState(info)) {}

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
  public override string ToString() => Date != null ? Date.Value.ToIsoString() : string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "meeting")]
  public sealed record Info : IResultable<ITranscriptMeeting>
  {
    /// <summary>
    ///   <para>Date of meeting.</para>
    /// </summary>
    [DataMember(Name = "date", IsRequired = true)]
    public DateTimeOffset? Date { get; init; }

    /// <summary>
    ///   <para>Number of meeting.</para>
    /// </summary>
    [DataMember(Name = "number", IsRequired = true)]
    public int? Number { get; init; }

    /// <summary>
    ///   <para>Number of lines in transcript.</para>
    /// </summary>
    [DataMember(Name = "maxNumber", IsRequired = true)]
    public int? LinesCount { get; init; }

    /// <summary>
    ///   <para>Questions that were discussed during the meeting.</para>
    /// </summary>
    [DataMember(Name = "questions", IsRequired = true)]
    public List<TranscriptMeetingQuestion> Questions { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ITranscriptMeeting ToResult() => new TranscriptMeeting(this);
  }
}