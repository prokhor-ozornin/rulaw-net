using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Transcript's question.</para>
/// </summary>
public interface ITranscriptMeetingQuestion : INameable, IComparable<ITranscriptMeetingQuestion>, IEquatable<ITranscriptMeetingQuestion>
{
  /// <summary>
  ///   <para>Question's review stage.</para>
  /// </summary>
  string Stage { get; }

  /// <summary>
  ///   <para>List of transcript's fragments.</para>
  /// </summary>
  IEnumerable<ITranscriptMeetingQuestionPart> Parts { get; }
}