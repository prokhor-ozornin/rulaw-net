using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="QuestionTranscriptsResult"/>.</para>
/// </summary>
public sealed class QuestionTranscriptsResultTest : ClassTest<QuestionTranscriptsResult>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="QuestionTranscriptsResult()"/>
  [Fact]
  public void Constructors()
  {
    typeof(QuestionTranscriptsResult).Should().BeDerivedFrom<object>().And.Implement<IQuestionTranscriptsResult>();

    var result = new QuestionTranscriptsResult();
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var result = new QuestionTranscriptsResult();
    result.Meetings.Should().BeEmpty();

    var meetings = result.Meetings.To<List<TranscriptMeeting>>();
    var meeting = new TranscriptMeeting();
    meetings.Add(meeting);
    result.Meetings.Should().ContainSingle().Which.Should().BeSameAs(meeting);

    meetings.Remove(meeting);
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new QuestionTranscriptsResult());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}