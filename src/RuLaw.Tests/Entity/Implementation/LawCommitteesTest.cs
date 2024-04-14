using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawCommittees"/>.</para>
/// </summary>
public sealed class LawCommitteesTest : ClassTest<LawCommittees>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawCommittees()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawCommittees).Should().BeDerivedFrom<object>().And.Implement<ILawCommittees>();

    var committees = new LawCommittees();
    committees.Responsible.Should().BeNull();
    committees.Profile.Should().BeEmpty();
    committees.SoExecutor.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawCommittees.Responsible"/> property.</para>
  /// </summary>
  [Fact]
  public void Responsible_Property()
  {
    var committee = new Committee();
    new LawCommittees { Responsible = committee }.Responsible.Should().BeSameAs(committee);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawCommittees.Profile"/> property.</para>
  /// </summary>
  [Fact]
  public void Profile_Property()
  {
    var lawCommittees = new LawCommittees();
    lawCommittees.Profile.Should().BeEmpty();

    var committee = new Committee();

    var committees = lawCommittees.Profile.To<List<Committee>>();

    committees.Add(committee);
    lawCommittees.Profile.Should().ContainSingle().Which.Should().BeSameAs(committee);
    committees.Remove(committee);
    lawCommittees.Profile.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawCommittees.SoExecutor"/> property.</para>
  /// </summary>
  [Fact]
  public void SoExecutor_Property()
  {
    var lawCommittees = new LawCommittees();
    lawCommittees.SoExecutor.Should().BeEmpty();

    var committee = new Committee();

    var committees = lawCommittees.SoExecutor.To<List<Committee>>();

    committees.Add(committee);
    lawCommittees.SoExecutor.Should().ContainSingle().Which.Should().BeSameAs(committee);
    committees.Remove(committee);
    lawCommittees.SoExecutor.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new LawCommittees
    {
      Responsible = new Committee { Id = 1 },
      Profile = [new Committee { Id = 2 }],
      SoExecutor = [new Committee { Id = 3 }]
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}