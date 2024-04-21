using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ITranscriptMeetingQuestionExtensions.Stage<ITranscriptMeetingQuestion>(null, "stage")).ThrowExactly<ArgumentNullException>().WithParameterName("questions");

      Validate([], [], null);
      Validate([], [], "subject");

      Enumerable.Empty<ITranscriptMeetingQuestion>().Stage("stage").Should().NotBeNull().And.BeEmpty();

      var first = new TranscriptMeetingQuestion { Stage = "first" };
      var second = new TranscriptMeetingQuestion { Stage = "second" };
      Validate([], [null], null);
      Validate([first], [null, first, second, null], first.Stage);

    }

    return;

    static void Validate(IEnumerable<ITranscriptMeetingQuestion> result, IEnumerable<ITranscriptMeetingQuestion> meetings, string stage) => meetings.Stage(stage).Should().BeAssignableTo<IEnumerable<ITranscriptMeetingQuestion>>().And.Equal(result);
  }
}