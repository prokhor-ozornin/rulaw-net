using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Committee"/>.</para>
/// </summary>
public sealed class CommitteeTest : ClassTest<Committee>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Committee(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Committee(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property() { new Committee(new {Active = true}).Active.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property() { new Committee(new {FromDate = DateTimeOffset.MaxValue}).FromDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new Committee(new {ToDate = DateTimeOffset.MaxValue}).ToDate.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Committee(long?, string?, bool?, DateTimeOffset?, DateTimeOffset?)"/>
  /// <seealso cref="Committee(Committee.Info)"/>
  /// <seealso cref="Committee(object)"/>
  [Fact]
  public void Constructors()
  {
    var committee = new Committee();
    committee.Id.Should().BeNull();
    committee.Name.Should().BeNull();
    committee.Active.Should().BeNull();
    committee.FromDate.Should().BeNull();
    committee.ToDate.Should().BeNull();

    committee = new Committee(new Committee.Info());
    committee.Id.Should().BeNull();
    committee.Name.Should().BeNull();
    committee.Active.Should().BeNull();
    committee.FromDate.Should().BeNull();
    committee.ToDate.Should().BeNull();

    committee = new Committee(new {});
    committee.Id.Should().BeNull();
    committee.Name.Should().BeNull();
    committee.Active.Should().BeNull();
    committee.FromDate.Should().BeNull();
    committee.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.CompareTo(ICommittee)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Committee.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Committee.Equals(ICommittee)"/></description></item>
  ///     <item><description><see cref="Committee.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Committee.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Committee.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Committee(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="Committee.Info"/>.</para>
/// </summary>
public sealed class CommitteeInfoTests : ClassTest<Committee.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Committee.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Committee.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Info.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property() { new Committee.Info {Active = true}.Active.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Info.FromDate"/> property.</para>
  /// </summary>
  [Fact]
  public void FromDate_Property() { new Committee.Info {FromDate = Guid.Empty.ToString()}.FromDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Info.ToDate"/> property.</para>
  /// </summary>
  [Fact]
  public void ToDate_Property() { new Committee.Info {ToDate = Guid.Empty.ToString()}.ToDate.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Committee.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new Committee.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.Active.Should().BeNull();
    info.FromDate.Should().BeNull();
    info.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Committee.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new Committee.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<Committee>();
      result.Id.Should().NotBeNull();
      result.Name.Should().NotBeNull();
      result.Active.Should().NotBeNull();
      result.FromDate.Should().NotBeNull();
      result.ToDate.Should().NotBeNull();
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
      Validate(new Committee.Info
      {
        Id = 1,
        Active = true,
        FromDate = DateTimeOffset.MinValue.AsString(),
        Name = "name",
        ToDate = DateTimeOffset.MaxValue.AsString()
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}