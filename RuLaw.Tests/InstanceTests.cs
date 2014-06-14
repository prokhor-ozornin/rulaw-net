using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Instance"/>.</para>
  /// </summary>
  public sealed class InstanceTests : UnitTestsBase<Instance>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new Instance(), new { id = 0, isCurrent = false });
      this.TestJson(
        new Instance
        {
          Id = 1,
          Active = true,
          Name = "name"
        },
        new { id = 1, isCurrent = true, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new Instance(), "instance", new { id = 0, isCurrent = false });
      this.TestXml(
        new Instance
        {
          Id = 1,
          Active = true,
          Name = "name"
        },
        "instance",
        new { id = 1, isCurrent = true, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Instance()"/>
    [Fact]
    public void Constructors()
    {
      var instance = new Instance();
      Assert.Equal(0, instance.Id);
      Assert.False(instance.Active);
      Assert.Null(instance.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Instance.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Instance { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Instance.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new Instance { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Instance.Active"/> property.</para>
    /// </summary>
    [Fact]
    public void Active_Property()
    {
      Assert.True(new Instance { Active = true }.Active);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Instance.CompareTo(Instance)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Instance.Equals(Instance)"/></description></item>
    ///     <item><description><see cref="Instance.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Instance.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Instance.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Instance { Name = "name" }.ToString());
    }
  }
}