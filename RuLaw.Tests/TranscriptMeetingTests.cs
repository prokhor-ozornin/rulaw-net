using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TranscriptMeeting"/>.</para>
  /// </summary>
  public sealed class TranscriptMeetingTests : UnitTestsBase<TranscriptMeeting>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new TranscriptMeeting(), new { date = default(DateTime), maxNumber = 0, number = 0, questions = new object[] { } });
      this.TestJson(
        new TranscriptMeeting
        {
          Date = DateTime.MinValue,
          LinesCount = 1,
          Number = 2,
          Questions = new List<TranscriptMeetingQuestion> { new TranscriptMeetingQuestion() }
        },
        new { date = DateTime.MinValue, maxNumber = 1, number = 2, questions = new object[] { new { parts = new object[] {} } } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new TranscriptMeeting(), "meeting", new { date = default(DateTime).ISO8601(), maxNumber = 0, number = 0 });
      this.TestXml(
        new TranscriptMeeting
        {
          Date = DateTime.MinValue,
          LinesCount = 1,
          Number = 2,
          Questions = new List<TranscriptMeetingQuestion> { new TranscriptMeetingQuestion() }
        },
        "meeting",
        new { date = DateTime.MinValue.ISO8601(), maxNumber = 1, number = 2 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="TranscriptMeeting()"/>
    [Fact]
    public void Constructors()
    {
      var meeting = new TranscriptMeeting();
      Assert.Equal(default(DateTime), meeting.Date);
      Assert.Equal(0, meeting.LinesCount);
      Assert.Equal(0, meeting.Number);
      Assert.False(meeting.Questions.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeeting.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new TranscriptMeeting { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeeting.LinesCount"/> property.</para>
    /// </summary>
    [Fact]
    public void LinesCount_Property()
    {
      Assert.Equal(1, new TranscriptMeeting { LinesCount = 1 }.LinesCount);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeeting.Number"/> property.</para>
    /// </summary>
    [Fact]
    public void Number_Property()
    {
      Assert.Equal(1, new TranscriptMeeting { Number = 1 }.Number);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeeting.Questions"/> property.</para>
    /// </summary>
    [Fact]
    public void Questions_Property()
    {
      var meeting = new TranscriptMeeting();
      var question = new TranscriptMeetingQuestion();

      meeting.Questions.Add(question);
      Assert.True(ReferenceEquals(meeting.Questions.Single(), question));

      meeting.Questions.Remove(question);
      Assert.False(meeting.Questions.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeeting.CompareTo(TranscriptMeeting)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="TranscriptMeeting.Equals(TranscriptMeeting)"/></description></item>
    ///     <item><description><see cref="TranscriptMeeting.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Date", DateTime.MinValue, DateTime.MaxValue);
      this.TestEquality("Number", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeeting.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Date", DateTime.MinValue, DateTime.MaxValue);
      this.TestHashCode("Number", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeeting.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal(DateTime.MinValue.ISO8601(), new TranscriptMeeting { Date = DateTime.MinValue }.ToString());
    }
  }
}