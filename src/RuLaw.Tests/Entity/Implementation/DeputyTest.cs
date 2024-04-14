using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Deputy"/>.</para>
/// </summary>
public sealed class DeputyTest : ClassTest<Deputy>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Deputy()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Deputy).Should().BeDerivedFrom<object>().And.Implement<IDeputy>();

    var deputy = new Deputy();
    deputy.Id.Should().BeNull();
    deputy.Name.Should().BeNull();
    deputy.Active.Should().BeNull();
    deputy.Position.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Deputy.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Deputy { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Deputy.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Deputy { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Deputy.Active"/> property.</para>
  /// </summary>
  [Fact]
  public void Active_Property()
  {
    new Deputy { Active = true }.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Deputy.Position"/> property.</para>
  /// </summary>
  [Fact]
  public void Position_Property()
  {
    new Deputy { Position = Guid.Empty.ToString() }.Position.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Deputy.CompareTo(IDeputy)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Deputy.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Deputy.Equals(IDeputy)"/></description></item>
  ///     <item><description><see cref="Deputy.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Deputy.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Deputy.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Deputy.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Deputy.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Deputy {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Deputy
      {
        Id = 1,
        Active = true,
        Name = "name",
        Position = "position"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}