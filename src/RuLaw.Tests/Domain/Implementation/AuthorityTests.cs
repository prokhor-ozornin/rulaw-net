using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Authority"/>.</para>
  /// </summary>
  public sealed class AuthorityTests : UnitTestsBase<Authority>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new Authority(), new { id = 0, isCurrent = false, startDate = default(DateTime) });
      TestJson(
        new Authority
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
      TestXml(new Authority(), "department", new { id = 0, isCurrent = false, startDate = default(DateTime).ISO8601() });
      TestXml(
        new Authority
        {
          Id = 1,
          Active = true,
          FromDate = DateTime.MinValue,
          Name = "name",
          ToDate = DateTime.MaxValue
        },
        "department",
        new { id = 1, name = "name", isCurrent = true, startDate = DateTime.MinValue.ISO8601(), stopDate = DateTime.MaxValue.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Authority()"/>
    [Fact]
    public void Constructors()
    {
      var authority = new Authority();
      Assert.Equal(0, authority.Id);
      Assert.False(authority.Active);
      Assert.Equal(default(DateTime), authority.FromDate);
      Assert.Null(authority.Name);
      Assert.False(authority.ToDate.HasValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Authority.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Authority { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Authority.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new Authority { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Authority.Active"/> property.</para>
    /// </summary>
    [Fact]
    public void Active_Property()
    {
      Assert.True(new Authority { Active = true }.Active);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Authority.FromDate"/> property.</para>
    /// </summary>
    [Fact]
    public void FromDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new Authority { FromDate = DateTime.MinValue }.FromDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Authority.ToDate"/> property.</para>
    /// </summary>
    [Fact]
    public void ToDate_Property()
    {
      Assert.Equal(DateTime.MaxValue, new Authority { ToDate = DateTime.MaxValue }.ToDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Authority.CompareTo(IAuthority)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Authority.Equals(IAuthority)"/></description></item>
    ///     <item><description><see cref="Authority.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Authority.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Authority.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Authority { Name = "name" }.ToString());
    }
  }
}