using System;
using System.Configuration;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="VotesApiCaller"/>.</para>
  /// </summary>
  public sealed class VotesApiCallerTests
  {
    private readonly IApiCaller xmlApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Xml));
    private readonly IApiCaller jsonApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Json));

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="TranscriptsApiCaller(IApiCaller)"/>
    [Fact]
    public void Constructors()
    {
      Assert.Throws<ArgumentNullException>(() => new VotesApiCaller(null));

      var apiCaller = RuLaw.API(api => api.ApiKey("apiKey").AppKey("appKey"));
      var caller = new VotesApiCaller(apiCaller);
      Assert.True(ReferenceEquals(apiCaller, caller.Api));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VotesApiCaller.Search(long?, DateTime?, DateTime?, long?, long?, string, string, int?, PageSize?, VotesSorting?)"/> method.</para>
    /// </summary>
    [Fact]
    public void Search_Method()
    {
      this.TestVoteSearchResult(this.xmlApiCaller.Votes().Search(from: DateTime.UtcNow.Subtract(TimeSpan.FromDays(180)), to : DateTime.UtcNow), this.xmlApiCaller.Votes().Search(from: new DateTime(2011, 12, 21), to : new DateTime(2011, 12, 31), deputy: 99111987));
      this.TestVoteSearchResult(this.jsonApiCaller.Votes().Search(from: DateTime.UtcNow.Subtract(TimeSpan.FromDays(180)), to : DateTime.UtcNow), this.xmlApiCaller.Votes().Search(from: new DateTime(2011, 12, 21), to : new DateTime(2011, 12, 31), deputy: 99111987));
    }

    private void TestVoteSearchResult(IVotesSearchResult factionResult, IVotesSearchResult deputyResult)
    {
      Assertion.NotNull(factionResult);
      Assertion.NotNull(deputyResult);

      Assert.True(factionResult.Count > 0);
      Assert.Equal(20, factionResult.PageSize);
      Assert.NotEmpty(factionResult.Wording);

      Assert.NotEmpty(factionResult.Votes);
      var vote = factionResult.Votes.First();
      Assert.NotEmpty(vote.Subject);
      Assert.True(vote.Date <= DateTime.UtcNow);
      Assert.True(vote.TotalVotesCount > 0);
    }
  }
}