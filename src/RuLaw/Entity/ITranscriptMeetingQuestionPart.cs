using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Part of meeting question's transcript.</para>
/// </summary>
public interface ITranscriptMeetingQuestionPart : IComparable<ITranscriptMeetingQuestionPart>, IEquatable<ITranscriptMeetingQuestionPart>
{
  /// <summary>
  ///   <para>Start line of transcript's text fragment.</para>
  /// </summary>
  int? StartLine { get; }

  /// <summary>
  ///   <para>End line of transcript's text fragment.</para>
  /// </summary>
  int? EndLine { get; }

  /// <summary>
  ///   <para>Lines of transcript's fragment.</para>
  /// </summary>
  IEnumerable<string> Lines { get; }

  /// <summary>
  ///   <para>List of question' votes.</para>
  /// </summary>
  IEnumerable<ITranscriptVote> Votes { get; }

  string Text => Lines.Join(Environment.NewLine);
}