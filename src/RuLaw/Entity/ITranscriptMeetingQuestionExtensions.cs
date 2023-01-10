﻿using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ITranscriptMeetingQuestion"/>.</para>
/// </summary>
/// <seealso cref="ITranscriptMeetingQuestion"/>
public static class ITranscriptMeetingQuestionExtensions
{
  /// <summary>
  ///   <para>Filters sequence of transcripts questions, leaving those containing a specified stage.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="questions">Source sequence of questions for filtering.</param>
  /// <param name="stage">Stage to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of questions that contain specified stage.</returns>
  public static IEnumerable<TEntity> Stage<TEntity>(this IEnumerable<TEntity> questions, string stage) where TEntity : ITranscriptMeetingQuestion
  {
    if (questions is null) throw new ArgumentNullException(nameof(questions));
    if (stage is null) throw new ArgumentNullException(nameof(stage));
    if (stage.IsEmpty()) throw new ArgumentException(nameof(stage));

    return questions.Where(question => question != null && string.Equals(question.Stage, stage, StringComparison.InvariantCultureIgnoreCase));
  }
}