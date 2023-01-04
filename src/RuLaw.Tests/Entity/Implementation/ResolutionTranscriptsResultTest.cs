﻿using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ResolutionTranscriptsResult"/>.</para>
/// </summary>
public sealed class ResolutionTranscriptsResultTest : UnitTest<ResolutionTranscriptsResult>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property() { new ResolutionTranscriptsResult(new {Number = Guid.Empty.ToString()}).Number.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var result = new ResolutionTranscriptsResult(new {});
    result.Meetings.Should().BeEmpty();
    var meeting = new TranscriptMeeting(new {});

    var meetings = result.Meetings.To<List<TranscriptMeeting>>();
    meetings.Add(meeting);
    result.Meetings.Should().ContainSingle().Which.Should().BeSameAs(meeting);

    meetings.Remove(meeting);
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ResolutionTranscriptsResult(string?, IEnumerable{ITranscriptMeeting}?)"/>
  /// <seealso cref="ResolutionTranscriptsResult(ResolutionTranscriptsResult.Info)"/>
  /// <seealso cref="ResolutionTranscriptsResult(object)"/>
  [Fact]
  public void Constructors()
  {
    var result = new ResolutionTranscriptsResult();
    result.Number.Should().BeNull();
    result.Meetings.Should().BeEmpty();

    result = new ResolutionTranscriptsResult(new ResolutionTranscriptsResult.Info());
    result.Number.Should().BeNull();
    result.Meetings.Should().BeEmpty();

    result = new ResolutionTranscriptsResult(new {});
    result.Number.Should().BeNull();
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
  public void ToString_Method() { new ResolutionTranscriptsResult(new {Number = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="ResolutionTranscriptsResult.Info"/>.</para>
/// </summary>
public sealed class ResolutionTranscriptsResultInfoTests : UnitTest<ResolutionTranscriptsResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.Info.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property() { new ResolutionTranscriptsResult.Info {Number = Guid.Empty.ToString()}.Number.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.Info.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var meetings = new List<TranscriptMeeting>();
    new ResolutionTranscriptsResult.Info {Meetings = meetings}.Meetings.Should().BeSameAs(meetings);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ResolutionTranscriptsResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new ResolutionTranscriptsResult.Info();
    info.Number.Should().BeNull();
    info.Meetings.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new ResolutionTranscriptsResult.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<ResolutionTranscriptsResult>();
    result.Number.Should().BeNull();
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of JSON serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization_Json()
  {
    var info = new ResolutionTranscriptsResult.Info
    {
      Meetings = new List<TranscriptMeeting> {new(new {})},
      Number = "number"
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}