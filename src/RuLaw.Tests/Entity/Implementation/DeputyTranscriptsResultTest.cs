using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyTranscriptsResult"/>.</para>
/// </summary>
public sealed class DeputyTranscriptsResultTest : EntityTest<DeputyTranscriptsResult>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new DeputyTranscriptsResult(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property() { new DeputyTranscriptsResult(new {Page = int.MaxValue}).Page.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.PageSize"/> property.</para>
  /// </summary>
  [Fact]
  public void PageSize_Property() { new DeputyTranscriptsResult(new {PageSize = int.MaxValue}).PageSize.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property() { new DeputyTranscriptsResult(new {Count = int.MaxValue}).Count.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var transcript = new DeputyTranscriptsResult(new {});
    var meeting = new TranscriptMeeting(new {});

    var meetings = transcript.Meetings.To<List<TranscriptMeeting>>();

    meetings.Add(meeting);
    transcript.Meetings.Should().ContainSingle().Which.Should().BeSameAs(meeting);

    meetings.Remove(meeting);
    transcript.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyTranscriptsResult(string?, int?, int?, int?, IEnumerable{ITranscriptMeeting}?)"/>
  /// <seealso cref="DeputyTranscriptsResult(DeputyTranscriptsResult.Info)"/>
  /// <seealso cref="DeputyTranscriptsResult(object)"/>
  [Fact]
  public void Constructors()
  {
    var transcript = new DeputyTranscriptsResult();
    transcript.Name.Should().BeNull();
    transcript.Page.Should().BeNull();
    transcript.PageSize.Should().BeNull();
    transcript.Count.Should().BeNull();
    transcript.Meetings.Should().BeEmpty();

    transcript = new DeputyTranscriptsResult(new DeputyTranscriptsResult.Info());
    transcript.Name.Should().BeNull();
    transcript.Page.Should().BeNull();
    transcript.PageSize.Should().BeNull();
    transcript.Count.Should().BeNull();
    transcript.Meetings.Should().BeEmpty();

    transcript = new DeputyTranscriptsResult(new {});
    transcript.Name.Should().BeNull();
    transcript.Page.Should().BeNull();
    transcript.PageSize.Should().BeNull();
    transcript.Count.Should().BeNull();
    transcript.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.CompareTo(IDeputyTranscriptsResult)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(DeputyTranscriptsResult.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new DeputyTranscriptsResult(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="DeputyTranscriptsResult.Info"/>.</para>
/// </summary>
public sealed class DeputyTranscriptsResultInfoTests : EntityTest<DeputyTranscriptsResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new DeputyTranscriptsResult.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Info.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property() { new DeputyTranscriptsResult.Info {Page = int.MaxValue}.Page.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Info.PageSize"/> property.</para>
  /// </summary>
  [Fact]
  public void PageSize_Property() { new DeputyTranscriptsResult.Info {PageSize = int.MaxValue}.PageSize.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Info.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property() { new DeputyTranscriptsResult.Info {Count = int.MaxValue}.Count.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Info.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var meetings = new List<TranscriptMeeting>();
    new DeputyTranscriptsResult.Info {Meetings = meetings}.Meetings.Should().BeSameAs(meetings);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyTranscriptsResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new DeputyTranscriptsResult.Info();
    info.Name.Should().BeNull();
    info.Page.Should().BeNull();
    info.PageSize.Should().BeNull();
    info.Count.Should().BeNull();
    info.Meetings.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new DeputyTranscriptsResult.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<DeputyTranscriptsResult>();
    result.Name.Should().BeNull();
    result.Page.Should().BeNull();
    result.PageSize.Should().BeNull();
    result.Count.Should().BeNull();
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new DeputyTranscriptsResult.Info();
    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}