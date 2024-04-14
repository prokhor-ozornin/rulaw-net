using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ResolutionTranscriptsResult"/>.</para>
/// </summary>
public sealed class ResolutionTranscriptsResultTest : ClassTest<ResolutionTranscriptsResult>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ResolutionTranscriptsResult()"/>
  [Fact]
  public void Constructors()
  {
    typeof(ResolutionTranscriptsResult).Should().BeDerivedFrom<object>().And.Implement<IResolutionTranscriptsResult>();

    var result = new ResolutionTranscriptsResult();
    result.Number.Should().BeNull();
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property()
  {
    new ResolutionTranscriptsResult { Number = Guid.Empty.ToString() }.Number.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var result = new ResolutionTranscriptsResult();
    result.Meetings.Should().BeEmpty();
    var meeting = new TranscriptMeeting();

    var meetings = result.Meetings.To<List<TranscriptMeeting>>();
    meetings.Add(meeting);
    result.Meetings.Should().ContainSingle().Which.Should().BeSameAs(meeting);

    meetings.Remove(meeting);
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ResolutionTranscriptsResult.Equals(IResolutionTranscriptsResult)"/></description></item>
  ///     <item><description><see cref="ResolutionTranscriptsResult.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(ResolutionTranscriptsResult.Number), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(ResolutionTranscriptsResult.Number), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new ResolutionTranscriptsResult {Number = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of JSON serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new ResolutionTranscriptsResult
    {
      Meetings = [new TranscriptMeeting()],
      Number = "number"
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}