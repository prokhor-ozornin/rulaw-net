using System.Runtime.Serialization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyActivity"/>.</para>
/// </summary>
public sealed class DeputyActivityTest : ClassTest<DeputyActivity>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Education(new {Institution = Guid.Empty.ToString()}).Institution.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.CommitteeId"/> property.</para>
  /// </summary>
  [Fact]
  public void CommitteeId_Property() { new DeputyActivity(new {CommitteeId = long.MaxValue}).CommitteeId.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.CommitteeNameGenitive"/> property.</para>
  /// </summary>
  [Fact]
  public void CommitteeNameGenitive_Property() { new DeputyActivity(new {CommitteeNameGenitive = Guid.Empty.ToString()}).CommitteeNameGenitive.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyActivity(string?, long?, string?)"/>
  /// <seealso cref="DeputyActivity(DeputyActivity.Info)"/>
  /// <seealso cref="DeputyActivity(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(DeputyActivity).Should().BeDerivedFrom<object>().And.Implement<IDeputyActivity>();

    var activity = new DeputyActivity();
    activity.Name.Should().BeNull();
    activity.CommitteeId.Should().BeNull();
    activity.CommitteeNameGenitive.Should().BeNull();

    activity = new DeputyActivity(new DeputyActivity.Info());
    activity.Name.Should().BeNull();
    activity.CommitteeId.Should().BeNull();
    activity.CommitteeNameGenitive.Should().BeNull();

    activity = new DeputyActivity(new {});
    activity.Name.Should().BeNull();
    activity.CommitteeId.Should().BeNull();
    activity.CommitteeNameGenitive.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.CompareTo(IDeputyActivity)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo("Name", "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="DeputyActivity.Equals(IDeputyActivity)"/></description></item>
  ///     <item><description><see cref="DeputyActivity.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(DeputyActivity.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(DeputyActivity.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new DeputyActivity(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="DeputyActivity.Info"/>.</para>
/// </summary>
public sealed class DeputyActivityInfoTests : ClassTest<DeputyActivity.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Education.Info {Institution = Guid.Empty.ToString()}.Institution.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.Info.CommitteeId"/> property.</para>
  /// </summary>
  [Fact]
  public void CommitteeId_Property() { new DeputyActivity.Info {CommitteeId = long.MaxValue}.CommitteeId.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.Info.CommitteeNameGenitive"/> property.</para>
  /// </summary>
  [Fact]
  public void CommitteeNameGenitive_Property() { new DeputyActivity.Info {CommitteeNameGenitive = Guid.Empty.ToString()}.CommitteeNameGenitive.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyActivity.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(DeputyActivity.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IDeputyActivity>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new DeputyActivity.Info();
    info.Name.Should().BeNull();
    info.CommitteeId.Should().BeNull();
    info.CommitteeNameGenitive.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyActivity.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new DeputyActivity.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<DeputyActivity>();
      result.Name.Should().BeNull();
      result.CommitteeId.Should().BeNull();
      result.CommitteeNameGenitive.Should().BeNull();
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
      Validate(new DeputyActivity.Info
      {
        CommitteeId = 1,
        CommitteeNameGenitive = "committeeNameGenitive",
        Name = "name"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}