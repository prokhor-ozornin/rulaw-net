using System.Runtime.Serialization;
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
  /// <seealso cref="QuestionTranscriptsResult(IEnumerable{ITranscriptMeeting}?)"/>
  /// <seealso cref="QuestionTranscriptsResult(QuestionTranscriptsResult.Info)"/>
  /// <seealso cref="QuestionTranscriptsResult(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(QuestionTranscriptsResult).Should().BeDerivedFrom<object>().And.Implement<IQuestionTranscriptsResult>();

    var result = new QuestionTranscriptsResult();
    result.Meetings.Should().BeEmpty();

    result = new QuestionTranscriptsResult(new QuestionTranscriptsResult.Info());
    result.Meetings.Should().BeEmpty();

    result = new QuestionTranscriptsResult(new {});
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var result = new QuestionTranscriptsResult(new
    {
    });
    result.Meetings.Should().BeEmpty();

    var meetings = result.Meetings.To<List<TranscriptMeeting>>();
    var meeting = new TranscriptMeeting(new
    {
    });
    meetings.Add(meeting);
    result.Meetings.Should().ContainSingle().Which.Should().BeSameAs(meeting);

    meetings.Remove(meeting);
    result.Meetings.Should().BeEmpty();
  }
}

/// <summary>
///   <para>Tests set for class <see cref="QuestionTranscriptsResult.Info"/>.</para>
/// </summary>
public sealed class QuestionTranscriptsResultInfoTests : ClassTest<QuestionTranscriptsResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="QuestionTranscriptsResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(QuestionTranscriptsResult.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IQuestionTranscriptsResult>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new QuestionTranscriptsResult.Info();
    info.Meetings.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionTranscriptsResult.Info.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var meetings = new List<TranscriptMeeting>();
    new QuestionTranscriptsResult.Info { Meetings = meetings }.Meetings.Should().BeSameAs(meetings);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionTranscriptsResult.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new QuestionTranscriptsResult.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<QuestionTranscriptsResult>();
      result.Meetings.Should().BeEmpty();
    }

    return;

    static void Validate()
    {

    }
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