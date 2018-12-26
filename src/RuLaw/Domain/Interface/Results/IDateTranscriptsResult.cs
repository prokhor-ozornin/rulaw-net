namespace RuLaw
{
  using System.Collections.Generic;

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