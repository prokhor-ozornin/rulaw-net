using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TranscriptMeetingQuestion"/>.</para>
/// </summary>
public sealed class TranscriptMeetingQuestionTest : UnitTest<TranscriptMeetingQuestion>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new TranscriptMeetingQuestion(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Stage"/> property.</para>
  /// </summary>
  [Fact]
  public void Stage_Property() { new TranscriptMeetingQuestion(new {Stage = Guid.Empty.ToString()}).Stage.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Parts"/> property.</para>
  /// </summary>
  [Fact]
  public void Parts_Property()
  {
    var question = new TranscriptMeetingQuestion(new {});

    var part = new TranscriptMeetingQuestionPart(new {});
    var parts = question.Parts.To<List<TranscriptMeetingQuestionPart>>();

    parts.Add(part);
    question.Parts.Should().ContainSingle().Which.Should().BeSameAs(part);

    parts.Remove(part);
    question.Parts.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="TranscriptMeetingQuestion(string?, string?, IEnumerable{ITranscriptMeetingQuestionPart}?)"/>
  /// <seealso cref="TranscriptMeetingQuestion(TranscriptMeetingQuestion.Info)"/>
  /// <seealso cref="TranscriptMeetingQuestion(object)"/>
  [Fact]
  public void Constructors()
  {
    var question = new TranscriptMeetingQuestion();
    question.Name.Should().BeNull();
    question.Stage.Should().BeNull();
    question.Parts.Should().BeEmpty();

    question = new TranscriptMeetingQuestion(new TranscriptMeetingQuestion.Info());
    question.Name.Should().BeNull();
    question.Stage.Should().BeNull();
    question.Parts.Should().BeEmpty();

    question = new TranscriptMeetingQuestion(new {});
    question.Name.Should().BeNull();
    question.Stage.Should().BeNull();
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
  public void ToString_Method() { new TranscriptMeetingQuestion(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="TranscriptMeetingQuestion.Info"/>.</para>
/// </summary>
public sealed class TranscriptMeetingQuestionInfoTests : UnitTest<TranscriptMeetingQuestion.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new TranscriptMeetingQuestion.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Info.Stage"/> property.</para>
  /// </summary>
  [Fact]
  public void Stage_Property() { new TranscriptMeetingQuestion.Info {Stage = Guid.Empty.ToString()}.Stage.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Info.Parts"/> property.</para>
  /// </summary>
  [Fact]
  public void Parts_Property()
  {
    var parts = new List<TranscriptMeetingQuestionPart>();
    new TranscriptMeetingQuestion.Info {Parts = parts}.Parts.Should().BeSameAs(parts);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="TranscriptMeetingQuestion.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new TranscriptMeetingQuestion.Info();
    info.Name.Should().BeNull();
    info.Stage.Should().BeNull();
    info.Parts.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestion.Info.Result()"/> method.</para>
  /// </summary>
  [Fact]
  public void Result_Method()
  {
    var result = new TranscriptMeetingQuestion.Info().Result();
    result.Should().NotBeNull().And.BeOfType<TranscriptMeetingQuestion>();
    result.Name.Should().BeNull();
    result.Stage.Should().BeNull();
    result.Parts.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new TranscriptMeetingQuestion.Info
    {
      Name = "name",
      Parts = new List<TranscriptMeetingQuestionPart> {new(new {})},
      Stage = "stage"
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}