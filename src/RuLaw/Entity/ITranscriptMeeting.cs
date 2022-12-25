namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma's meeting.</para>
/// </summary>
public interface ITranscriptMeeting : IDateable, IComparable<ITranscriptMeeting>, IEquatable<ITranscriptMeeting>
{
  /// <summary>
  ///   <para>Number of meeting.</para>
  /// </summary>
  int? Number { get; }

  /// <summary>
  ///   <para>Number of lines in transcript.</para>
  /// </summary>
  int? LinesCount { get; }

  /// <summary>
  ///   <para>Questions that were discussed during the meeting.</para>
  /// </summary>
  IEnumerable<ITranscriptMeetingQuestion> Questions { get; }
}