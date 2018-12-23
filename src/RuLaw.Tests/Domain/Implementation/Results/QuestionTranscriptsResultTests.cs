using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="QuestionTranscriptsResult"/>.</para>
  /// </summary>
  public sealed class QuestionTranscriptsResultTests : UnitTestsBase<QuestionTranscriptsResult>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="QuestionTranscriptsResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new QuestionTranscriptsResult();
      Assert.Empty(result.MeetingsOriginal);
      Assert.Empty(result.Meetings);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionTranscriptsResult.Meetings"/> property.</para>
    /// </summary>
    [Fact]
    public void Meetings_Property()
    {
      var result = new QuestionTranscriptsResult();
      Assert.Empty(result.Meetings);
      var meeting = new TranscriptMeeting();
      result.MeetingsOriginal.Add(meeting);
      Assert.True(ReferenceEquals(meeting, result.MeetingsOriginal.Single()));
      Assert.True(ReferenceEquals(meeting, result.Meetings.Single()));
      result.MeetingsOriginal.Remove(meeting);
      Assert.Empty(result.MeetingsOriginal);
      Assert.Empty(result.Meetings);
    }
  }
}