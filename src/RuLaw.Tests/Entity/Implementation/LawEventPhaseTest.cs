using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawEventPhase"/>.</para>
/// </summary>
public sealed class LawEventPhaseTest : ClassTest<LawEventPhase>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new LawEventPhase(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawEventPhase(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEventPhase(long?, string?)"/>
  /// <seealso cref="LawEventPhase(LawEventPhase.Info)"/>
  /// <seealso cref="LawEventPhase(object)"/>
  [Fact]
  public void Constructors()
  {
    var phase = new LawEventPhase();
    phase.Id.Should().BeNull();
    phase.Name.Should().BeNull();

    phase = new LawEventPhase(new LawEventPhase.Info());
    phase.Id.Should().BeNull();
    phase.Name.Should().BeNull();

    phase = new LawEventPhase(new {});
    phase.Id.Should().BeNull();
    phase.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.CompareTo(ILawEventPhase)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawEventPhase.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="LawEventPhase.Equals(ILawEventPhase)"/></description></item>
  ///     <item><description><see cref="LawEventPhase.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(LawEventPhase.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(LawEventPhase.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new LawEventPhase(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="LawEventPhase.Info"/>.</para>
/// </summary>
public sealed class LawEventPhaseInfoTests : ClassTest<LawEventPhase.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new LawEventPhase.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawEventPhase.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEventPhase.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new LawEventPhase.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new LawEventPhase.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<LawEventPhase>();
    result.Id.Should().BeNull();
    result.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new LawEventPhase.Info
    {
      Id = 1,
      Name = "name"
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}