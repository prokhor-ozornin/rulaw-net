using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="PhaseStage"/>.</para>
/// </summary>
public sealed class PhaseStageTest : ClassTest<PhaseStage>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="PhaseStage()"/>
  [Fact]
  public void Constructors()
  {
    typeof(PhaseStage).Should().BeDerivedFrom<object>().And.Implement<IPhaseStage>();

    var stage = new PhaseStage();
    stage.Id.Should().BeNull();
    stage.Name.Should().BeNull();
    stage.Phases.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new PhaseStage { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new PhaseStage { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PhaseStage.Phases"/> property.</para>
  /// </summary>
  [Fact]
  public void Phases_Property()
  {
    var stage = new PhaseStage();
    stage.Phases.Should().BeEmpty();

    var phase = new StagePhase();

    var phases = stage.Phases.To<List<StagePhase>>();
    phases.Add(phase);
    stage.Phases.Should().ContainSingle().Which.Should().BeSameAs(phase);
    phases.Remove(phase);
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
  public void ToString_Method()
  {
    new PhaseStage {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new PhaseStage
      {
        Id = 1,
        Name = "name",
        Phases = [new StagePhase { Id = 2 }]
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}