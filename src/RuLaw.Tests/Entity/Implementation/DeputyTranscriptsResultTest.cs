using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyTranscriptsResult"/>.</para>
/// </summary>
public sealed class DeputyTranscriptsResultTest : ClassTest<DeputyTranscriptsResult>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyTranscriptsResult()"/>
  [Fact]
  public void Constructors()
  {
    typeof(DeputyTranscriptsResult).Should().BeDerivedFrom<object>().And.Implement<IDeputyTranscriptsResult>();

    var transcript = new DeputyTranscriptsResult();
    transcript.Name.Should().BeNull();
    transcript.Page.Should().BeNull();
    transcript.PageSize.Should().BeNull();
    transcript.Count.Should().BeNull();
    transcript.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new DeputyTranscriptsResult { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property()
  {
    new DeputyTranscriptsResult { Page = int.MaxValue }.Page.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.PageSize"/> property.</para>
  /// </summary>
  [Fact]
  public void PageSize_Property()
  {
    new DeputyTranscriptsResult { PageSize = int.MaxValue }.PageSize.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property()
  {
    new DeputyTranscriptsResult { Count = int.MaxValue }.Count.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var transcript = new DeputyTranscriptsResult();
    var meeting = new TranscriptMeeting();

    var meetings = transcript.Meetings.To<List<TranscriptMeeting>>();

    meetings.Add(meeting);
    transcript.Meetings.Should().ContainSingle().Which.Should().BeSameAs(meeting);

    meetings.Remove(meeting);
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
  public void ToString_Method()
  {
    new DeputyTranscriptsResult {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new DeputyTranscriptsResult());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}