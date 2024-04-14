using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TranscriptMeetingQuestion"/>.</para>
/// </summary>
public sealed class TranscriptMeetingQuestionTest : ClassTest<TranscriptMeetingQuestion>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="TranscriptMeetingQuestion()"/>
  [Fact]
  public void Constructors()
  {
    typeof(TranscriptMeetingQuestion).Should().BeDerivedFrom<object>().And.Implement<ITranscriptMeetingQuestion>();

    var question = new TranscriptMeetingQuestion();
    question.Name.Should().BeNull();
    question.Stage.Should().BeNull();
    question.Parts.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new TranscriptMeetingQuestion { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Stage"/> property.</para>
  /// </summary>
  [Fact]
  public void Stage_Property()
  {
    new TranscriptMeetingQuestion { Stage = Guid.Empty.ToString() }.Stage.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Parts"/> property.</para>
  /// </summary>
  [Fact]
  public void Parts_Property()
  {
    var question = new TranscriptMeetingQuestion();

    var part = new TranscriptMeetingQuestionPart();
    var parts = question.Parts.To<List<TranscriptMeetingQuestionPart>>();

    parts.Add(part);
    question.Parts.Should().ContainSingle().Which.Should().BeSameAs(part);

    parts.Remove(part);
    question.Parts.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.CompareTo(ITranscriptMeetingQuestion)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(TranscriptMeetingQuestion.Name), "first", "second"); }

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
    TestEquality(nameof(TranscriptMeetingQuestion.Name), "first", "second");
    TestEquality(nameof(TranscriptMeetingQuestion.Stage), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(TranscriptMeetingQuestion.Name), "first", "second");
    TestHashCode(nameof(TranscriptMeetingQuestion.Stage), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new TranscriptMeetingQuestion {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new TranscriptMeetingQuestion
      {
        Name = "name",
        Parts = [new TranscriptMeetingQuestionPart()],
        Stage = "stage"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}