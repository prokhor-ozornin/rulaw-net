using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IVotesApiCallerExtensions"/>.</para>
  /// </summary>
  public sealed class IVotesApiCallerExtensionsTests
  {
    private readonly IApiCaller xmlApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Xml));
    private readonly IApiCaller jsonApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Json));
    
    /// <summary>
    ///   <para>Performs testing of <see cref="ITranscriptsApiCallerExtensions.Deputy(ITranscriptsApiCaller, Action{IDeputyTranscriptLawApiCall})"/> method.</para>
    /// </summary>
    [Fact]
    public void Search_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IVotesApiCallerExtensions.Search(null, call => { }));

      this.TestVoteSearchResult(this.xmlApiCaller.Votes().Search(call => call.From(new DateTime(2011, 12, 21))),
                                this.xmlApiCaller.Votes().Search(call => call.From(new DateTime(2011, 12, 21)).Deputy(99111987)));

      this.TestVoteSearchResult(this.jsonApiCaller.Votes().Search(call => call.From(new DateTime(2011, 12, 21))),
                                this.jsonApiCaller.Votes().Search(call => call.From(new DateTime(2011, 12, 21)).Deputy(99111987)));
    }

    private void TestVoteSearchResult(VotesSearchResult factionResult, VotesSearchResult deputyResult)
    {
      Assertion.NotNull(factionResult);
      Assertion.NotNull(deputyResult);

      Assert.True(factionResult.Count > 0);
      Assert.Equal(20, factionResult.PageSize);
      Assert.Equal("Результаты голосования по вопросам, вынесенным для открытого голосования за период с 21.12.2011 по текущую дату.", factionResult.Wording);
      Assert.True(factionResult.Votes.Any());
      var vote = factionResult.Votes.Single(x => x.Id == 86474);
      Assert.False(vote.Personal);
      Assert.Null(vote.GetPersonResult());
      Assert.True(vote.Successful);
      Assert.Equal("(Предложение деп. Русских) О проекте порядка работы Государственной Думы на 23 мая 2014 года", vote.Subject);
      Assert.Equal(VoteResultType.Quantitative, vote.GetResultType());
      Assert.Equal(new DateTime(2014, 5, 23, 10, 47, 10), vote.Date);
      Assert.Equal(378, vote.TotalVotesCount);
      Assert.Equal(327, vote.ForVotesCount);
      Assert.Equal(51, vote.AgainstVotesCount);
      Assert.Equal(0, vote.AbstainVotesCount);
      Assert.Equal(72, vote.AbsentVotesCount);

      Assert.True(deputyResult.Count > 0);
      Assert.Equal(20, deputyResult.PageSize);
      Assert.Equal("Результаты голосования депутата Агаев Ваха Абуевич по вопросам, вынесенным для открытого голосования за период с 21.12.2011 по текущую дату.", deputyResult.Wording);
      Assert.True(deputyResult.Votes.Any());
      vote = deputyResult.Votes.Single(x => x.Id == 86473);
      Assert.True(vote.Personal);
      Assert.True(vote.Successful);
      Assert.Equal("(за основу) О проекте порядка работы Государственной Думы на 23 мая 2014 года", vote.Subject);
      Assert.Equal(VotePersonResult.For, vote.GetPersonResult());
      Assert.Equal(VoteResultType.Quantitative, vote.GetResultType());
      Assert.Equal(new DateTime(2014, 5, 23, 10, 1, 6), vote.Date);
      Assert.Null(vote.TotalVotesCount);
      Assert.Null(vote.ForVotesCount);
      Assert.Null(vote.AgainstVotesCount);
      Assert.Null(vote.AbstainVotesCount);
      Assert.Null(vote.AbsentVotesCount);
    }
  }
}