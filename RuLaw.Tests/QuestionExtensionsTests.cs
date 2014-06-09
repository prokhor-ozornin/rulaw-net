using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="QuestionExtensions"/>.</para>
  /// </summary>
  public sealed class QuestionExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionExtensions.Lines(IEnumerable{Question}, int?, int?)"/> method.</para>
    /// </summary>
    [Fact]
    public void Lines_Method()
    {
      Assert.Throws<ArgumentNullException>(() => QuestionExtensions.Lines(null));

      Assert.False(Enumerable.Empty<Question>().Lines().Any());

      var first = new Question { StartLine = 0 };
      var second = new Question { StartLine = 1 };
      var third = new Question { StartLine = 2 };
      var questions = new[] { null, first, second, third };
      Assert.True(questions.Lines(1).SequenceEqual(new[] { second, third }));
      Assert.True(questions.Lines(null, 1).SequenceEqual(new[] { first, second, third }));
      Assert.True(questions.Lines(0, 2).SequenceEqual(new[] { first, second, third }));

      first = new Question { StartLine = 0, EndLine = 2 };
      second = new Question { StartLine = 1, EndLine = 1 };
      third = new Question { StartLine = 2, EndLine = 2 };
      questions = new[] { null, first, second, third };
      Assert.True(questions.Lines(1).SequenceEqual(new[] { second, third }));
      Assert.True(ReferenceEquals(second, questions.Lines(null, 1).Single()));
      Assert.True(ReferenceEquals(second, questions.Lines(1, 1).Single()));
    }
  }
}