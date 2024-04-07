using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawEvent"/>.</para>
/// </summary>
public sealed class LawEventTest : ClassTest<LawEvent>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new LawEvent(new {Date = DateTimeOffset.MaxValue}).Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Solution"/> property.</para>
  /// </summary>
  [Fact]
  public void Solution_Property() { new LawEvent(new {Solution = Guid.Empty.ToString()}).Solution.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Document"/> property.</para>
  /// </summary>
  [Fact]
  public void Document_Property()
  {
    var document = new LawEventDocument(new {});
    new LawEvent(new {Document = document}).Document.Should().BeSameAs(document);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Phase"/> property.</para>
  /// </summary>
  [Fact]
  public void Phase_Property()
  {
    var phase = new LawEventPhase(new {});
    new LawEvent(new {Phase = phase}).Phase.Should().BeSameAs(phase);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Stage"/> property.</para>
  /// </summary>
  [Fact]
  public void Stage_Property()
  {
    var stage = new LawEventStage(new {});
    new LawEvent(new {Stage = stage}).Stage.Should().BeSameAs(stage);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEvent(DateTimeOffset?, string?, ILawEventDocument?, ILawEventPhase?, ILawEventStage?)"/>
  /// <seealso cref="LawEvent(LawEvent.Info)"/>
  /// <seealso cref="LawEvent(object)"/>
  [Fact]
  public void Constructors()
  {
    var lawEvent = new LawEvent();
    lawEvent.Date.Should().BeNull();
    lawEvent.Solution.Should().BeNull();
    lawEvent.Document.Should().BeNull();
    lawEvent.Phase.Should().BeNull();
    lawEvent.Stage.Should().BeNull();

    lawEvent = new LawEvent(new LawEvent.Info());
    lawEvent.Date.Should().BeNull();
    lawEvent.Solution.Should().BeNull();
    lawEvent.Document.Should().BeNull();
    lawEvent.Phase.Should().BeNull();
    lawEvent.Stage.Should().BeNull();

    lawEvent = new LawEvent(new {});
    lawEvent.Date.Should().BeNull();
    lawEvent.Solution.Should().BeNull();
    lawEvent.Document.Should().BeNull();
    lawEvent.Phase.Should().BeNull();
    lawEvent.Stage.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.CompareTo(ILawEvent)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawEvent.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new LawEvent(new {Solution = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="LawEvent.Info"/>.</para>
/// </summary>
public sealed class LawEventInfoTests : ClassTest<LawEvent.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Info.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new LawEvent.Info {Date = Guid.Empty.ToString()}.Date.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Info.Solution"/> property.</para>
  /// </summary>
  [Fact]
  public void Solution_Property() { new LawEvent.Info {Solution = Guid.Empty.ToString()}.Solution.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Info.Document"/> property.</para>
  /// </summary>
  [Fact]
  public void Document_Property()
  {
    var document = new LawEventDocument(new {});
    new LawEvent.Info {Document = document}.Document.Should().BeSameAs(document);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Info.Phase"/> property.</para>
  /// </summary>
  [Fact]
  public void Phase_Property()
  {
    var phase = new LawEventPhase(new {});
    new LawEvent.Info {Phase = phase}.Phase.Should().BeSameAs(phase);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Info.Stage"/> property.</para>
  /// </summary>
  [Fact]
  public void Stage_Property()
  {
    var stage = new LawEventStage(new {});
    new LawEvent.Info {Stage = stage}.Stage.Should().BeSameAs(stage);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEvent.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new LawEvent.Info();
    info.Date.Should().BeNull();
    info.Solution.Should().BeNull();
    info.Document.Should().BeNull();
    info.Phase.Should().BeNull();
    info.Stage.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new LawEvent.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<LawEvent>();
      result.Date.Should().BeNull();
      result.Solution.Should().BeNull();
      result.Document.Should().BeNull();
      result.Phase.Should().BeNull();
      result.Stage.Should().BeNull();
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
      Validate(new LawEvent.Info
      {
        Date = DateTimeOffset.MinValue.AsString(),
        Document = new LawEventDocument(new { Name = "document.name", Type = "document.type" }),
        Phase = new LawEventPhase(new { Id = 2, Name = "phase.name" }),
        Solution = "solution",
        Stage = new LawEventStage(new { Id = 3, Name = "stage.name" })
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}