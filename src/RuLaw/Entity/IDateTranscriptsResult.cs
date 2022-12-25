namespace RuLaw;

/// <summary>
///   <para>Transcripts search result.</para>
/// </summary>
public interface IDateTranscriptsResult : IDateable, IComparable<IDateTranscriptsResult>, IEquatable<IDateTranscriptsResult>
{
  /// <summary>
  ///   <para>List of meetings transcripts.</para>
  /// </summary>
  IEnumerable<IDateTranscriptMeeting> Meetings { get; }
}