using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DateTranscriptMeeting"/>.</para>
  /// </summary>
  public sealed class DateTranscriptMeetingTests : UnitTestsBase<DateTranscriptMeeting>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new DateTranscriptMeeting(), new { date = default(DateTime), lines = new object[] {}, number = 0, votes = new object[] {} });
      this.TestJson(
        new DateTranscriptMeeting
        {
          Date = DateTime.MinValue,
          Lines = new List<string> { "line" },
          Number = 1,
          Votes = new List<TranscriptVote> { new TranscriptVote { Date = DateTime.MinValue, Line = 2 } }
        },
        new { date = DateTime.MinValue, lines = new object[] { "line" }, number = 1, votes = new object[] { new { date = DateTime.MinValue, line = 2 } } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new DateTranscriptMeeting(), "meeting", new { date = default(DateTime).ISO8601(), number = 0 });
      this.TestXml(new DateTranscriptMeeting
        {
          Date = DateTime.MinValue,
          Lines = new List<string> { "line" },
          Number = 1,
          Votes = new List<TranscriptVote> { new TranscriptVote { Date = DateTime.MinValue, Line = 2 } }
        },
        "meeting",
        new { date = DateTime.MinValue.ISO8601(), line = "line", number = 1 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DateTranscriptMeeting()"/>
    [Fact]
    public void Constructors()
    {
      var meeting = new DateTranscriptMeeting();
      Assert.Equal(default(DateTime), meeting.Date);
      Assert.False(meeting.Lines.Any());
      Assert.Equal(0, meeting.Number);
      Assert.Equal(string.Empty, meeting.Text);
      Assert.False(meeting.Votes.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new DateTranscriptMeeting { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Number"/> property.</para>
    /// </summary>
    [Fact]
    public void Number_Property()
    {
      Assert.Equal(1, new DateTranscriptMeeting { Number = 1 }.Number);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Lines"/> property.</para>
    /// </summary>
    [Fact]
    public void Lines_Property()
    {
      var meeting = new DateTranscriptMeeting();
      Assert.False(meeting.Lines.Any());
      meeting.Lines.Add("line");
      Assert.Equal("line", meeting.Lines.Single());
      meeting.Lines.Remove("line");
      Assert.False(meeting.Lines.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Text"/> property.</para>
    /// </summary>
    [Fact]
    public void Text_Property()
    {
      Assert.Equal("first{0}second".FormatSelf(Environment.NewLine), new DateTranscriptMeeting { Lines = new List<string> { "first", "second" } }.Text);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptMeeting.Votes"/> property.</para>
    /// </summary>
    [Fact]
    public void Votes_Property()
    {
      var meeting = new DateTranscriptMeeting();
      Assert.False(meeting.Votes.Any());
      var vote = new TranscriptVote();
      meeting.Votes.Add(vote);
      Assert.True(ReferenceEquals(vote, meeting.Votes.Single()));
      meeting.Votes.Remove(vote);
      Assert.False(meeting.Votes.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptMeeting.CompareTo(DateTranscriptMeeting)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DateTranscriptMeeting.Equals(DateTranscriptMeeting)"/></description></item>
    ///     <item><description><see cref="DateTranscriptMeeting.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptMeeting.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptMeeting.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("first{0}second".FormatSelf(Environment.NewLine), new DateTranscriptMeeting { Lines = new List<string> { "first", "second" } }.ToString());
    }
  }
}