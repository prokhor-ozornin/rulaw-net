using System.Collections.Generic;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcripts search result.</para>
  /// </summary>
  public interface IDateTranscriptsResult : IDateable
  {
    /// <summary>
    ///   <para>List of meetings transcripts.</para>
    /// </summary>
    IEnumerable<IDateTranscriptMeeting> Meetings { get; }
  }
}