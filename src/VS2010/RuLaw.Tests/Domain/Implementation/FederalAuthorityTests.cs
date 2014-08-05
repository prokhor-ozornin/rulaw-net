using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="FederalAuthority"/>.</para>
  /// </summary>
  public sealed class FederalAuthorityTests : UnitTestsBase<FederalAuthority>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new FederalAuthority(), new { id = 0, isCurrent = false, startDate = default(DateTime) });
      this.TestJson(
        new FederalAuthority
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
      this.TestXml(new FederalAuthority(), "federalOrgan", new { id = 0, isCurrent = false, startDate = default(DateTime).ISO8601() });
      this.TestXml(
        new FederalAuthority
        {
          Id = 1,
          Active = true,
          FromDate = DateTime.MinValue,
          Name = "name",
          ToDate = DateTime.MaxValue
        },
        "federalOrgan",
        new { id = 1, isCurrent = true, name = "name", startDate = DateTime.MinValue.ISO8601(), stopDate = DateTime.MaxValue.ISO8601() }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="FederalAuthority()"/>
    [Fact]
    public void Constructors()
    {
      var authority = new FederalAuthority();
      Assert.Equal(0, authority.Id);
      Assert.False(authority.Active);
      Assert.Equal(default(DateTime), authority.FromDate);
      Assert.Null(authority.Name);
      Assert.Null(authority.ToDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="FederalAuthority.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new RegionalAuthority { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="FederalAuthority.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new FederalAuthority { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="FederalAuthority.Active"/> property.</para>
    /// </summary>
    [Fact]
    public void Active_Property()
    {
      Assert.True(new FederalAuthority { Active = true }.Active);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="FederalAuthority.FromDate"/> property.</para>
    /// </summary>
    [Fact]
    public void FromDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new FederalAuthority { FromDate = DateTime.MinValue }.FromDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="FederalAuthority.ToDate"/> property.</para>
    /// </summary>
    [Fact]
    public void ToDate_Property()
    {
      Assert.Equal(DateTime.MaxValue, new FederalAuthority { ToDate = DateTime.MaxValue }.ToDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="FederalAuthority.CompareTo(IAuthority)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="FederalAuthority.Equals(IAuthority)"/></description></item>
    ///     <item><description><see cref="FederalAuthority.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="FederalAuthority.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="FederalAuthority.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new FederalAuthority { Name = "name" }.ToString());
    }
  }
}