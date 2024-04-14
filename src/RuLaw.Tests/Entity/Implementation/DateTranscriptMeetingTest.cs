using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTranscriptMeeting"/>.</para>
/// </summary>
public sealed class DateTranscriptMeetingTest : ClassTest<DateTranscriptMeeting>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DateTranscriptMeeting()"/>
  [Fact]
  public void Constructors()
  {
    typeof(DateTranscriptMeeting).Should().BeDerivedFrom<object>().And.Implement<IDateTranscriptMeeting>();

    var meeting = new DateTranscriptMeeting();
    meeting.Date.Should().BeNull();
    meeting.Number.Should().BeNull();
    meeting.Lines.Should().BeEmpty();
    meeting.Votes.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new DateTranscriptMeeting { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property()
  {
    new DateTranscriptMeeting { Number = int.MaxValue }.Number.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Lines"/> property.</para>
  /// </summary>
  [Fact]
  public void Lines_Property()
  {
    var meeting = new DateTranscriptMeeting();
    meeting.Lines.Should().BeEmpty();

    var lines = meeting.Lines.To<List<string>>();
    lines.Add("line");
    meeting.Lines.Should().ContainSingle().Which.Should().Be("line");
    lines.Remove("line");
    meeting.Lines.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Votes"/> property.</para>
  /// </summary>
  [Fact]
  public void Votes_Property()
  {
    var meeting = new DateTranscriptMeeting();
    meeting.Votes.Should().BeEmpty();

    var vote = new TranscriptVote();

    var votes = meeting.Votes.To<List<TranscriptVote>>();
    votes.Add(vote);
    meeting.Votes.Should().ContainSingle().Which.Should().BeSameAs(vote);
    votes.Remove(vote);
    meeting.Votes.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.CompareTo(IDateTranscriptMeeting)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(DateTranscriptMeeting.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="DateTranscriptMeeting.Equals(IDateTranscriptMeeting)"/></description></item>
  ///     <item><description><see cref="DateTranscriptMeeting.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(DateTranscriptMeeting.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(DateTranscriptMeeting.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new DateTranscriptMeeting {Lines = new List<string> {"first", "second"}}.ToString().Should().Be($"first{Environment.NewLine}second");
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new DateTranscriptMeeting
      {
        Date = DateTimeOffset.MinValue,
        Lines = ["line"],
        Number = 1,
        Votes = [new TranscriptVote { Date = DateTimeOffset.MinValue, Line = 2 }]
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}