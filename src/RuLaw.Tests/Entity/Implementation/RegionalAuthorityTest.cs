using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RegionalAuthority"/>.</para>
/// </summary>
public sealed class RegionalAuthorityTest : ClassTest<RegionalAuthority>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new RegionalAuthority(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new RegionalAuthority(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property() { new RegionalAuthority(new {Active = true}).Active.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property() { new RegionalAuthority(new {FromDate = DateTimeOffset.MaxValue}).FromDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new RegionalAuthority(new {ToDate = DateTimeOffset.MaxValue}).ToDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="RegionalAuthority(long?, string?, bool?, DateTimeOffset?, DateTimeOffset?)"/>
  /// <seealso cref="RegionalAuthority(RegionalAuthority.Info)"/>
  /// <seealso cref="RegionalAuthority(object)"/>
  [Fact]
  public void Constructors()
  {
    var authority = new RegionalAuthority();
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();

    authority = new RegionalAuthority(new RegionalAuthority.Info());
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();

    authority = new RegionalAuthority(new {});
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.CompareTo(IAuthority)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(RegionalAuthority.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="RegionalAuthority.Equals(IAuthority)"/></description></item>
  ///     <item><description><see cref="RegionalAuthority.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(RegionalAuthority.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(RegionalAuthority.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new RegionalAuthority(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="RegionalAuthority.Info"/>.</para>
/// </summary>
public sealed class RegionalAuthorityInfoTests : ClassTest<RegionalAuthority.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new RegionalAuthority.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new RegionalAuthority.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Info.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property() { new RegionalAuthority.Info {Active = true}.Active.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Info.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property() { new RegionalAuthority.Info {FromDate = Guid.Empty.ToString()}.FromDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Info.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new RegionalAuthority.Info {ToDate = Guid.Empty.ToString()}.ToDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="RegionalAuthority.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new RegionalAuthority.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.Active.Should().BeNull();
    info.FromDate.Should().BeNull();
    info.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new RegionalAuthority.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<RegionalAuthority>();
    result.Id.Should().BeNull();
    result.Name.Should().BeNull();
    result.Active.Should().BeNull();
    result.FromDate.Should().BeNull();
    result.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new RegionalAuthority.Info
    {
      Id = 1,
      Active = true,
      FromDate = DateTimeOffset.MinValue.AsString(),
      Name = "name",
      ToDate = DateTimeOffset.MaxValue.AsString()
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}