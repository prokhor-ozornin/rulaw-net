namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface ITranscriptVote : IDateable, IComparable<ITranscriptVote>, IEquatable<ITranscriptVote>
{
  /// <summary>
  ///   <para>Transcript's line number.</para>
  /// </summary>
  int? Line { get; }
}