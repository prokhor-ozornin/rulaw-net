using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawEventPhase"/>.</para>
/// </summary>
public sealed class LawEventPhaseTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawEventPhase()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawEventPhase).Should().BeDerivedFrom<object>().And.Implement<ILawEventPhase>();

    using (new AssertionScope())
    {
      var phase = new LawEventPhase();

      phase.Id.Should().BeNull();
      phase.Name.Should().BeNull();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() => new LawEventPhase { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() => new LawEventPhase { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.CompareTo(ILawEventPhase)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() => TestCompareTo< LawEventPhase, string>(nameof(LawEventPhase.Name), "first", "second"); 

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="LawEventPhase.Equals(ILawEventPhase)"/></description></item>
  ///     <item><description><see cref="LawEventPhase.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() => TestEquality<LawEventPhase, long>(nameof(LawEventPhase.Id), 1, 2); 

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() => TestHashCode<LawEventPhase, long>(nameof(LawEventPhase.Id), 1, 2); 

  /// <summary>
  ///   <para>Performs testing of <see cref="LawEventPhase.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new LawEventPhase {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Test(new LawEventPhase
      {
        Id = 1,
        Name = "name"
      });
    }

    return;

    static void Test(ILawEventPhase instance) => instance.To<object>().Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}