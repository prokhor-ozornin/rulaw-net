using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="VotesSearchResult"/>.</para>
  /// </summary>
  public sealed class VotesSearchResultTests : UnitTestsBase<VotesSearchResult>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new VotesSearchResult(), new { page = 0, pageSize = 0, totalCount = 0, votes = new object[] {} });
      this.TestJson(
        new VotesSearchResult
        {
          Count = 3,
          Page = 1,
          PageSize = 2,
          Votes = new List<Vote> { new Vote() },
          Wording = "wording"
        },
        new { page = 1, pageSize = 2, totalCount = 3, votes = new object[] { new { id = 0, result = false, voteDate = DateTime.MinValue } }, wording = "wording" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new VotesSearchResult(), "result", new { page = 0, pageSize = 0, totalCount = 0 });
      this.TestXml(
        new VotesSearchResult
        {
          Count = 3,
          Page = 1,
          PageSize = 2,
          Votes = new List<Vote> { new Vote() },
          Wording = "wording"
        },
        "result",
        new { page = 1, pageSize = 2, totalCount = 3, wording = "wording" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="VotesSearchResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new VotesSearchResult();
      Assert.Equal(0, result.Count);
      Assert.Equal(0, result.Page);
      Assert.Equal(0, result.PageSize);
      Assert.False(result.Votes.Any());
      Assert.Null(result.Wording);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchResult.Count"/> property.</para>
    /// </summary>
    [Fact]
    public void Count_Property()
    {
      Assert.Equal(1, new VotesSearchResult { Count = 1 }.Count);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchResult.Page"/> property.</para>
    /// </summary>
    [Fact]
    public void Page_Property()
    {
      Assert.Equal(1, new VotesSearchResult { Page = 1 }.Page);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchResult.PageSize"/> property.</para>
    /// </summary>
    [Fact]
    public void PageSize_Property()
    {
      Assert.Equal(1, new VotesSearchResult { PageSize = 1 }.PageSize);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchResult.Votes"/> property.</para>
    /// </summary>
    [Fact]
    public void Votes_Property()
    {
      var search = new VotesSearchResult();
      var vote = new Vote();

      search.Votes.Add(vote);
      Assert.True(ReferenceEquals(search.Votes.Single(), vote));

      search.Votes.Remove(vote);
      Assert.False(search.Votes.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchResult.Wording"/> property.</para>
    /// </summary>
    [Fact]
    public void Wording_Property()
    {
      Assert.Equal("wording", new VotesSearchResult { Wording = "wording" }.Wording);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchResult.CompareTo(VotesSearchResult)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Count", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchResult.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("wording", new VotesSearchResult { Wording = "wording" }.ToString());
    }
  }
}