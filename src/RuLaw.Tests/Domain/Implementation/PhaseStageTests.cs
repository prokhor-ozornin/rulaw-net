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
      TestJson(new PhaseStage(), new { id = 0, phases = new object[] { } });
      TestJson(
        new PhaseStage
        {
          Id = 1,
          Name = "name",
          PhasesOriginal = new List<StagePhase> { new StagePhase { Id = 2 } }
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
      TestXml(new PhaseStage(), "stage", new { id = 0 });
      TestXml(
        new PhaseStage
        {
          Id = 1,
          Name = "name",
          PhasesOriginal = new List<StagePhase> { new StagePhase { Id = 2 } }
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
      Assert.Empty(stage.PhasesOriginal);
      Assert.Empty(stage.Phases);
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
      Assert.Empty(stage.Phases);
      var phase = new StagePhase();
      stage.PhasesOriginal.Add(phase);
      Assert.True(ReferenceEquals(stage.PhasesOriginal.Single(), phase));
      Assert.True(ReferenceEquals(stage.Phases.Single(), phase));
      stage.PhasesOriginal.Remove(phase);
      Assert.Empty(stage.PhasesOriginal);
      Assert.Empty(stage.Phases);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PhaseStage.CompareTo(IStage)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="PhaseStage.Equals(IStage)"/></description></item>
    ///     <item><description><see cref="PhaseStage.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PhaseStage.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      TestHashCode("Id", 1, 2);
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