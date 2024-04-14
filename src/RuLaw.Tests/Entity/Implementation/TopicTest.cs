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
  /// <seealso cref="Topic()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Topic).Should().BeDerivedFrom<object>().And.Implement<ITopic>();

    var topic = new Topic();
    topic.Id.Should().BeNull();
    topic.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Topic { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Topic.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Topic { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
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
    new Topic {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Topic
      {
        Id = 1,
        Name = "name"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}