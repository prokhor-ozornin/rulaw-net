using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TranscriptMeeting"/>.</para>
/// </summary>
public sealed class TranscriptMeetingTest : ClassTest<TranscriptMeeting>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="TranscriptMeeting()"/>
  [Fact]
  public void Constructors()
  {
    typeof(TranscriptMeeting).Should().BeDerivedFrom<object>().And.Implement<ITranscriptMeeting>();

    var meeting = new TranscriptMeeting();
    meeting.Date.Should().BeNull();
    meeting.Number.Should().BeNull();
    meeting.LinesCount.Should().BeNull();
    meeting.Questions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeeting.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new TranscriptMeeting { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeeting.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property()
  {
    new TranscriptMeeting { Number = int.MaxValue }.Number.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeeting.LinesCount"/> property.</para>
  /// </summary>
  [Fact]
  public void LinesCount_Property()
  {
    new TranscriptMeeting { LinesCount = int.MaxValue }.LinesCount.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeeting.Questions"/> property.</para>
  /// </summary>
  [Fact]
  public void Questions_Property()
  {
    var meeting = new TranscriptMeeting();
    var question = new TranscriptMeetingQuestion();

    var questions = meeting.Questions.To<List<TranscriptMeetingQuestion>>();

    questions.Add(question);
    meeting.Questions.Should().ContainSingle().Which.Should().BeSameAs(question);

    questions.Remove(question);
    meeting.Questions.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeeting.CompareTo(ITranscriptMeeting)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(TranscriptMeeting.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TranscriptMeeting.Equals(ITranscriptMeeting)"/></description></item>
  ///     <item><description><see cref="TranscriptMeeting.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(TranscriptMeeting.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestEquality(nameof(TranscriptMeeting.Number), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeeting.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(TranscriptMeeting.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestHashCode(nameof(TranscriptMeeting.Number), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeeting.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new TranscriptMeeting {Date = DateTimeOffset.MaxValue}.ToString().Should().Be(DateTimeOffset.MaxValue.ToIsoString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new TranscriptMeeting
      {
        Date = DateTimeOffset.MinValue,
        LinesCount = 1,
        Number = 2,
        Questions = [new TranscriptMeetingQuestion()]
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}