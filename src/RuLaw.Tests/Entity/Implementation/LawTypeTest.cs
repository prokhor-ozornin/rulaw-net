using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawType"/>.</para>
/// </summary>
public sealed class LawTypeTest : ClassTest<LawType>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawType()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawType).Should().BeDerivedFrom<object>().And.Implement<ILawType>();

    var type = new LawType();
    type.Id.Should().BeNull();
    type.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new LawType { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new LawType { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.CompareTo(ILawType)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawType.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="LawType.Equals(ILawType)"/></description></item>
  ///     <item><description><see cref="LawType.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(LawType.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(LawType.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawType.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new LawType {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of JSON serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new LawType
      {
        Id = 1,
        Name = "name"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}