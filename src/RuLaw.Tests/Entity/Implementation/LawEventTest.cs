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
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEvent()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawEvent).Should().BeDerivedFrom<object>().And.Implement<ILawEvent>();

    var lawEvent = new LawEvent();
    lawEvent.Date.Should().BeNull();
    lawEvent.Solution.Should().BeNull();
    lawEvent.Document.Should().BeNull();
    lawEvent.Phase.Should().BeNull();
    lawEvent.Stage.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new LawEvent { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Solution"/> property.</para>
  /// </summary>
  [Fact]
  public void Solution_Property()
  {
    new LawEvent { Solution = Guid.Empty.ToString() }.Solution.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Document"/> property.</para>
  /// </summary>
  [Fact]
  public void Document_Property()
  {
    var document = new LawEventDocument();
    new LawEvent { Document = document }.Document.Should().BeSameAs(document);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Phase"/> property.</para>
  /// </summary>
  [Fact]
  public void Phase_Property()
  {
    var phase = new LawEventPhase();
    new LawEvent { Phase = phase }.Phase.Should().BeSameAs(phase);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEvent.Stage"/> property.</para>
  /// </summary>
  [Fact]
  public void Stage_Property()
  {
    var stage = new LawEventStage();
    new LawEvent { Stage = stage }.Stage.Should().BeSameAs(stage);
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
    new LawEvent {Solution = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new LawEvent
      {
        Date = DateTimeOffset.MinValue,
        Document = new LawEventDocument { Name = "document.name", Type = "document.type" },
        Phase = new LawEventPhase { Id = 2, Name = "phase.name" },
        Solution = "solution",
        Stage = new LawEventStage { Id = 3, Name = "stage.name" }
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}