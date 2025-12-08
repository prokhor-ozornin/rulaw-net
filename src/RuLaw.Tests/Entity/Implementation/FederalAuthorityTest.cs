using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FederalAuthority"/>.</para>
/// </summary>
/// <seealso cref="FederalAuthority"/>
public sealed class FederalAuthorityTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="FederalAuthority()"/>
  [Fact]
  public void Constructors()
  {
    typeof(FederalAuthority).Should().BeDerivedFrom<Authority>();

    using (new AssertionScope())
    {
      var authority = new FederalAuthority();

      authority.Id.Should().BeNull();
      authority.Name.Should().BeNull();
      authority.Active.Should().BeNull();
      authority.FromDate.Should().BeNull();
      authority.ToDate.Should().BeNull();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEntity.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() => new RegionalAuthority { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);

  /// <summary>
  ///   <para>Performs testing of <see cref="INameable.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() => new FederalAuthority { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());

  /// <summary>
  ///   <para>Performs testing of <see cref="IActive.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property() => new FederalAuthority { Active = true }.Active.Should().BeTrue();
  
  /// <summary>
  ///   <para>Performs testing of <see cref="IPeriodable.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property() => new FederalAuthority { FromDate = DateTimeOffset.MaxValue }.FromDate.Should().Be(DateTimeOffset.MaxValue);

  /// <summary>
  ///   <para>Performs testing of <see cref="IPeriodable.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() => new FederalAuthority { ToDate = DateTimeOffset.MaxValue }.ToDate.Should().Be(DateTimeOffset.MaxValue);

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparable{IAuthority}.CompareTo(IAuthority)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() => TestCompareTo<FederalAuthority, string>(nameof(FederalAuthority.Name), "first", "second"); 

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IEquatable{IAuthority}.Equals(IAuthority)"/></description></item>
  ///     <item><description><see cref="object.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() => TestEquality<FederalAuthority, long>(nameof(FederalAuthority.Id), 1, 2); 

  /// <summary>
  ///   <para>Performs testing of <see cref="object.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() => TestHashCode<FederalAuthority, long>(nameof(FederalAuthority.Id), 1, 2); 

  /// <summary>
  ///   <para>Performs testing of <see cref="object.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new FederalAuthority {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Test(new FederalAuthority
      {
        Id = 1,
        Active = true,
        FromDate = DateTimeOffset.MinValue,
        Name = "name",
        ToDate = DateTimeOffset.MaxValue
      });
    }

    return;

    static void Test(IAuthority authority) => authority.To<object>().Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}