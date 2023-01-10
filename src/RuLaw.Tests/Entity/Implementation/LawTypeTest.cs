using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawType"/>.</para>
/// </summary>
public sealed class LawTypeTest : EntityTest<LawType>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new LawType(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawType(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawType(long?, string?)"/>
  /// <seealso cref="LawType(LawType.Info)"/>
  /// <seealso cref="LawType(object)"/>
  [Fact]
  public void Constructors()
  {
    var type = new LawType();
    type.Id.Should().BeNull();
    type.Name.Should().BeNull();

    type = new LawType(new LawType.Info());
    type.Id.Should().BeNull();
    type.Name.Should().BeNull();

    type = new LawType(new {});
    type.Id.Should().BeNull();
    type.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.CompareTo(ILawType)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawType.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="LawType.Equals(ILawType)"/></description></item>
  ///     <item><description><see cref="LawType.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(LawType.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(LawType.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new LawType(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="LawType.Info"/>.</para>
/// </summary>
public sealed class LawTypeInfoTests : EntityTest<LawType.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new LawType.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawType.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawType.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new LawType.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new LawType.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<LawType>();
    result.Id.Should().BeNull();
    result.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of JSON serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new LawType.Info
    {
      Id = 1,
      Name = "name"
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}