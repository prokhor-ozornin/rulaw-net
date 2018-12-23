using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ITranscriptMeetingQuestionExtensions"/>.</para>
  /// </summary>
  public sealed class ITranscriptMeetingQuestionExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ITranscriptMeetingQuestionExtensions.Stage{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Stage_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ITranscriptMeetingQuestionExtensions.Stage<ITranscriptMeetingQuestion>(null, "stage"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<ITranscriptMeetingQuestion>().Stage(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<ITranscriptMeetingQuestion>().Stage(string.Empty));

      Assert.Empty(Enumerable.Empty<ITranscriptMeetingQuestion>().Stage("stage"));

      var first = new TranscriptMeetingQuestion { Stage = "FIRST" };
      var second = new TranscriptMeetingQuestion { Stage = "Second" };
      var questions = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, questions.Stage("first").Single()));
      Assert.True(ReferenceEquals(second, questions.Stage("second").Single()));
    }
  }
}