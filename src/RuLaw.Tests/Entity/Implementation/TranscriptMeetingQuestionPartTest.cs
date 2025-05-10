using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TranscriptMeetingQuestionPart"/>.</para>
/// </summary>
public sealed class TranscriptMeetingQuestionPartTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Education()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Education).Should().BeDerivedFrom<object>().And.Implement<IEducation>();

    using (new AssertionScope())
    {
      var part = new TranscriptMeetingQuestionPart();

      part.StartLine.Should().BeNull();
      part.EndLine.Should().BeNull();
      part.Lines.Should().BeEmpty();
      part.Votes.Should().BeEmpty();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.StartLine"/> property.</para>
  /// </summary>
  [Fact]
  public void StartLine_Property()
  {
    new TranscriptMeetingQuestionPart { StartLine = int.MaxValue }.StartLine.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.EndLine"/> property.</para>
  /// </summary>
  [Fact]
  public void EndLine_Property()
  {
    new TranscriptMeetingQuestionPart { EndLine = int.MaxValue }.EndLine.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Lines"/> property.</para>
  /// </summary>
  [Fact]
  public void Lines_Property()
  {
    var part = new TranscriptMeetingQuestionPart();

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
    var part = new TranscriptMeetingQuestionPart();

    var vote = new TranscriptVote();

    var votes = part.Votes.To<List<TranscriptVote>>();

    votes.Add(vote);
    part.Votes.Should().ContainSingle().Which.Should().BeSameAs(vote);

    votes.Remove(vote);
    part.Votes.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.CompareTo(ITranscriptMeetingQuestionPart)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo<TranscriptMeetingQuestionPart, int>("StartLine", 1, 2); 
  }

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
    TestEquality<TranscriptMeetingQuestionPart, int>(nameof(TranscriptMeetingQuestionPart.StartLine), 1, 2);
    TestEquality<TranscriptMeetingQuestionPart, int>(nameof(TranscriptMeetingQuestionPart.EndLine), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode<TranscriptMeetingQuestionPart, int>(nameof(TranscriptMeetingQuestionPart.StartLine), 1, 2);
    TestHashCode<TranscriptMeetingQuestionPart, int>(nameof(TranscriptMeetingQuestionPart.EndLine), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new TranscriptMeetingQuestionPart {Lines = new List<string> {"first", "second"}}.ToString().Should().Be($"first{Environment.NewLine}second");
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Test(new TranscriptMeetingQuestionPart
      {
        EndLine = 2,
        Lines = ["line"],
        StartLine = 1,
        Votes = [new TranscriptVote { Date = DateTimeOffset.MinValue, Line = 3 }]
      });
    }

    return;

    static void Test(ITranscriptMeetingQuestionPart instance) => instance.To<object>().Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}