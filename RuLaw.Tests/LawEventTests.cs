using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawEvent"/>.</para>
  /// </summary>
  public sealed class LawEventTests : UnitTestsBase<LawEvent>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Date", "Document", "Phase", "Solution", "Stage");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new LawEvent(), new { date = default(DateTime).ISO8601() });
      this.TestJson(
        new LawEvent
        {
          Date = DateTime.MinValue,
          Document = new LawEventDocument { Name = "document.name", Type = "document.type" },
          Phase = new LawEventPhase { Id = 2, Name = "phase.name" },
          Solution = "solution",
          Stage = new LawEventStage { Id = 3, Name = "stage.name" }
        },
        new { date = DateTime.MinValue.ISO8601(), document = new { name = "document.name", type = "document.type" }, phase = new { id = 2, name = "phase.name" }, solution = "solution", stage = new { id = 3, name = "stage.name" } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new LawEvent(), "lastEvent", new { date = default(DateTime).ISO8601() });
      this.TestXml(
        new LawEvent
        {
          Date = DateTime.MinValue,
          Document = new LawEventDocument { Name = "document.name", Type = "document.type" },
          Phase = new LawEventPhase { Id = 2, Name = "phase.name" },
          Solution = "solution",
          Stage = new LawEventStage { Id = 3, Name = "stage.name" }
        },
        "lastEvent",
        new { date = DateTime.MinValue.ISO8601(), solution = "solution" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawEvent()"/>
    [Fact]
    public void Constructors()
    {
      var lawEvent = new LawEvent();
      Assert.Equal(default(DateTime), lawEvent.Date);
      Assert.Null(lawEvent.Document);
      Assert.Null(lawEvent.Phase);
      Assert.Null(lawEvent.Solution);
      Assert.Null(lawEvent.Stage);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEvent.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new LawEvent { Date = DateTime.MinValue }.Date);
    }
    
    /// <summary>
    ///   <para>Performs testing of <see cref="LawEvent.Document"/> property.</para>
    /// </summary>
    [Fact]
    public void Document_Property()
    {
      var document = new LawEventDocument();
      Assert.True(ReferenceEquals(new LawEvent { Document = document }.Document, document));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEvent.Phase"/> property.</para>
    /// </summary>
    [Fact]
    public void Phase_Property()
    {
      var phase = new LawEventPhase();
      Assert.True(ReferenceEquals(new LawEvent { Phase = phase }.Phase, phase));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEvent.Solution"/> property.</para>
    /// </summary>
    [Fact]
    public void Solution_Property()
    {
      Assert.Equal("solution", new LawEvent { Solution = "solution" }.Solution);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEvent.Stage"/> property.</para>
    /// </summary>
    [Fact]
    public void Stage_Property()
    {
      var stage = new LawEventStage();
      Assert.True(ReferenceEquals(new LawEvent { Stage = stage }.Stage, stage));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEvent.CompareTo(LawEvent)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEvent.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("solution", new LawEvent { Solution = "solution" }.ToString());
    }
  }
}