using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawEventDocument"/>.</para>
  /// </summary>
  public sealed class LawEventDocumentTests : UnitTestsBase<LawEventDocument>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new LawEventDocument(), new { });
      this.TestJson(
        new LawEventDocument
        {
          Name = "name",
          Type = "type"
        },
        new { name = "name", type = "type" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(
        new LawEventDocument
        {
          Name = "name",
          Type = "type"
        },
        "document",
        new { name = "name", type = "type" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawEventDocument()"/>
    [Fact]
    public void Constructors()
    {
      var document = new LawEventDocument();
      Assert.Null(document.Name);
      Assert.Null(document.Type);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEventDocument.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new LawEventDocument { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEventDocument.Type"/> property.</para>
    /// </summary>
    [Fact]
    public void Type_Property()
    {
      Assert.Equal("type", new LawEventDocument { Type = "type" }.Type);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEventDocument.CompareTo(LawEventDocument)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="LawEventDocument.Equals(LawEventDocument)"/></description></item>
    ///     <item><description><see cref="LawEventDocument.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEventDocument.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawEventDocument.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new LawEventDocument { Name = "name" }.ToString());
    }
  }
}