using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawsSearchResult"/>.</para>
/// </summary>
public sealed class LawsSearchResultTest : ClassTest<LawsSearchResult>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawsSearchResult()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawsSearchResult).Should().BeDerivedFrom<object>().And.Implement<ILawsSearchResult>();

    var result = new LawsSearchResult();
    result.Page.Should().BeNull();
    result.Count.Should().BeNull();
    result.Wording.Should().BeNull();
    result.Laws.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property()
  {
    new LawsSearchResult { Page = int.MaxValue }.Page.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property()
  {
    new LawsSearchResult { Count = int.MaxValue }.Count.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Wording"/> property.</para>
  /// </summary>
  [Fact]
  public void Wording_Property()
  {
    new LawsSearchResult { Wording = Guid.Empty.ToString() }.Wording.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsSearchResult.Laws"/> property.</para>
  /// </summary>
  [Fact]
  public void Laws_Property()
  {
    var result = new LawsSearchResult();
    var law = new Law();

    var laws = result.Laws.To<List<ILaw>>();

    laws.Add(law);
    result.Laws.Should().ContainSingle().Which.Should().BeSameAs(law);

    laws.Remove(law);
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
  public void ToString_Method()
  {
    new LawsSearchResult {Wording = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new LawsSearchResult
      {
        Page = 3,
        Count = 2,
        Wording = "wording",
        Laws = [new Law { Id = 1 }]
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}