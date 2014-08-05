using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Committee"/>.</para>
  /// </summary>
  public sealed class CommitteeTests : UnitTestsBase<Committee>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new Committee(), new { id = 0, isCurrent = false, startDate = default(DateTime) });
      this.TestJson(
        new Committee
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
      this.TestXml(new Committee(), "committee", new { id = 0, isCurrent = false, startDate = default(DateTime).ISO8601() });
      this.TestXml(
        new Committee
        {
          Id = 1,
          Active = true,
          FromDate = DateTime.MinValue,
          Name = "name",
          ToDate = DateTime.MaxValue
        },
        "committee",
        new { id = 1, name = "name", isCurrent = true, startDate = DateTime.MinValue.ISO8601(), stopDate = DateTime.MaxValue.ISO8601() }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Committee()"/>
    [Fact]
    public void Constructors()
    {
      var committee = new Committee();
      Assert.Equal(0, committee.Id);
      Assert.False(committee.Active);
      Assert.Equal(default(DateTime), committee.FromDate);
      Assert.Null(committee.Name);
      Assert.False(committee.ToDate.HasValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Committee.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Committee { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Committee.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new Committee { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Committee.Active"/> property.</para>
    /// </summary>
    [Fact]
    public void Active_Property()
    {
      Assert.True(new Committee { Active = true }.Active);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Committee.FromDate"/> property.</para>
    /// </summary>
    [Fact]
    public void FromDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new Committee { FromDate = DateTime.MinValue }.FromDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Committee.ToDate"/> property.</para>
    /// </summary>
    [Fact]
    public void ToDate_Property()
    {
      Assert.Equal(DateTime.MaxValue, new Committee { ToDate = DateTime.MaxValue }.ToDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Committee.CompareTo(ICommittee)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Committee.Equals(ICommittee)"/></description></item>
    ///     <item><description><see cref="Committee.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Committee.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Committee.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Committee { Name = "name" }.ToString());
    }
  }
}