using System.Runtime.Serialization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Topic"/>.</para>
/// </summary>
public sealed class TopicTest : ClassTest<Topic>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Topic(long?, string?)"/>
  /// <seealso cref="Topic(Topic.Info)"/>
  /// <seealso cref="Topic(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(Topic).Should().BeDerivedFrom<object>().And.Implement<ITopic>();

    var topic = new Topic();
    topic.Id.Should().BeNull();
    topic.Name.Should().BeNull();

    topic = new Topic(new Topic.Info());
    topic.Id.Should().BeNull();
    topic.Name.Should().BeNull();

    topic = new Topic(new {});
    topic.Id.Should().BeNull();
    topic.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Topic(new
    {
      Id = long.MaxValue
    }).Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Topic(new
    {
      Name = Guid.Empty.ToString()
    }).Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.CompareTo(ITopic)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Topic.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Topic.Equals(ITopic)"/></description></item>
  ///     <item><description><see cref="Topic.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Topic.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Topic.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Topic(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="Topic.Info"/>.</para>
/// </summary>
public sealed class TopicInfoTests : ClassTest<Topic.Info>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Topic.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Topic.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<ITopic>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new Topic.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Topic.Info { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Topic.Info { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new Topic.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<Topic>();
      result.Id.Should().BeNull();
      result.Name.Should().BeNull();
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Topic.Info
      {
        Id = 1,
        Name = "name"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}