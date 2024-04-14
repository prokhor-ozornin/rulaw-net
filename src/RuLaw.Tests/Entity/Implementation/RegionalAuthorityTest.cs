using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RegionalAuthority"/>.</para>
/// </summary>
public sealed class RegionalAuthorityTest : ClassTest<RegionalAuthority>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="RegionalAuthority()"/>
  [Fact]
  public void Constructors()
  {
    typeof(RegionalAuthority).Should().BeDerivedFrom<Authority>();

    var authority = new RegionalAuthority();
    authority.Id.Should().BeNull();
    authority.Name.Should().BeNull();
    authority.Active.Should().BeNull();
    authority.FromDate.Should().BeNull();
    authority.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new RegionalAuthority { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new RegionalAuthority { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property()
  {
    new RegionalAuthority { Active = true }.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property()
  {
    new RegionalAuthority { FromDate = DateTimeOffset.MaxValue }.FromDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionalAuthority.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property()
  {
    new RegionalAuthority { ToDate = DateTimeOffset.MaxValue }.ToDate.Should().Be(DateTimeOffset.MaxValue);
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
  public void ToString_Method()
  {
    new RegionalAuthority {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new RegionalAuthority
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