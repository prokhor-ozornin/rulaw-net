﻿using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyRequestAddressee"/>.</para>
  /// </summary>
  public sealed class DeputyRequestAddresseeTests : UnitTestsBase<DeputyRequestAddressee>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Id", "Name");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new DeputyRequestAddressee(), new { id = 0 } );
      this.TestJson(
        new DeputyRequestAddressee
        {
          Id = 1,
          Name = "name"
        },
        new { id = 1, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new DeputyRequestAddressee(), "addressee", new { id = 0 });
      this.TestXml(
        new DeputyRequestAddressee
        {
          Id = 1,
          Name = "name"
        },
        "addressee",
        new { id = 1, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputyRequestAddressee()"/>
    [Fact]
    public void Constructors()
    {
      var addressee = new DeputyRequestAddressee();
      Assert.Equal(0, addressee.Id);
      Assert.Null(addressee.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestAddressee.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new DeputyRequestAddressee { Id = 1 }.Id);
    }
    
    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestAddressee.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new DeputyRequestAddressee { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestAddressee.CompareTo(DeputyRequestAddressee)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DeputyRequestAddressee.Equals(DeputyRequestAddressee)"/></description></item>
    ///     <item><description><see cref="DeputyRequestAddressee.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestAddressee.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestAddressee.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new DeputyRequestAddressee { Name = "name" }.ToString());
    }
  }
}