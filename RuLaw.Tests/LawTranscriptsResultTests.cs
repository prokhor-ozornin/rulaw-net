using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawTranscriptsResult"/>.</para>
  /// </summary>
  public sealed class LawTranscriptsResultTests : UnitTestsBase<LawTranscriptsResult>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Comments", "Meetings", "Name", "Number");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new LawTranscriptsResult(), new { meetings = new object[] { } });
      this.TestJson(
        new LawTranscriptsResult
        {
          Comments = "comments",
          Meetings = new List<TranscriptMeeting> { new TranscriptMeeting() },
          Name = "name",
          Number = "number"
        },
        new { comments = "comments", meetings = new object[] { new { date = DateTime.MinValue, maxNumber = 0, number = 0, questions = new object[] { } } }, name = "name", number = "number" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(
        new LawTranscriptsResult
        {
          Comments = "comments",
          Meetings = new List<TranscriptMeeting> { new TranscriptMeeting() },
          Name = "name",
          Number = "number"
        },
        "result",
        new { comments = "comments", name = "name", number = "number" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawTranscriptsResult()"/>
    [Fact]
    public void Constructors()
    {
      var transcript = new LawTranscriptsResult();
      Assert.Null(transcript.Comments);
      Assert.False(transcript.Meetings.Any());
      Assert.Null(transcript.Name);
      Assert.Null(transcript.Number);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawTranscriptsResult.Comments"/> property.</para>
    /// </summary>
    [Fact]
    public void Comments_Property()
    {
      Assert.Equal("comments", new LawTranscriptsResult { Comments = "comments" }.Comments);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawTranscriptsResult.Meetings"/> property.</para>
    /// </summary>
    [Fact]
    public void Meetings_Property()
    {
      var transcript = new LawTranscriptsResult();
      var meeting = new TranscriptMeeting();
 
      transcript.Meetings.Add(meeting);
      Assert.True(ReferenceEquals(transcript.Meetings.Single(), meeting));
      
      transcript.Meetings.Remove(meeting);
      Assert.False(transcript.Meetings.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawTranscriptsResult.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new LawTranscriptsResult { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawTranscriptsResult.Number"/> property.</para>
    /// </summary>
    [Fact]
    public void Number_Property()
    {
      Assert.Equal("number", new LawTranscriptsResult { Number = "number" }.Number);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawTranscriptsResult.CompareTo(LawTranscriptsResult)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Number", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="LawTranscriptsResult.Equals(LawTranscriptsResult)"/></description></item>
    ///     <item><description><see cref="LawTranscriptsResult.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Number", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawTranscriptsResult.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Number", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawTranscriptsResult.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("number", new LawTranscriptsResult { Number = "number" }.ToString());
    }
  }
}