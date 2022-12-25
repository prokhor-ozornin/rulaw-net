using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawsSearchResult"/>.</para>
/// </summary>
public sealed class LawsSearchResultTest : UnitTest<LawsSearchResult>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property() { new LawsSearchResult(new {Page = int.MaxValue}).Page.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property() { new LawsSearchResult(new {Count = int.MaxValue}).Count.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Wording"/> property.</para>
  /// </summary>
  [Fact]
  public void Wording_Property() { new LawsSearchResult(new {Wording = Guid.Empty.ToString()}).Wording.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Laws"/> property.</para>
  /// </summary>
  [Fact]
  public void Laws_Property()
  {
    var result = new LawsSearchResult(new {});
    var law = new Law(new {});

    var laws = result.Laws.To<List<ILaw>>();

    laws.Add(law);
    result.Laws.Should().ContainSingle().Which.Should().BeSameAs(law);

    laws.Remove(law);
    result.Laws.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawsSearchResult(int?, int?, string?, IEnumerable{ILaw}?)"/>
  /// <seealso cref="LawsSearchResult(LawsSearchResult.Info)"/>
  /// <seealso cref="LawsSearchResult(object)"/>
  [Fact]
  public void Constructors()
  {
    var result = new LawsSearchResult();
    result.Page.Should().BeNull();
    result.Count.Should().BeNull();
    result.Wording.Should().BeNull();
    result.Laws.Should().BeEmpty();

    result = new LawsSearchResult(new LawsSearchResult.Info());
    result.Page.Should().BeNull();
    result.Count.Should().BeNull();
    result.Wording.Should().BeNull();
    result.Laws.Should().BeEmpty();

    result = new LawsSearchResult(new {});
    result.Page.Should().BeNull();
    result.Count.Should().BeNull();
    result.Wording.Should().BeNull();
    result.Laws.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.CompareTo(ILawsSearchResult)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(LawsSearchResult.Count), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new LawsSearchResult(new {Wording = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="LawsSearchResult.Info"/>.</para>
/// </summary>
public sealed class LawsSearchResultInfoTests : UnitTest<LawsSearchResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Info.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property() { new LawsSearchResult.Info {Page = int.MaxValue}.Page.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Info.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property() { new LawsSearchResult.Info {Count = int.MaxValue}.Count.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Info.Wording"/> property.</para>
  /// </summary>
  [Fact]
  public void Wording_Property() { new LawsSearchResult.Info {Wording = Guid.Empty.ToString()}.Wording.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Info.Laws"/> property.</para>
  /// </summary>
  [Fact]
  public void Laws_Property()
  {
    var laws = new List<Law>();
    new LawsSearchResult.Info {Laws = laws}.Laws.Should().BeSameAs(laws);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawsSearchResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new LawsSearchResult.Info();
    info.Page.Should().BeNull();
    info.Count.Should().BeNull();
    info.Wording.Should().BeNull();
    info.Laws.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Info.Result()"/> method.</para>
  /// </summary>
  [Fact]
  public void Result_Method()
  {
    var result = new LawsSearchResult.Info().Result();
    result.Should().NotBeNull().And.BeOfType<LawsSearchResult>();
    result.Page.Should().BeNull();
    result.Count.Should().BeNull();
    result.Wording.Should().BeNull();
    result.Laws.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new LawsSearchResult.Info
    {
      Page = 3,
      Count = 2,
      Wording = "wording",
      Laws = new List<Law> {new(new {Id = 1})}
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}