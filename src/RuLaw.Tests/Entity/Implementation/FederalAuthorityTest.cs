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
  /// <seealso cref="FederalAuthority()"/>
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
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new RegionalAuthority { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new FederalAuthority { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property()
  {
    new FederalAuthority { Active = true }.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property()
  {
    new FederalAuthority { FromDate = DateTimeOffset.MaxValue }.FromDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FederalAuthority.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property()
  {
    new FederalAuthority { ToDate = DateTimeOffset.MaxValue }.ToDate.Should().Be(DateTimeOffset.MaxValue);
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
      Validate(new FederalAuthority
      {
        Id = 1,
        Active = true,
        FromDate = DateTimeOffset.MinValue,
        Name = "name",
        ToDate = DateTimeOffset.MaxValue
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}