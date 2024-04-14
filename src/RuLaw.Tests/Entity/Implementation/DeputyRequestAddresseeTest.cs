using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyRequestAddressee"/>.</para>
/// </summary>
public sealed class DeputyRequestAddresseeTest : ClassTest<DeputyRequestAddressee>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyRequestAddressee()"/>
  [Fact]
  public void Constructors()
  {
    typeof(DeputyRequestAddressee).Should().BeDerivedFrom<object>().And.Implement<IDeputyRequestAddressee>();

    var addressee = new DeputyRequestAddressee();
    addressee.Id.Should().BeNull();
    addressee.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestAddressee.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new DeputyRequestAddressee { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestAddressee.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new DeputyRequestAddressee { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestAddressee.CompareTo(IDeputyRequestAddressee)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(DeputyRequestAddressee.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="DeputyRequestAddressee.Equals(IDeputyRequestAddressee)"/></description></item>
  ///     <item><description><see cref="DeputyRequestAddressee.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(DeputyRequestAddressee.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestAddressee.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(DeputyRequestAddressee.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyRequestAddressee.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new DeputyRequestAddressee {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new DeputyRequestAddressee
      {
        Id = 1,
        Name = "name"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}