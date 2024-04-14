using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawTranscriptsResult"/>.</para>
/// </summary>
public sealed class LawTranscriptsResultTest : ClassTest<LawTranscriptsResult>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawTranscriptsResult()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawTranscriptsResult).Should().BeDerivedFrom<object>().And.Implement<ILawTranscriptsResult>();

    var transcript = new LawTranscriptsResult();
    transcript.Name.Should().BeNull();
    transcript.Number.Should().BeNull();
    transcript.Comments.Should().BeNull();
    transcript.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new LawTranscriptsResult { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property()
  {
    new LawTranscriptsResult { Number = Guid.Empty.ToString() }.Number.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Comments"/> property.</para>
  /// </summary>
  [Fact]
  public void Comments_Property()
  {
    new LawTranscriptsResult { Comments = Guid.Empty.ToString() }.Comments.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var transcript = new LawTranscriptsResult();
    var meeting = new TranscriptMeeting();

    var meetings = transcript.Meetings.To<List<TranscriptMeeting>>();
    meetings.Add(meeting);
    transcript.Meetings.Should().ContainSingle().Which.Should().BeSameAs(meeting);

    meetings.Remove(meeting);
    transcript.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.CompareTo(ILawTranscriptsResult)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawTranscriptsResult.Number), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="LawTranscriptsResult.Equals(ILawTranscriptsResult)"/></description></item>
  ///     <item><description><see cref="LawTranscriptsResult.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(LawTranscriptsResult.Number), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(LawTranscriptsResult.Number), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new LawTranscriptsResult {Number = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new LawTranscriptsResult
      {
        Name = "name",
        Number = "number",
        Comments = "comments",
        Meetings = [new TranscriptMeeting()]
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}