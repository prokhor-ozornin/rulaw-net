using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Question"/>.</para>
  /// </summary>
  /// <seealso cref="Question"/>
  public static class QuestionExtensions
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="questions"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="questions"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Question> Lines(this IEnumerable<Question> questions, int? from = null, int? to = null)
    {
      Assertion.NotNull(questions);

      if (from != null)
      {
        questions = questions.Where(question => question != null && question.StartLine >= from.Value);
      }
      if (to != null)
      {
        questions = questions.Where(question => question != null && question.EndLine <= to.Value);
      }

      return questions;
    }
  }
}