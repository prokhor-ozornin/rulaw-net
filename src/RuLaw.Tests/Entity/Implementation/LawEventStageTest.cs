using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawEventStage"/>.</para>
/// </summary>
public sealed class LawEventStageTest : ClassTest<LawEventStage>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEventStage()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawEventStage).Should().BeDerivedFrom<object>().And.Implement<ILawEventStage>();

    var stage = new LawEventStage();
    stage.Id.Should().BeNull();
    stage.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventStage.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new LawEventStage { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventStage.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new LawEventStage { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventStage.CompareTo(ILawEventStage)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawEventStage.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="LawEventStage.Equals(ILawEventStage)"/></description></item>
  ///     <item><description><see cref="LawEventStage.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(LawEventStage.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventStage.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(LawEventStage.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventStage.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new LawEventStage {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new LawEventStage
      {
        Id = 1,
        Name = "name"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}