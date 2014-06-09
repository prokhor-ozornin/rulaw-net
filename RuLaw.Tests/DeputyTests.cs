using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Deputy"/>.</para>
  /// </summary>
  public sealed class DeputyTests : UnitTestsBase<Deputy>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Id", "Name", "Active", "Position");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new Deputy(), new { id = 0, isCurrent = false } );
      this.TestJson(
        new Deputy
        {
          Id = 1,
          Active = true,
          Name = "name",
          Position = "position"
        },
        new { id = 1, isCurrent = true, name = "name", position = "position" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new Deputy(), "deputy", new { id = 0, isCurrent = false });
      this.TestXml(
        new Deputy
        {
          Id = 1,
          Active = true,
          Name = "name",
          Position = "position"
        },
        "deputy",
        new { id = 1, isCurrent = true, name = "name", position = "position" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Deputy()"/>
    [Fact]
    public void Constructors()
    {
      var deputy = new Deputy();
      Assert.Equal(0, deputy.Id);
      Assert.False(deputy.Active);
      Assert.Null(deputy.Name);
      Assert.Null(deputy.Position);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Deputy.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Deputy { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Deputy.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new Deputy { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Deputy.Active"/> property.</para>
    /// </summary>
    [Fact]
    public void Active_Property()
    {
      Assert.True(new Deputy { Active = true }.Active);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Deputy.Position"/> property.</para>
    /// </summary>
    [Fact]
    public void Position_Property()
    {
      Assert.Equal("position", new Deputy { Position = "position" }.Position);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Deputy.GetPosition()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetPosition_Method()
    {
      Assert.Null(new Deputy().GetPosition());
      Assert.Throws<InvalidOperationException>(() => new Deputy { Position = "position" }.GetPosition());
      Assert.Equal(DeputyPosition.DumaDeputy, new Deputy { Position = "Депутат ГД" }.GetPosition());
      Assert.Equal(DeputyPosition.FederationCouncilMember, new Deputy { Position = "Член СФ" }.GetPosition());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Deputy.CompareTo(Deputy)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Deputy.Equals(Deputy)"/></description></item>
    ///     <item><description><see cref="Deputy.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Deputy.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Deputy.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Deputy { Name = "name" }.ToString());
    }
  }
}