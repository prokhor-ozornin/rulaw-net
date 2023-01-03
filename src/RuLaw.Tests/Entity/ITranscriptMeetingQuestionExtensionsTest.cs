using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ITranscriptMeetingQuestionExtensions"/>.</para>
/// </summary>
public sealed class ITranscriptMeetingQuestionExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ITranscriptMeetingQuestionExtensions.Stage{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Stage_Method()
  {
    AssertionExtensions.Should(() => ITranscriptMeetingQuestionExtensions.Stage<ITranscriptMeetingQuestion>(null, "stage")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<ITranscriptMeetingQuestion>().Stage(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<ITranscriptMeetingQuestion>().Stage(string.Empty)).ThrowExactly<ArgumentException>();

    Enumerable.Empty<ITranscriptMeetingQuestion>().Stage("stage").Should().NotBeNull().And.BeEmpty();

    var first = new TranscriptMeetingQuestion(new {Stage = "FIRST"});
    var second = new TranscriptMeetingQuestion(new {Stage = "Second"});
    var questions = new[] {null, first, second};
    questions.Stage("first").Should().NotBeNullOrEmpty().And.Equal(first);
    questions.Stage("second").Should().NotBeNullOrEmpty().And.Equal(second);
  }
}