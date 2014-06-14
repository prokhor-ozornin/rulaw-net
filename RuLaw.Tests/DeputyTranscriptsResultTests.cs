using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyTranscriptsResult"/>.</para>
  /// </summary>
  public sealed class DeputyTranscriptsResultTests : UnitTestsBase<DeputyTranscriptsResult>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new DeputyTranscriptsResult(), new { meetings = new object[] {}, page = 0, pageSize = 0, totalCount = 0 });
      this.TestJson(
        new DeputyTranscriptsResult
        {
          Meetings = new List<TranscriptMeeting> { new TranscriptMeeting() },
          Name = "name",
          Page = 1,
          PageSize = 2,
          Count = 3
        },
        new { meetings = new object[] { new { date = default(DateTime), maxNumber = 0, number = 0, questions = new object[] {} } }, name = "name", page = 1, pageSize = 2, totalCount = 3 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new DeputyTranscriptsResult(), "result", new { page = 0, pageSize = 0, totalCount = 0 });
      this.TestXml(
        new DeputyTranscriptsResult
        {
          Meetings = new List<TranscriptMeeting> { new TranscriptMeeting() },
          Name = "name",
          Page = 1,
          PageSize = 2,
          Count = 3
        },
        "result",
        new { name = "name", page = 1, pageSize = 2, totalCount = 3 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputyTranscriptsResult()"/>
    [Fact]
    public void Constructors()
    {
      var transcript = new DeputyTranscriptsResult();
      Assert.Equal(0, transcript.Count);
      Assert.False(transcript.Meetings.Any());
      Assert.Null(transcript.Name);
      Assert.Equal(0, transcript.Page);
      Assert.Equal(0, transcript.PageSize);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Count"/> property.</para>
    /// </summary>
    [Fact]
    public void Count_Property()
    {
      Assert.Equal(1, new DeputyTranscriptsResult { Count = 1 }.Count);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Meetings"/> property.</para>
    /// </summary>
    [Fact]
    public void Meetings_Property()
    {
      var transcript = new DeputyTranscriptsResult();
      var meeting = new TranscriptMeeting();

      transcript.Meetings.Add(meeting);
      Assert.True(ReferenceEquals(transcript.Meetings.Single(), meeting));

      transcript.Meetings.Remove(meeting);
      Assert.False(transcript.Meetings.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new DeputyTranscriptsResult { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Page"/> property.</para>
    /// </summary>
    [Fact]
    public void Page_Property()
    {
      Assert.Equal(1, new DeputyTranscriptsResult { Page = 1 }.Page);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.PageSize"/> property.</para>
    /// </summary>
    [Fact]
    public void PageSize_Property()
    {
      Assert.Equal(1, new DeputyTranscriptsResult { PageSize = 1 }.PageSize);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.CompareTo(DeputyTranscriptsResult)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new DeputyTranscriptsResult { Name = "name" }.ToString());
    }
  }
}