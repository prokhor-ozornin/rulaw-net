using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTranscriptMeeting"/>.</para>
/// </summary>
public sealed class DateTranscriptMeetingTest : UnitTest<DateTranscriptMeeting>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new DateTranscriptMeeting(new {Date = DateTimeOffset.MaxValue}).Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property() { new DateTranscriptMeeting(new {Number = int.MaxValue}).Number.Should().Be(int.MaxValue); }

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
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DateTranscriptMeeting(DateTimeOffset?, int?, IEnumerable{string}?, IEnumerable{ITranscriptVote}?)"/>
  /// <seealso cref="DateTranscriptMeeting(DateTranscriptMeeting.Info)"/>
  /// <seealso cref="DateTranscriptMeeting(object)"/>
  [Fact]
  public void Constructors()
  {
    var meeting = new DateTranscriptMeeting();
    meeting.Date.Should().BeNull();
    meeting.Number.Should().BeNull();
    meeting.Lines.Should().BeEmpty();
    meeting.Votes.Should().BeEmpty();

    meeting = new DateTranscriptMeeting(new DateTranscriptMeeting.Info());
    meeting.Date.Should().BeNull();
    meeting.Number.Should().BeNull();
    meeting.Lines.Should().BeEmpty();
    meeting.Votes.Should().BeEmpty();

    meeting = new DateTranscriptMeeting(new {});
    meeting.Date.Should().BeNull();
    meeting.Number.Should().BeNull();
    meeting.Lines.Should().BeEmpty();
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
  public void ToString_Method() { new DateTranscriptMeeting(new {Lines = new List<string> {"first", "second"}}).ToString().Should().Be($"first{Environment.NewLine}second"); }
}

/// <summary>
///   <para>Tests set for class <see cref="DateTranscriptMeeting.Info"/>.</para>
/// </summary>
public sealed class DateTranscriptMeetingInfoTests : UnitTest<DateTranscriptMeeting.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Info.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new DateTranscriptMeeting.Info {Date = DateTimeOffset.MaxValue}.Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Info.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property() { new DateTranscriptMeeting.Info {Number = int.MaxValue}.Number.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Info.Lines"/> property.</para>
  /// </summary>
  [Fact]
  public void Lines_Property()
  {
    var lines = new List<string>();
    new DateTranscriptMeeting.Info {Lines = lines}.Lines.Should().BeSameAs(lines);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Info.Votes"/> property.</para>
  /// </summary>
  [Fact]
  public void Votes_Property()
  {
    var votes = new List<TranscriptVote>();
    new DateTranscriptMeeting.Info {Votes = votes}.Votes.Should().BeSameAs(votes);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DateTranscriptMeeting.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new DateTranscriptMeeting.Info();
    info.Should().BeNull();
    info.Number.Should().BeNull();
    info.Lines.Should().BeNull();
    info.Votes.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Info.Result()"/> method.</para>
  /// </summary>
  [Fact]
  public void Result_Method()
  {
    var result = new DateTranscriptMeeting.Info().Result();
    result.Should().NotBeNull().And.BeOfType<DateTranscriptMeeting>();
    result.Date.Should().BeNull();
    result.Number.Should().BeNull();
    result.Lines.Should().BeEmpty();
    result.Votes.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new DateTranscriptMeeting.Info
    {
      Date = DateTimeOffset.MinValue,
      Lines = new List<string> {"line"},
      Number = 1,
      Votes = new List<TranscriptVote> {new(new {Date = DateTimeOffset.MinValue, Line = 2})}
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}