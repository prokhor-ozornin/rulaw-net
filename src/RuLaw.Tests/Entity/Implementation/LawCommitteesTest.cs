using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawCommittees"/>.</para>
/// </summary>
public sealed class LawCommitteesTest : ClassTest<LawCommittees>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawCommittees.Responsible"/> property.</para>
  /// </summary>
  [Fact]
  public void Responsible_Property()
  {
    var committee = new Committee(new {});
    new LawCommittees(new {Responsible = committee}).Responsible.Should().BeSameAs(committee);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawCommittees.Profile"/> property.</para>
  /// </summary>
  [Fact]
  public void Profile_Property()
  {
    var lawCommittees = new LawCommittees(new {});
    lawCommittees.Profile.Should().BeEmpty();

    var committee = new Committee(new {});

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
    var lawCommittees = new LawCommittees(new {});
    lawCommittees.SoExecutor.Should().BeEmpty();

    var committee = new Committee(new {});

    var committees = lawCommittees.SoExecutor.To<List<Committee>>();

    committees.Add(committee);
    lawCommittees.SoExecutor.Should().ContainSingle().Which.Should().BeSameAs(committee);
    committees.Remove(committee);
    lawCommittees.SoExecutor.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawCommittees(ICommittee?, IEnumerable{ICommittee}?, IEnumerable{ICommittee}?)"/>
  /// <seealso cref="LawCommittees(LawCommittees.Info)"/>
  /// <seealso cref="LawCommittees(object)"/>
  [Fact]
  public void Constructors()
  {
    var committees = new LawCommittees();
    committees.Responsible.Should().BeNull();
    committees.Profile.Should().BeEmpty();
    committees.SoExecutor.Should().BeEmpty();

    committees = new LawCommittees(new LawCommittees.Info());
    committees.Responsible.Should().BeNull();
    committees.Profile.Should().BeEmpty();
    committees.SoExecutor.Should().BeEmpty();

    committees = new LawCommittees(new {});
    committees.Responsible.Should().BeNull();
    committees.Profile.Should().BeEmpty();
    committees.SoExecutor.Should().BeEmpty();
  }
}

/// <summary>
///   <para>Tests set for class <see cref="LawCommittees.Info"/>.</para>
/// </summary>
public sealed class LawCommitteesInfoTests : ClassTest<LawCommittees.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawCommittees.Info.Responsible"/> property.</para>
  /// </summary>
  [Fact]
  public void Responsible_Property()
  {
    var responsible = new Committee(new {});
    new LawCommittees.Info {Responsible = responsible}.Responsible.Should().BeSameAs(responsible);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawCommittees.Info.Profile"/> property.</para>
  /// </summary>
  [Fact]
  public void Profile_Property()
  {
    var profile = new List<Committee>();
    new LawCommittees.Info {Profile = profile}.Profile.Should().BeSameAs(profile);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawCommittees.Info.SoExecutor"/> property.</para>
  /// </summary>
  [Fact]
  public void SoExecutor_Property()
  {
    var soExecutor = new List<Committee>();
    new LawCommittees.Info {SoExecutor = soExecutor}.SoExecutor.Should().BeSameAs(soExecutor);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawCommittees.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new LawCommittees.Info();
    info.Responsible.Should().BeNull();
    info.Profile.Should().BeNull();
    info.SoExecutor.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawCommittees.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new LawCommittees.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<LawCommittees>();
      result.Responsible.Should().BeNull();
      result.Profile.Should().BeNull();
      result.SoExecutor.Should().BeNull();
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
    var info = new LawCommittees.Info
    {
      Responsible = new Committee(new {Id = 1}),
      Profile = new List<Committee> {new(new {Id = 2})},
      SoExecutor = new List<Committee> {new(new {Id = 3})}
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}