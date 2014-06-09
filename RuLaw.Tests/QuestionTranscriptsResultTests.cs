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
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Meetings");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="QuestionTranscriptsResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new QuestionTranscriptsResult();
      Assert.False(result.Meetings.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionTranscriptsResult.Meetings"/> property.</para>
    /// </summary>
    [Fact]
    public void Meetings_Property()
    {
      var result = new QuestionTranscriptsResult();
      Assert.False(result.Meetings.Any());
      var meeting = new TranscriptMeeting();
      result.Meetings.Add(meeting);
      Assert.True(ReferenceEquals(meeting, result.Meetings.Single()));
      result.Meetings.Remove(meeting);
      Assert.False(result.Meetings.Any());
    }
  }
}