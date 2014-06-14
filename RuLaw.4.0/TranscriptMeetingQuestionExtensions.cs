using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="TranscriptMeetingQuestion"/>.</para>
  /// </summary>
  /// <seealso cref="TranscriptMeetingQuestion"/>
  public static class TranscriptMeetingQuestionExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of transcripts questions, leaving those containing a specified stage.</para>
    /// </summary>
    /// <param name="questions">Source sequence of questions for filtering.</param>
    /// <param name="stage">Stage to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of questions that contain specified stage.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="questions"/> or <paramref name="stage"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="stage"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<TranscriptMeetingQuestion> Stage(this IEnumerable<TranscriptMeetingQuestion> questions, string stage)
    {
      Assertion.NotNull(questions);
      Assertion.NotEmpty(stage);

      return questions.Where(question => question != null && string.Equals(question.Stage, stage, StringComparison.InvariantCultureIgnoreCase));
    }
  }
}