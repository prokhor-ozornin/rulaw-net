using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="RegionalAuthority"/>.</para>
  /// </summary>
  public sealed class RegionalAuthorityTests : UnitTestsBase<RegionalAuthority>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new RegionalAuthority(), new { id = 0, isCurrent = false, startDate = default(DateTime) });
      this.TestJson(
        new RegionalAuthority
        {
          Id = 1,
          Active = true,
          FromDate = DateTime.MinValue,
          Name = "name",
          ToDate = DateTime.MaxValue
        },
        new { id = 1, isCurrent = true, name = "name", startDate = DateTime.MinValue, stopDate = DateTime.MaxValue }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new RegionalAuthority(), "regionalOrgan", new { id = 0, isCurrent = false, startDate = default(DateTime).ISO8601() });
      this.TestXml(
        new RegionalAuthority
        {
          Id = 1,
          Active = true,
          FromDate = DateTime.MinValue,
          Name = "name",
          ToDate = DateTime.MaxValue
        },
        "regionalOrgan",
        new { id = 1, isCurrent = true, name = "name", startDate = DateTime.MinValue.ISO8601(), stopDate = DateTime.MaxValue.ISO8601() }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="RegionalAuthority()"/>
    [Fact]
    public void Constructors()
    {
      var authority = new RegionalAuthority();
      Assert.Equal(0, authority.Id);
      Assert.False(authority.Active);
      Assert.Equal(default(DateTime), authority.FromDate);
      Assert.Null(authority.Name);
      Assert.False(authority.ToDate.HasValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RegionalAuthority.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new RegionalAuthority { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RegionalAuthority.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new RegionalAuthority { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RegionalAuthority.Active"/> property.</para>
    /// </summary>
    [Fact]
    public void Active_Property()
    {
      Assert.True(new RegionalAuthority { Active = true }.Active);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RegionalAuthority.FromDate"/> property.</para>
    /// </summary>
    [Fact]
    public void FromDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new RegionalAuthority { FromDate = DateTime.MinValue }.FromDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RegionalAuthority.ToDate"/> property.</para>
    /// </summary>
    [Fact]
    public void ToDate_Property()
    {
      Assert.Equal(DateTime.MaxValue, new RegionalAuthority { ToDate = DateTime.MaxValue }.ToDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RegionalAuthority.CompareTo(RegionalAuthority)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="RegionalAuthority.Equals(RegionalAuthority)"/></description></item>
    ///     <item><description><see cref="RegionalAuthority.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RegionalAuthority.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RegionalAuthority.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new RegionalAuthority { Name = "name" }.ToString());
    }
  }
}