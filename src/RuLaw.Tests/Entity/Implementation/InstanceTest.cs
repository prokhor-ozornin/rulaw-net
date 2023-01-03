using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Instance"/>.</para>
/// </summary>
public sealed class InstanceTest : UnitTest<Instance>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Instance(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Instance(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property() { new Instance(new {Active = true}).Active.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.CompareTo(IInstance)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Instance.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Instance.Equals(IInstance)"/></description></item>
  ///     <item><description><see cref="Instance.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Instance.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Instance.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Instance(long?, string?, bool?)"/>
  /// <seealso cref="Instance(Instance.Info)"/>
  /// <seealso cref="Instance(object)"/>
  [Fact]
  public void Constructors()
  {
    var instance = new Instance();
    instance.Id.Should().BeNull();
    instance.Name.Should().BeNull();
    instance.Active.Should().BeNull();

    instance = new Instance(new Instance.Info());
    instance.Id.Should().BeNull();
    instance.Name.Should().BeNull();
    instance.Active.Should().BeNull();

    instance = new Instance(new {});
    instance.Id.Should().BeNull();
    instance.Name.Should().BeNull();
    instance.Active.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new Instance(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="Instance.Info"/>.</para>
/// </summary>
public sealed class InstanceInfoTests : UnitTest<Instance.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Instance.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Instance.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Info.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property() { new Instance.Info {Active = true}.Active.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Instance.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new Instance.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.Active.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new Instance.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<Instance>();
    result.Id.Should().BeNull();
    result.Name.Should().BeNull();
    result.Active.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new Instance.Info
    {
      Id = 1,
      Active = true,
      Name = "name"
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}