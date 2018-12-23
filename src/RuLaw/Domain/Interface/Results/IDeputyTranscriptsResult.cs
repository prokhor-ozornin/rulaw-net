using System.Collections.Generic;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of deputy's public speaches.</para>
  /// </summary>
  public interface IDeputyTranscriptsResult : INameable
  {
    /// <summary>
    ///   <para>Number of questions.</para>
    /// </summary>
    int Count { get; set; }

    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    IEnumerable<ITranscriptMeeting> Meetings { get; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    int Page { get; }

    /// <summary>
    ///   <para>Size of results page.</para>
    /// </summary>
    int PageSize { get; }
  }
}