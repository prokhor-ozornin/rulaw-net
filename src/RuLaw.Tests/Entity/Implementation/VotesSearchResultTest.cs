using System.Runtime.Serialization;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="VotesSearchResult"/>.</para>
/// </summary>
public sealed class VotesSearchResultTest : ClassTest<VotesSearchResult>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property() { new VotesSearchResult(new {Page = int.MaxValue}).Page.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.PageSize"/> property.</para>
  /// </summary>
  [Fact]
  public void PageSize_Property() { new VotesSearchResult(new {PageSize = int.MaxValue}).PageSize.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property() { new VotesSearchResult(new {Count = int.MaxValue}).Count.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Wording"/> property.</para>
  /// </summary>
  [Fact]
  public void Wording_Property() { new VotesSearchResult(new {Wording = Guid.Empty.ToString()}).Wording.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Votes"/> property.</para>
  /// </summary>
  [Fact]
  public void Votes_Property()
  {
    var search = new VotesSearchResult(new {});
    var vote = new Vote(new {});

    var votes = search.Votes.To<List<Vote>>();
    votes.Add(vote);
    search.Votes.Should().ContainSingle().Which.Should().BeSameAs(vote);

    votes.Remove(vote);
    search.Votes.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="VotesSearchResult(int?, int?, int?, string?, IEnumerable{IVote}?)"/>
  /// <seealso cref="VotesSearchResult(VotesSearchResult.Info)"/>
  /// <seealso cref="VotesSearchResult(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(VotesSearchResult).Should().BeDerivedFrom<object>().And.Implement<IVotesSearchResult>();

    var result = new VotesSearchResult();
    result.Page.Should().BeNull();
    result.PageSize.Should().BeNull();
    result.Count.Should().BeNull();
    result.Wording.Should().BeNull();
    result.Votes.Should().BeEmpty();

    result = new VotesSearchResult(new VotesSearchResult.Info());
    result.Page.Should().BeNull();
    result.PageSize.Should().BeNull();
    result.Count.Should().BeNull();
    result.Wording.Should().BeNull();
    result.Votes.Should().BeEmpty();

    result = new VotesSearchResult(new {});
    result.Page.Should().BeNull();
    result.PageSize.Should().BeNull();
    result.Count.Should().BeNull();
    result.Wording.Should().BeNull();
    result.Votes.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.CompareTo(IVotesSearchResult)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(VotesSearchResult.Count), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new VotesSearchResult(new {Wording = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="VotesSearchResult.Info"/>.</para>
/// </summary>
public sealed class VotesSearchResultInfoTests : ClassTest<VotesSearchResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Info.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property() { new VotesSearchResult.Info {Page = int.MaxValue}.Page.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Info.PageSize"/> property.</para>
  /// </summary>
  [Fact]
  public void PageSize_Property() { new VotesSearchResult.Info {PageSize = int.MaxValue}.PageSize.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Info.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property() { new VotesSearchResult.Info {Count = int.MaxValue}.Count.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Info.Wording"/> property.</para>
  /// </summary>
  [Fact]
  public void Wording_Property() { new VotesSearchResult.Info {Wording = Guid.Empty.ToString()}.Wording.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Votes"/> property.</para>
  /// </summary>
  [Fact]
  public void Votes_Property()
  {
    var votes = new List<Vote>();
    new VotesSearchResult.Info {Votes = votes}.Votes.Should().BeSameAs(votes);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="VotesSearchResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(VotesSearchResult.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IVotesSearchResult>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new VotesSearchResult.Info();
    info.Page.Should().BeNull();
    info.PageSize.Should().BeNull();
    info.Count.Should().BeNull();
    info.Wording.Should().BeNull();
    info.Votes.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new VotesSearchResult.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<VotesSearchResult>();
      result.Page.Should().BeNull();
      result.PageSize.Should().BeNull();
      result.Count.Should().BeNull();
      result.Wording.Should().BeNull();
      result.Votes.Should().BeEmpty();
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of JSON serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization_Json()
  {
    var info = new VotesSearchResult.Info
    {
      Page = 1,
      PageSize = 2,
      Count = 3,
      Wording = "wording",
      Votes = [new Vote(new { })]
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}