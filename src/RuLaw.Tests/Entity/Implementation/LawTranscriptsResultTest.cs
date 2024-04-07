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
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawTranscriptsResult(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property() { new LawTranscriptsResult(new {Number = Guid.Empty.ToString()}).Number.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Comments"/> property.</para>
  /// </summary>
  [Fact]
  public void Comments_Property() { new LawTranscriptsResult(new {Comments = Guid.Empty.ToString()}).Comments.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var transcript = new LawTranscriptsResult(new {});
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
  /// <seealso cref="LawTranscriptsResult(string?, string?, string?, IEnumerable{ITranscriptMeeting}?)"/>
  /// <seealso cref="LawTranscriptsResult(LawTranscriptsResult.Info)"/>
  /// <seealso cref="LawTranscriptsResult(object)"/>
  [Fact]
  public void Constructors()
  {
    var transcript = new LawTranscriptsResult();
    transcript.Name.Should().BeNull();
    transcript.Number.Should().BeNull();
    transcript.Comments.Should().BeNull();
    transcript.Meetings.Should().BeEmpty();

    transcript = new LawTranscriptsResult(new LawTranscriptsResult.Info());
    transcript.Name.Should().BeNull();
    transcript.Number.Should().BeNull();
    transcript.Comments.Should().BeNull();
    transcript.Meetings.Should().BeEmpty();

    transcript = new LawTranscriptsResult(new {});
    transcript.Name.Should().BeNull();
    transcript.Number.Should().BeNull();
    transcript.Comments.Should().BeNull();
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
    new LawTranscriptsResult(new {Number = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="LawTranscriptsResult.Info"/>.</para>
/// </summary>
public sealed class LawTranscriptsResultInfoTests : ClassTest<LawTranscriptsResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawTranscriptsResult.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Info.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property() { new LawTranscriptsResult.Info {Number = Guid.Empty.ToString()}.Number.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Info.Comments"/> property.</para>
  /// </summary>
  [Fact]
  public void Comments_Property() { new LawTranscriptsResult.Info {Comments = Guid.Empty.ToString()}.Comments.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Info.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var meetings = new List<TranscriptMeeting>();
    new LawTranscriptsResult.Info {Meetings = meetings}.Meetings.Should().BeSameAs(meetings);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawTranscriptsResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new LawTranscriptsResult.Info();
    info.Name.Should().BeNull();
    info.Number.Should().BeNull();
    info.Comments.Should().BeNull();
    info.Meetings.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawTranscriptsResult.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new LawTranscriptsResult.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<LawTranscriptsResult>();
      result.Name.Should().BeNull();
      result.Number.Should().BeNull();
      result.Comments.Should().BeNull();
      result.Meetings.Should().BeEmpty();
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
      Validate(new LawTranscriptsResult.Info
      {
        Name = "name",
        Number = "number",
        Comments = "comments",
        Meetings = new List<TranscriptMeeting> { new(new { }) }
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}