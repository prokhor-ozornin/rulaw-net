using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawBranch"/>.</para>
  /// </summary>
  public sealed class LawBranchTests : UnitTestsBase<LawBranch>
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
      this.TestJson(new LawBranch(), new { id = 0 });
      this.TestJson(new LawBranch { Id = 1, Name = "name" }, new { id = 1, name = "name" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new LawBranch(), "class", new { id = 0 });
      this.TestXml(new LawBranch { Id = 1, Name = "name" }, "class", new { id = 1, name = "name" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawBranch()"/>
    [Fact]
    public void Constructors()
    {
      var topic = new LawBranch();
      Assert.Equal(0, topic.Id);
      Assert.Null(topic.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawBranch.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new LawBranch { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawBranch.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new LawBranch { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawBranch.CompareTo(LawBranch)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="LawBranch.Equals(LawBranch)"/></description></item>
    ///     <item><description><see cref="LawBranch.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawBranch.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawBranch.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new LawBranch { Name = "name" }.ToString());
    }
  }
}