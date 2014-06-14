using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="PhaseStage"/>.</para>
  /// </summary>
  public sealed class PhaseStageTests : UnitTestsBase<PhaseStage>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new PhaseStage(), new { id = 0, phases = new object[] { } });
      this.TestJson(
        new PhaseStage
        {
          Id = 1,
          Name = "name",
          Phases = new List<StagePhase> { new StagePhase { Id = 2 } }
        },
        new { id = 1, name = "name", phases = new object[] { new { id = 2 } } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new PhaseStage(), "stage", new { id = 0 });
      this.TestXml(
        new PhaseStage
        {
          Id = 1,
          Name = "name",
          Phases = new List<StagePhase> { new StagePhase { Id = 2 } }
        },
        "stage",
        new { id = 1, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="PhaseStage()"/>
    [Fact]
    public void Constructors()
    {
      var stage = new PhaseStage();
      Assert.Equal(0, stage.Id);
      Assert.Null(stage.Name);
      Assert.Equal(0, stage.Phases.Count);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PhaseStage.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new PhaseStage { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PhaseStage.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new PhaseStage { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PhaseStage.Phases"/> property.</para>
    /// </summary>
    [Fact]
    public void Phases_Property()
    {
      var stage = new PhaseStage();
      Assert.False(stage.Phases.Any());
      var phase = new StagePhase();
      stage.Phases.Add(phase);
      Assert.True(ReferenceEquals(stage.Phases.Single(), phase));
      stage.Phases.Remove(phase);
      Assert.False(stage.Phases.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PhaseStage.CompareTo(Stage)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="PhaseStage.Equals(Stage)"/></description></item>
    ///     <item><description><see cref="PhaseStage.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PhaseStage.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PhaseStage.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new PhaseStage { Name = "name" }.ToString());
    }
  }
}