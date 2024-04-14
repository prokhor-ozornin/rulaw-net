using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Instance"/>.</para>
/// </summary>
public sealed class InstanceTest : ClassTest<Instance>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Instance()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Instance).Should().BeDerivedFrom<object>().And.Implement<IInstance>();

    var instance = new Instance();
    instance.Id.Should().BeNull();
    instance.Name.Should().BeNull();
    instance.Active.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Instance { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Instance { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property()
  {
    new Instance { Active = true }.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.CompareTo(IInstance)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Instance.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Instance.Equals(IInstance)"/></description></item>
  ///     <item><description><see cref="Instance.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Instance.Id), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Instance.Id), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Instance.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Instance {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Instance
      {
        Id = 1,
        Active = true,
        Name = "name"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}