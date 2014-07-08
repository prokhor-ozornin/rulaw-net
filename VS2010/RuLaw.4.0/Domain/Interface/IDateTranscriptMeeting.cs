using System.Collections.Generic;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of Duma's meeting.</para>
  /// </summary>
  public interface IDateTranscriptMeeting : IDateable
  {
    /// <summary>
    ///   <para>Transcript's text lines.</para>
    /// </summary>
    IEnumerable<string> Lines { get; }

    /// <summary>
    ///   <para>Number of meeting.</para>
    /// </summary>
    int Number { get; }

    /// <summary>
    ///   <para>Meeting's votes.</para>
    /// </summary>
    IEnumerable<ITranscriptVote> Votes { get; }
  }
}