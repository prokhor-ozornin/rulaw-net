using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="StagePhase"/>.</para>
  /// </summary>
  public sealed class StagePhaseTests : UnitTestsBase<StagePhase>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new StagePhase(), new { id = 0 });
      this.TestJson(
        new StagePhase
        {
          Id = 1,
          Name = "name",
          InstanceOriginal = new Instance { Id = 2 }
        },
        new { id = 1, instance = new { id = 2, isCurrent = false }, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new StagePhase(), "phase", new { id = 0 });
      this.TestXml(
        new StagePhase
        {
          Id = 1,
          Name = "name",
          InstanceOriginal = new Instance { Id = 2 }
        },
        "phase",
        new { id = 1, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="StagePhase()"/>
    [Fact]
    public void Constructors()
    {
      var phase = new StagePhase();
      Assert.Equal(0, phase.Id);
      Assert.Null(phase.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="StagePhase.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Topic { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="StagePhase.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new StagePhase { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="StagePhase.CompareTo(IStagePhase)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="StagePhase.Equals(IStagePhase)"/></description></item>
    ///     <item><description><see cref="StagePhase.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="StagePhase.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="StagePhase.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new StagePhase { Name = "name" }.ToString());
    }
  }
}