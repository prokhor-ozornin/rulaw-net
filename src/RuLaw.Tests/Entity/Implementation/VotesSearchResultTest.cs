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
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="VotesSearchResult()"/>
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
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Page"/> property.</para>
  /// </summary>
  [Fact]
  public void Page_Property()
  {
    new VotesSearchResult { Page = int.MaxValue }.Page.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.PageSize"/> property.</para>
  /// </summary>
  [Fact]
  public void PageSize_Property()
  {
    new VotesSearchResult { PageSize = int.MaxValue }.PageSize.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property()
  {
    new VotesSearchResult { Count = int.MaxValue }.Count.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Wording"/> property.</para>
  /// </summary>
  [Fact]
  public void Wording_Property()
  {
    new VotesSearchResult { Wording = Guid.Empty.ToString() }.Wording.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchResult.Votes"/> property.</para>
  /// </summary>
  [Fact]
  public void Votes_Property()
  {
    var search = new VotesSearchResult();
    var vote = new Vote();

    var votes = search.Votes.To<List<Vote>>();
    votes.Add(vote);
    search.Votes.Should().ContainSingle().Which.Should().BeSameAs(vote);

    votes.Remove(vote);
    search.Votes.Should().BeEmpty();
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
    new VotesSearchResult {Wording = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of JSON serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization_Json()
  {
    using (new AssertionScope())
    {
      Validate(new Vote
      {
        Id = 1,
        AbsentVotesCount = 1,
        AbstainVotesCount = 2,
        AgainstVotesCount = 3,
        Date = DateTimeOffset.MinValue,
        ForVotesCount = 4,
        PersonResult = "personResult",
        Subject = "subject",
        Successful = true,
        TotalVotesCount = 5,
        ResultType = "type"
      });
    }

    return;

    var info = new VotesSearchResult
    {
      Page = 1,
      PageSize = 2,
      Count = 3,
      Wording = "wording",
      Votes = [new Vote()]
    };

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}