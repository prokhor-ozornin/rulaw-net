using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ITranscriptMeetingQuestionExtensions"/>.</para>
/// </summary>
public sealed class ITranscriptMeetingQuestionExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ITranscriptMeetingQuestionExtensions.Stage{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Stage_Method()
  {
    AssertionExtensions.Should(() => ITranscriptMeetingQuestionExtensions.Stage<ITranscriptMeetingQuestion>(null, "stage")).ThrowExactly<ArgumentNullException>().WithParameterName("questions");
    AssertionExtensions.Should(() => Enumerable.Empty<ITranscriptMeetingQuestion>().Stage(null)).ThrowExactly<ArgumentNullException>().WithParameterName("stage");
    AssertionExtensions.Should(() => Enumerable.Empty<ITranscriptMeetingQuestion>().Stage(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("stage");

    Enumerable.Empty<ITranscriptMeetingQuestion>().Stage("stage").Should().NotBeNull().And.BeEmpty();

    var first = new TranscriptMeetingQuestion(new {Stage = "FIRST"});
    var second = new TranscriptMeetingQuestion(new {Stage = "Second"});
    var questions = first.ToSequence(second, null);
    questions.Stage("first").Should().NotBeNullOrEmpty().And.Equal(first);
    questions.Stage("second").Should().NotBeNullOrEmpty().And.Equal(second);
  }
}