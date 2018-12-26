using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TranscriptVote"/>.</para>
  /// </summary>
  public sealed class TranscriptVoteTests : UnitTestsBase<TranscriptVote>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new TranscriptVote(), new { date = default(DateTime), line = 0 });
      TestJson(
        new TranscriptVote
        {
          Date = DateTime.MinValue,
          Line = 1
        },
        new { date = DateTime.MinValue, line = 1 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      TestXml(new TranscriptVote(), "vote", new { date = default(DateTime).ISO8601(), line = 0 });
      TestXml(
        new TranscriptVote
        {
          Date = DateTime.MinValue,
          Line = 1
        },
        "vote",
        new { date = DateTime.MinValue.ISO8601(), line = 1 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="TranscriptVote()"/>
    [Fact]
    public void Constructors()
    {
      var vote = new TranscriptVote();
      Assert.Equal(default(DateTime), vote.Date);
      Assert.Equal(0, vote.Line);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptVote.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new TranscriptVote { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptVote.Line"/> property.</para>
    /// </summary>
    [Fact]
    public void Line_Property()
    {
      Assert.Equal(1, new TranscriptVote { Line = 1 }.Line);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptVote.CompareTo(ITranscriptVote)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="TranscriptVote.Equals(ITranscriptVote)"/></description></item>
    ///     <item><description><see cref="TranscriptVote.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      TestEquality("Date", DateTime.MinValue, DateTime.MaxValue);
      TestEquality("Line", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptVote.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      TestHashCode("Date", DateTime.MinValue, DateTime.MaxValue);
      TestHashCode("Line", 1, 2);
    }
  }
}