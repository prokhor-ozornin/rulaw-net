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
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="StagePhase()"/>
  [Fact]
  public void Constructors()
  {
    typeof(StagePhase).Should().BeDerivedFrom<object>().And.Implement<IStagePhase>();

    var phase = new StagePhase();
    phase.Id.Should().BeNull();
    phase.Name.Should().BeNull();
    phase.Instance.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Topic { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new StagePhase { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StagePhase.Instance"/> property.</para>
  /// </summary>
  [Fact]
  public void Instance_Property()
  {
    var instance = new Instance();
    new StagePhase { Instance = instance }.Instance.Should().BeSameAs(instance);
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
    new StagePhase {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new StagePhase
      {
        Id = 1,
        Name = "name",
        Instance = new Instance { Id = 2 }
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}