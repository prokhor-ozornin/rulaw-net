using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="PhaseStage"/>.</para>
/// </summary>
public sealed class PhaseStageTest : UnitTest<PhaseStage>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new PhaseStage(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new PhaseStage(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Phases"/> property.</para>
  /// </summary>
  [Fact]
  public void Phases_Property()
  {
    var stage = new PhaseStage(new PhaseStage.Info());
    stage.Phases.Should().BeEmpty();

    var phase = new StagePhase(new {});

    var phases = stage.Phases.To<List<StagePhase>>();
    phases.Add(phase);
    stage.Phases.Should().ContainSingle().Which.Should().BeSameAs(phase);
    phases.Remove(phase);
    stage.Phases.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="PhaseStage(long?, string?, IEnumerable{IStagePhase}?)"/>
  /// <seealso cref="PhaseStage(PhaseStage.Info)"/>
  /// <seealso cref="PhaseStage(object)"/>
  [Fact]
  public void Constructors()
  {
    var stage = new PhaseStage();
    stage.Id.Should().BeNull();
    stage.Name.Should().BeNull();
    stage.Phases.Should().BeEmpty();

    stage = new PhaseStage(new PhaseStage.Info());
    stage.Id.Should().BeNull();
    stage.Name.Should().BeNull();
    stage.Phases.Should().BeEmpty();

    stage = new PhaseStage(new {});
    stage.Id.Should().BeNull();
    stage.Name.Should().BeNull();
    stage.Phases.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.CompareTo(IStage)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(PhaseStage.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="PhaseStage.Equals(IPhaseStage)"/></description></item>
  ///     <item><description><see cref="PhaseStage.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(PhaseStage.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(PhaseStage.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new PhaseStage(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="PhaseStage.Info"/>.</para>
/// </summary>
public sealed class PhaseStageInfoTests : UnitTest<PhaseStage.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new PhaseStage.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new PhaseStage.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Info.Phases"/> property.</para>
  /// </summary>
  [Fact]
  public void Phases_Property()
  {
    var phases = new List<StagePhase>();
    new PhaseStage.Info {Phases = phases}.Phases.Should().BeSameAs(phases);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="PhaseStage.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new PhaseStage.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.Phases.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new PhaseStage.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<PhaseStage>();
    result.Id.Should().BeNull();
    result.Name.Should().BeNull();
    result.Phases.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new PhaseStage.Info
    {
      Id = 1,
      Name = "name",
      Phases = new List<StagePhase> {new(new {Id = 2})}
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}