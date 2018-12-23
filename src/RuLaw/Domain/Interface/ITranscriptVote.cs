namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface ITranscriptVote : IDateable
  {
    /// <summary>
    ///   <para>Transcript's line number.</para>
    /// </summary>
    int Line { get; }
  }
}