namespace RuLaw
{
  using System;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ITranscriptMeetingQuestionPart"/>.</para>
  /// </summary>
  /// <seealso cref="ITranscriptMeetingQuestionPart"/>
  public static class ITranscriptMeetingQuestionPartExtensions
  {
    /// <summary>
    ///   <para>Returns full text of transcript.</para>
    /// </summary>
    /// <param name="part">Transcript part instance.</param>
    /// <returns>Text of transcript.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="part"/> is a <c>null</c> reference.</exception>
    public static string Text(this ITranscriptMeetingQuestionPart part)
    {
      Assertion.NotNull(part);

      return part.Lines.Join(Environment.NewLine);
    }
  }
}