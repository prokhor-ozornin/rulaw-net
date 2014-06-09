﻿using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Topic"/>.</para>
  /// </summary>
  public sealed class TopicTests : UnitTestsBase<Topic>
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
      this.TestJson(new Topic(), new { id = 0 });
      this.TestJson(
        new Topic
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
      this.TestXml(new Topic(), "topic", new { id = 0 });
      this.TestXml(
        new Topic
        {
          Id = 1,
          Name = "name"
        },
        "topic",
        new { id = 1, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Topic()"/>
    [Fact]
    public void Constructors()
    {
      var topic = new Topic();
      Assert.Equal(0, topic.Id);
      Assert.Null(topic.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Topic.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Topic { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Topic.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new Topic { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Topic.CompareTo(Topic)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Topic.Equals(Topic)"/></description></item>
    ///     <item><description><see cref="Topic.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Topic.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Topic.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Topic { Name = "name" }.ToString());
    }
  }
}