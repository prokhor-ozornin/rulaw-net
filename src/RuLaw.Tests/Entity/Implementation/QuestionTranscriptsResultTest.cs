using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="QuestionTranscriptsResult"/>.</para>
/// </summary>
public sealed class QuestionTranscriptsResultTest : UnitTest<QuestionTranscriptsResult>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var result = new QuestionTranscriptsResult(new {});
    result.Meetings.Should().BeEmpty();

    var meetings = result.Meetings.To<List<TranscriptMeeting>>();
    var meeting = new TranscriptMeeting(new {});
    meetings.Add(meeting);
    result.Meetings.Should().ContainSingle().Which.Should().BeSameAs(meeting);

    meetings.Remove(meeting);
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="QuestionTranscriptsResult(IEnumerable{ITranscriptMeeting}?)"/>
  /// <seealso cref="QuestionTranscriptsResult(QuestionTranscriptsResult.Info)"/>
  /// <seealso cref="QuestionTranscriptsResult(object)"/>
  [Fact]
  public void Constructors()
  {
    var result = new QuestionTranscriptsResult();
    result.Meetings.Should().BeEmpty();

    result = new QuestionTranscriptsResult(new QuestionTranscriptsResult.Info());
    result.Meetings.Should().BeEmpty();

    result = new QuestionTranscriptsResult(new {});
    result.Meetings.Should().BeEmpty();
  }
}

/// <summary>
///   <para>Tests set for class <see cref="QuestionTranscriptsResult.Info"/>.</para>
/// </summary>
public sealed class QuestionTranscriptsResultInfoTests : UnitTest<QuestionTranscriptsResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionTranscriptsResult.Info.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var meetings = new List<TranscriptMeeting>();
    new QuestionTranscriptsResult.Info {Meetings = meetings}.Meetings.Should().BeSameAs(meetings);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="QuestionTranscriptsResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new QuestionTranscriptsResult.Info();
    info.Meetings.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionTranscriptsResult.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new QuestionTranscriptsResult.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<QuestionTranscriptsResult>();
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization() { throw new NotImplementedException(); }
}