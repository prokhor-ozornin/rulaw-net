using System;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="VotesSearchLawApiCall"/>.</para>
  /// </summary>
  public sealed class VotesSearchLawApiCallTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="VotesSearchLawApiCall()"/>
    [Fact]
    public void Constructors()
    {
      var call = new VotesSearchLawApiCall();
      Assert.Empty(call.Parameters);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.Convocation(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void Convocation_Method()
    {
      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("convocation"));
      Assert.True(ReferenceEquals(call, call.Convocation(1)));
      Assert.Equal((long)1, call.Parameters["convocation"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.From(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void From_Method()
    {
      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("from"));
      Assert.True(ReferenceEquals(call, call.From(DateTime.MinValue)));
      Assert.Equal(DateTime.MinValue.RuLawDate(), call.Parameters["from"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.To(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void To_Method()
    {
      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("to"));
      Assert.True(ReferenceEquals(call, call.To(DateTime.MinValue)));
      Assert.Equal(DateTime.MinValue.RuLawDate(), call.Parameters["to"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.Faction(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void Faction_Method()
    {
      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("faction"));
      Assert.True(ReferenceEquals(call, call.Faction(1)));
      Assert.Equal((long)1, call.Parameters["faction"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.Deputy(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deputy_Method()
    {
      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("deputy"));
      Assert.True(ReferenceEquals(call, call.Deputy(1)));
      Assert.Equal((long)1, call.Parameters["deputy"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.Number(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Number_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new VotesSearchLawApiCall().Number(null));
      Assert.Throws<ArgumentException>(() => new VotesSearchLawApiCall().Number(string.Empty));

      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("number"));
      Assert.True(ReferenceEquals(call, call.Number("number")));
      Assert.Equal("number", call.Parameters["number"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.Keywords(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Keywords_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new VotesSearchLawApiCall().Keywords(null));
      Assert.Throws<ArgumentException>(() => new VotesSearchLawApiCall().Keywords(string.Empty));

      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("keywords"));
      Assert.True(ReferenceEquals(call, call.Keywords("keywords")));
      Assert.Equal("keywords", call.Parameters["keywords"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.Page(int)"/> method.</para>
    /// </summary>
    [Fact]
    public void Page_Method()
    {
      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("page"));
      Assert.True(ReferenceEquals(call, call.Page(1)));
      Assert.Equal(1, call.Parameters["page"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.Limit(PageSize)"/> method.</para>
    /// </summary>
    [Fact]
    public void Limit_Method()
    {
      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("limit"));
      Assert.True(ReferenceEquals(call, call.Limit(PageSize.Five)));
      Assert.Equal(5, call.Parameters["limit"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesSearchLawApiCall.Sorting(VotesSorting)"/> method.</para>
    /// </summary>
    [Fact]
    public void Sorting_Method()
    {
      var call = new VotesSearchLawApiCall();
      Assert.False(call.Parameters.ContainsKey("sort"));
      Assert.True(ReferenceEquals(call, call.Sorting(VotesSorting.DateAscending)));
      Assert.Equal("date_asc", call.Parameters["sort"]);
      Assert.Equal("date_desc_true", call.Sorting(VotesSorting.DateDescending).Parameters["sort"]);
      Assert.Equal("date_desc", call.Sorting(VotesSorting.DateDescendingByDay).Parameters["sort"]);
      Assert.Equal("result_asc", call.Sorting(VotesSorting.ResultAscending).Parameters["sort"]);
      Assert.Equal("result_desc", call.Sorting(VotesSorting.ResultDescending).Parameters["sort"]);
    }
  }
}