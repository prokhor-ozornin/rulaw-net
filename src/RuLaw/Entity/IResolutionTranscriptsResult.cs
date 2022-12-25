namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma law's resolution.</para>
/// </summary>
public interface IResolutionTranscriptsResult : IEquatable<IResolutionTranscriptsResult>
{
  /// <summary>
  ///   <para>Number of resolution.</para>
  /// </summary>
  string? Number { get; }

  /// <summary>
  ///   <para>Collection of Duma's meetings.</para>
  /// </summary>
  IEnumerable<ITranscriptMeeting> Meetings { get; }
}