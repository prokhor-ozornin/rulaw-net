namespace RuLaw
{
  using System.Collections.Generic;

  /// <summary>
  ///   <para>Transcript's question.</para>
  /// </summary>
  public interface ITranscriptMeetingQuestion : INameable
  {
    /// <summary>
    ///   <para>List of transcript's fragments.</para>
    /// </summary>
    IEnumerable<ITranscriptMeetingQuestionPart> Parts { get; }

    /// <summary>
    ///   <para>Question's review stage.</para>
    /// </summary>
    string Stage { get; }
  }
}