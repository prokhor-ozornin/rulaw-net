using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TranscriptMeetingQuestion"/>.</para>
  /// </summary>
  public sealed class TranscriptMeetingQuestionTests : UnitTestsBase<TranscriptMeetingQuestion>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new TranscriptMeetingQuestion(), new { parts = new object[] {} });
      this.TestJson(
        new TranscriptMeetingQuestion
        {
          Name = "name",
          PartsOriginal = new List<TranscriptMeetingQuestionPart> { new TranscriptMeetingQuestionPart() },
          Stage = "stage"
        },
        new { name = "name", parts = new object[] { new { endLine = 0, lines = new object[] { }, startLine = 0, votes = new object[] { } } }, stage = "stage" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(
        new TranscriptMeetingQuestion
        {
          Name = "name",
          PartsOriginal = new List<TranscriptMeetingQuestionPart> { new TranscriptMeetingQuestionPart() },
          Stage = "stage"
        },
        "question",
        new { name = "name", stage = "stage" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="TranscriptMeetingQuestion()"/>
    [Fact]
    public void Constructors()
    {
      var transcript = new TranscriptMeetingQuestion();
      Assert.Null(transcript.Name);
      Assert.False(transcript.PartsOriginal.Any());
      Assert.False(transcript.Parts.Any());
      Assert.Null(transcript.Stage);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new TranscriptMeetingQuestion { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Parts"/> property.</para>
    /// </summary>
    [Fact]
    public void Parts_Property()
    {
      var question = new TranscriptMeetingQuestion();
      var part = new TranscriptMeetingQuestionPart();

      question.PartsOriginal.Add(part);
      Assert.True(ReferenceEquals(question.PartsOriginal.Single(), part));
      Assert.True(ReferenceEquals(question.Parts.Single(), part));

      question.PartsOriginal.Remove(part);
      Assert.False(question.PartsOriginal.Any());
      Assert.False(question.Parts.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Stage"/> property.</para>
    /// </summary>
    [Fact]
    public void Stage_Property()
    {
      Assert.Equal("stage", new TranscriptMeetingQuestion { Stage = "stage" }.Stage);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.CompareTo(ITranscriptMeetingQuestion)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="TranscriptMeetingQuestion.Equals(ITranscriptMeetingQuestion)"/></description></item>
    ///     <item><description><see cref="TranscriptMeetingQuestion.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Name", "first", "second");
      this.TestEquality("Stage", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Name", "first", "second");
      this.TestHashCode("Stage", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new TranscriptMeetingQuestion { Name = "name" }.ToString());
    }
  }
}