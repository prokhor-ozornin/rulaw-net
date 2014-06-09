using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DateTranscriptsResult"/>.</para>
  /// </summary>
  public sealed class DateTranscriptsResultTests : UnitTestsBase<DateTranscriptsResult>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Date", "Meetings");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new DateTranscriptsResult(), new { date = default(DateTime), meetings = new object[] {} });
      this.TestJson(
        new DateTranscriptsResult
        {
          Date = DateTime.MinValue,
          Meetings = new List<DateTranscriptMeeting> { new DateTranscriptMeeting() }
        },
        new { date = DateTime.MinValue, meetings = new object[] { new { date = DateTime.MinValue, lines = new object[] {}, number = 0, votes = new object[] {} } } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new DateTranscriptsResult(), "result", new { date = default(DateTime).ISO8601()  });
      this.TestXml(
        new DateTranscriptsResult
        {
          Date = DateTime.MinValue,
          Meetings = new List<DateTranscriptMeeting> { new DateTranscriptMeeting() }
        },
        "result",
        new { date = DateTime.MinValue.ISO8601() }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DateTranscriptsResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new DateTranscriptsResult();
      Assert.Equal(default(DateTime), result.Date);
      Assert.False(result.Meetings.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new DateTranscriptsResult { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.Meetings"/> property.</para>
    /// </summary>
    [Fact]
    public void Meetings_Property()
    {
      var result = new DateTranscriptsResult();
      var meeting = new DateTranscriptMeeting();

      result.Meetings.Add(meeting);
      Assert.True(ReferenceEquals(result.Meetings.Single(), meeting));

      result.Meetings.Remove(meeting);
      Assert.False(result.Meetings.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.CompareTo(DateTranscriptsResult)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DateTranscriptsResult.Equals(DateTranscriptsResult)"/></description></item>
    ///     <item><description><see cref="DateTranscriptsResult.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal(DateTime.MinValue.RuLawDate(), new DateTranscriptsResult { Date = DateTime.MinValue }.ToString());
    }
  }
}