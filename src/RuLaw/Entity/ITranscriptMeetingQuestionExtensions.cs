using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ITranscriptMeetingQuestion"/> interface.</para>
/// </summary>
/// <seealso cref="ITranscriptMeetingQuestion"/>
public static class ITranscriptMeetingQuestionExtensions
{
  /// <param name="questions">Source sequence of questions for filtering.</param>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  extension<TEntity>(IEnumerable<TEntity> questions) where TEntity : ITranscriptMeetingQuestion
  {
    /// <summary>
    ///   <para>Filters sequence of transcripts questions, leaving those containing a specified stage.</para>
    /// </summary>
    /// <param name="stage">Stage to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of questions that contain specified stage.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="questions"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Stage(string stage) => questions?.Where(question => question is not null && question.Stage.ToInvariantString().Equals(stage.ToInvariantString())) ?? throw new ArgumentNullException(nameof(questions));
  }
}