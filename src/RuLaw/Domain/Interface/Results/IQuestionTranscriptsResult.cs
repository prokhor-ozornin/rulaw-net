namespace RuLaw
{
  using System.Collections.Generic;

  /// <summary>
  ///   <para>Transcript of Duma's agenda question.</para>
  /// </summary>
  public interface IQuestionTranscriptsResult
  {
    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    IEnumerable<ITranscriptMeeting> Meetings { get; }
  }
}