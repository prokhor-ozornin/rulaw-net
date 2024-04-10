using System.Runtime.Serialization;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TranscriptMeetingQuestionPart"/>.</para>
/// </summary>
public sealed class TranscriptMeetingQuestionPartTest : ClassTest<TranscriptMeetingQuestionPart>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.StartLine"/> property.</para>
  /// </summary>
  [Fact]
  public void StartLine_Property() { new TranscriptMeetingQuestionPart(new {StartLine = int.MaxValue}).StartLine.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.EndLine"/> property.</para>
  /// </summary>
  [Fact]
  public void EndLine_Property() { new TranscriptMeetingQuestionPart(new {EndLine = int.MaxValue}).EndLine.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Lines"/> property.</para>
  /// </summary>
  [Fact]
  public void Lines_Property()
  {
    var part = new TranscriptMeetingQuestionPart(new {});

    var lines = part.Lines.To<List<string>>();

    lines.Add("line");
    part.Lines.Should().ContainSingle().Which.Should().Be("line");

    lines.Remove("line");
    part.Lines.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Votes"/> property.</para>
  /// </summary>
  [Fact]
  public void Votes_Property()
  {
    var part = new TranscriptMeetingQuestionPart(new {});

    var vote = new TranscriptVote(new {});

    var votes = part.Votes.To<List<TranscriptVote>>();

    votes.Add(vote);
    part.Votes.Should().ContainSingle().Which.Should().BeSameAs(vote);

    votes.Remove(vote);
    part.Votes.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Education(string?, short?)"/>
  /// <seealso cref="Education(Education.Info)"/>
  /// <seealso cref="Education(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(Education).Should().BeDerivedFrom<object>().And.Implement<IEducation>();

    var part = new TranscriptMeetingQuestionPart();
    part.StartLine.Should().BeNull();
    part.EndLine.Should().BeNull();
    part.Lines.Should().BeEmpty();
    part.Votes.Should().BeEmpty();

    part = new TranscriptMeetingQuestionPart(new TranscriptMeetingQuestionPart.Info());
    part.StartLine.Should().BeNull();
    part.EndLine.Should().BeNull();
    part.Lines.Should().BeEmpty();
    part.Votes.Should().BeEmpty();

    part = new TranscriptMeetingQuestionPart(new {});
    part.StartLine.Should().BeNull();
    part.EndLine.Should().BeNull();
    part.Lines.Should().BeEmpty();
    part.Votes.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.CompareTo(ITranscriptMeetingQuestionPart)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo("StartLine", 1, 2); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TranscriptMeetingQuestionPart.Equals(ITranscriptMeetingQuestionPart)"/></description></item>
  ///     <item><description><see cref="TranscriptMeetingQuestionPart.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(TranscriptMeetingQuestionPart.StartLine), 1, 2);
    TestEquality(nameof(TranscriptMeetingQuestionPart.EndLine), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(TranscriptMeetingQuestionPart.StartLine), 1, 2);
    TestHashCode(nameof(TranscriptMeetingQuestionPart.EndLine), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new TranscriptMeetingQuestionPart(new {Lines = new List<string> {"first", "second"}}).ToString().Should().Be($"first{Environment.NewLine}second");
  }
}

/// <summary>
///   <para>Tests set for class <see cref="TranscriptMeetingQuestionPart.Info"/>.</para>
/// </summary>
public sealed class TranscriptMeetingQuestionPartInfoTests : ClassTest<TranscriptMeetingQuestionPart.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Info.StartLine"/> property.</para>
  /// </summary>
  [Fact]
  public void StartLine_Property() { new TranscriptMeetingQuestionPart.Info {StartLine = int.MaxValue}.StartLine.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Info.EndLine"/> property.</para>
  /// </summary>
  [Fact]
  public void EndLine_Property() { new TranscriptMeetingQuestionPart.Info {EndLine = int.MaxValue}.EndLine.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Info.Lines"/> property.</para>
  /// </summary>
  [Fact]
  public void Lines_Property()
  {
    var lines = new List<string>();
    new TranscriptMeetingQuestionPart.Info {Lines = lines}.Lines.Should().BeSameAs(lines);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Info.Votes"/> property.</para>
  /// </summary>
  [Fact]
  public void Votes_Property()
  {
    var votes = new List<TranscriptVote>();
    new TranscriptMeetingQuestionPart.Info {Votes = votes}.Votes.Should().BeSameAs(votes);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Education.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Education.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IEducation>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new Education.Info();
    info.Institution.Should().BeNull();
    info.Year.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new TranscriptMeetingQuestionPart.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<TranscriptMeetingQuestionPart>();
      result.StartLine.Should().BeNull();
      result.EndLine.Should().BeNull();
      result.Lines.Should().BeEmpty();
      result.Votes.Should().BeEmpty();
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new TranscriptMeetingQuestionPart.Info
      {
        EndLine = 2,
        Lines = ["line"],
        StartLine = 1,
        Votes = [new TranscriptVote(new { Date = DateTimeOffset.MinValue, Line = 3 })]
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}