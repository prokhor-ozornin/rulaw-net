using System.Runtime.Serialization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FederalAuthority"/>.</para>
/// </summary>
public sealed class FederalAuthorityTest : ClassTest<FederalAuthority>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="FederalAuthority(long?, string?, bool?, DateTimeOffset?, DateTimeOffset?)"/>
  /// <seealso cref="FederalAuthority(FederalAuthority.Info)"/>
  /// <seealso cref="FederalAuthority(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(FederalAuthority).Should().BeDerivedFrom<Authority>();

    var authority = new FederalAuthority();
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();

    authority = new FederalAuthority(new FederalAuthority.Info());
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();

    authority = new FederalAuthority(new {});
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new RegionalAuthority(new
    {
      Id = long.MaxValue
    }).Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new FederalAuthority(new
    {
      Name = Guid.Empty.ToString()
    }).Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property()
  {
    new FederalAuthority(new
    {
      Active = true
    }).Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property()
  {
    new FederalAuthority(new
    {
      FromDate = DateTimeOffset.MaxValue
    }).FromDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property()
  {
    new FederalAuthority(new
    {
      ToDate = DateTimeOffset.MaxValue
    }).ToDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.CompareTo(IAuthority)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(FederalAuthority.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="FederalAuthority.Equals(IAuthority)"/></description></item>
  ///     <item><description><see cref="FederalAuthority.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(FederalAuthority.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(FederalAuthority.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new FederalAuthority(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="FederalAuthority.Info"/>.</para>
/// </summary>
public sealed class FederalAuthorityInfoTests : ClassTest<FederalAuthority.Info>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="FederalAuthority.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(FederalAuthority.Info).Should().BeDerivedFrom<Authority.Info>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new FederalAuthority.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.Active.Should().BeNull();
    info.FromDate.Should().BeNull();
    info.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new RegionalAuthority.Info { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new FederalAuthority.Info { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Info.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property()
  {
    new FederalAuthority.Info { Active = true }.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Info.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property()
  {
    new FederalAuthority.Info { FromDate = Guid.Empty.ToString() }.FromDate.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Info.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property()
  {
    new FederalAuthority.Info { ToDate = Guid.Empty.ToString() }.ToDate.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Authority.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new FederalAuthority.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<FederalAuthority>();
      result.Id.Should().BeNull();
      result.Name.Should().BeNull();
      result.Active.Should().BeNull();
      result.FromDate.Should().BeNull();
      result.ToDate.Should().BeNull();
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
      Validate(new FederalAuthority.Info
      {
        Id = 1,
        Active = true,
        FromDate = DateTimeOffset.MinValue.AsString(),
        Name = "name",
        ToDate = DateTimeOffset.MaxValue.AsString()
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}