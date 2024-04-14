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
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawBranch()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawBranch).Should().BeDerivedFrom<object>().And.Implement<ILawBranch>();

    var topic = new LawBranch();
    topic.Id.Should().BeNull();
    topic.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new LawBranch { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawBranch.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new LawBranch { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
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
    new LawBranch {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new LawBranch
      {
        Id = 1,
        Name = "name"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}