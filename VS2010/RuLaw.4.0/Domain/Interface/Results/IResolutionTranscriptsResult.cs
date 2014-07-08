using System.Collections.Generic;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of Duma law's resolution.</para>
  /// </summary>
  public interface IResolutionTranscriptsResult
  {
    /// <summary>
    ///   <para>Collection of Duma's meetings.</para>
    /// </summary>
    IEnumerable<ITranscriptMeeting> Meetings { get; }

    /// <summary>
    ///   <para>Number of resolution.</para>
    /// </summary>
    string Number { get; }
  }
}