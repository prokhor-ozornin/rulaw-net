using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawBranch"/>.</para>
/// </summary>
public sealed class LawBranchTest : ClassTest<LawBranch>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new LawBranch(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawBranch(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawBranch(long?, string?)"/>
  /// <seealso cref="LawBranch(LawBranch.Info)"/>
  /// <seealso cref="LawBranch(object)"/>
  [Fact]
  public void Constructors()
  {
    var topic = new LawBranch();
    topic.Id.Should().BeNull();
    topic.Name.Should().BeNull();

    topic = new LawBranch(new LawBranch.Info());
    topic.Id.Should().BeNull();
    topic.Name.Should().BeNull();

    topic = new LawBranch(new {});
    topic.Id.Should().BeNull();
    topic.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.CompareTo(ILawBranch)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawBranch.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="LawBranch.Equals(ILawBranch)"/></description></item>
  ///     <item><description><see cref="LawBranch.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(LawBranch.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(LawBranch.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new LawBranch(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="LawBranch.Info"/>.</para>
/// </summary>
public sealed class LawBranchInfoTests : ClassTest<LawBranch.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new LawBranch.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new LawBranch.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawBranch.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new LawBranch.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new LawBranch.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<LawBranch>();
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
      Validate(new LawBranch.Info
      {
        Id = 1,
        Name = "name"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}