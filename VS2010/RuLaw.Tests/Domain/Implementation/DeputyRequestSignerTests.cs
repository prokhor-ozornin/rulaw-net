using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyRequestSigner"/>.</para>
  /// </summary>
  public sealed class DeputyRequestSignerTests : UnitTestsBase<DeputyRequestSigner>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new DeputyRequestSigner(), new { id = 0 } );
      this.TestJson(
        new DeputyRequestSigner
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
      this.TestXml(new DeputyRequestSigner(), "signedBy", new { id = 0 });
      this.TestXml(
        new DeputyRequestSigner
        {
          Id = 1,
          Name = "name"
        },
        "signedBy",
        new { id = 1, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputyRequestSigner()"/>
    [Fact]
    public void Constructors()
    {
      var signer = new DeputyRequestSigner();
      Assert.Equal(0, signer.Id);
      Assert.Null(signer.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestSigner.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new DeputyRequestSigner { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestSigner.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new DeputyRequestSigner { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestSigner.CompareTo(IDeputyRequestSigner)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DeputyRequestSigner.Equals(IDeputyRequestSigner)"/></description></item>
    ///     <item><description><see cref="DeputyRequestSigner.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestSigner.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyRequestSigner.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new DeputyRequestSigner { Name = "name" }.ToString());
    }
  }
}