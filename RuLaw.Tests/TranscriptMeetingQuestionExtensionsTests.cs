using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TranscriptMeetingQuestionExtensions"/>.</para>
  /// </summary>
  public sealed class TranscriptMeetingQuestionExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionExtensions.Stage(IEnumerable{TranscriptMeetingQuestion}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Stage_Method()
    {
      Assert.Throws<ArgumentNullException>(() => TranscriptMeetingQuestionExtensions.Stage(null, "stage"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<TranscriptMeetingQuestion>().Stage(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<TranscriptMeetingQuestion>().Stage(string.Empty));

      Assert.False(Enumerable.Empty<TranscriptMeetingQuestion>().Stage("stage").Any());

      var first = new TranscriptMeetingQuestion { Stage = "FIRST" };
      var second = new TranscriptMeetingQuestion { Stage = "Second" };
      var questions = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, questions.Stage("first").Single()));
      Assert.True(ReferenceEquals(second, questions.Stage("second").Single()));
    }
  }
}