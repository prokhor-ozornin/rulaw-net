using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyRequestAddressee"/>.</para>
  /// </summary>
  public sealed class DeputyRequestAddresseeTests : UnitTestsBase<DeputyRequestAddressee>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new DeputyRequestAddressee(), new { id = 0 } );
      TestJson(
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
      TestXml(new DeputyRequestAddressee(), "addressee", new { id = 0 });
      TestXml(
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
    ///   <para>Performs testing of <see cref="DeputyRequestAddressee.CompareTo(IDeputyRequestAddressee)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DeputyRequestAddressee.Equals(IDeputyRequestAddressee)"/></description></item>
    ///     <item><description><see cref="DeputyRequestAddressee.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestAddressee.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      TestHashCode("Id", 1, 2);
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