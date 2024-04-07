using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StagePhase"/>.</para>
/// </summary>
public sealed class StagePhaseTest : ClassTest<StagePhase>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Topic(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new StagePhase(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Instance"/> property.</para>
  /// </summary>
  [Fact]
  public void Instance_Property()
  {
    var instance = new Instance();
    new StagePhase(new {Instance = instance}).Instance.Should().BeSameAs(instance);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="StagePhase(long?, string?, IInstance?)"/>
  /// <seealso cref="StagePhase(StagePhase.Info)"/>
  /// <seealso cref="StagePhase(object)"/>
  [Fact]
  public void Constructors()
  {
    var phase = new StagePhase();
    phase.Id.Should().BeNull();
    phase.Name.Should().BeNull();
    phase.Instance.Should().BeNull();

    phase = new StagePhase(new StagePhase.Info());
    phase.Id.Should().BeNull();
    phase.Name.Should().BeNull();
    phase.Instance.Should().BeNull();

    phase = new StagePhase(new {});
    phase.Id.Should().BeNull();
    phase.Name.Should().BeNull();
    phase.Instance.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.CompareTo(IStagePhase)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(StagePhase.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="StagePhase.Equals(IStagePhase)"/></description></item>
  ///     <item><description><see cref="StagePhase.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(StagePhase.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(StagePhase.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new StagePhase(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="StagePhase.Info"/>.</para>
/// </summary>
public sealed class StagePhaseInfoTests : ClassTest<StagePhase.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Topic.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new StagePhase.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Info.Instance"/> property.</para>
  /// </summary>
  [Fact]
  public void Instance_Property()
  {
    var instance = new Instance(new {});
    new StagePhase.Info {Instance = instance}.Instance.Should().BeSameAs(instance);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="StagePhase.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new StagePhase.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.Instance.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new StagePhase.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<StagePhase>();
      result.Id.Should().BeNull();
      result.Name.Should().BeNull();
      result.Instance.Should().BeNull();
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
      Validate(new StagePhase.Info
      {
        Id = 1,
        Name = "name",
        Instance = new Instance(new { Id = 2 })
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}