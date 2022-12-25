namespace RuLaw;

/// <summary>
///   <para>Transcript of deputy's public speaches.</para>
/// </summary>
public interface IDeputyTranscriptsResult : INameable, IPageable, IComparable<IDeputyTranscriptsResult>
{
  /// <summary>
  ///   <para>Number of questions.</para>
  /// </summary>
  int? Count { get; }

  /// <summary>
  ///   <para>Collection of duma's meetings.</para>
  /// </summary>
  IEnumerable<ITranscriptMeeting> Meetings { get; }
}