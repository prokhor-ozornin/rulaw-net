using System.Xml.Serialization;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="NameableEntity{ENTITY}"/>.</para>
  /// </summary>
  public sealed class NameableEntityTests : UnitTestsBase<MockNameableEntity>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var entity = new MockNameableEntity();
      this.TestJson(entity, new { id = 0 });

      entity = new MockNameableEntity
      {
        Id = 1,
        Name = "name"
      };
      this.TestJson(entity, new { id = 1, name = "name" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var entity = new MockNameableEntity();
      this.TestXml(entity, "entity", new { id = 0 });

      entity = new MockNameableEntity
      {
        Id = 1,
        Name = "name"
      };
      this.TestXml(entity, "entity", new { id = 1, name = "name" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="NameableEntity{ENTITY}()"/>
    [Fact]
    public void Constructors()
    {
      var entity = new MockNameableEntity();
      Assert.Equal(0, entity.Id);
      Assert.Null(entity.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="NameableEntity{ENTITY}.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Topic { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="NameableEntity{ENTITY}.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new MockNameableEntity { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="NameableEntity{ENTITY}.CompareTo(NameableEntity{ENTITY})"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="NameableEntity{ENTITY}.Equals(NameableEntity{ENTITY})"/></description></item>
    ///     <item><description><see cref="NameableEntity{ENTITY}.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="NameableEntity{ENTITY}.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="NameableEntity{ENTITY}.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new MockNameableEntity { Name = "name" }.ToString());
    }
  }

  [XmlType("entity")]
  public sealed class MockNameableEntity : NameableEntity<MockNameableEntity>
  {
  }
}