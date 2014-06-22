using System;
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
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ITranscriptsApiCallerExtensions.Deputy(ITranscriptsApiCaller, Action{IDeputyTranscriptLawApiCall})"/> method.</description></item>
    ///     <item><description><see cref="ITranscriptsApiCallerExtensions.Deputy(ITranscriptsApiCaller, Action{IDeputyTranscriptLawApiCall}, out DeputyTranscriptsResult)"/> method.</description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Search_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IVotesApiCallerExtensions.Search(null, call => { }));

      VotesSearchResult factionResult, deputyResult;

      var factionResultCall = (Action<IVotesSearchLawApiCall>) (call => call.From(new DateTime(2011, 12, 21)).To(new DateTime(2011, 12, 31)));
      var deputyResultCall = (Action<IVotesSearchLawApiCall>) (call => call.From(new DateTime(2011, 12, 21)).To(new DateTime(2011, 12, 31)).Deputy(99111987));

      this.TestVoteSearchResult(this.xmlApiCaller.Votes().Search(factionResultCall), this.xmlApiCaller.Votes().Search(deputyResultCall));
      Assert.True(this.xmlApiCaller.Votes().Search(factionResultCall, out factionResult));
      Assert.True(this.xmlApiCaller.Votes().Search(deputyResultCall, out deputyResult));
      this.TestVoteSearchResult(factionResult, deputyResult);

      this.TestVoteSearchResult(this.jsonApiCaller.Votes().Search(factionResultCall), this.jsonApiCaller.Votes().Search(deputyResultCall));
      Assert.True(this.jsonApiCaller.Votes().Search(factionResultCall, out factionResult));
      Assert.True(this.jsonApiCaller.Votes().Search(deputyResultCall, out deputyResult));
      this.TestVoteSearchResult(factionResult, deputyResult);
    }

    private void TestVoteSearchResult(VotesSearchResult factionResult, VotesSearchResult deputyResult)
    {
      Assertion.NotNull(factionResult);
      Assertion.NotNull(deputyResult);

      Assert.True(factionResult.Count > 0);
      Assert.Equal(20, factionResult.PageSize);
      Assert.Equal("Результаты голосования по вопросам, вынесенным для открытого голосования за период с 21.12.2011 по 31.12.2011.", factionResult.Wording);
      Assert.Equal(17, factionResult.Votes.Count);
      var vote = factionResult.Votes.Single(x => x.Id == 75785);
      Assert.False(vote.Personal);
      Assert.Null(vote.GetPersonResult());
      Assert.True(vote.Successful);
      Assert.Equal("(за основу) О проекте порядка работы первого заседания Государственной Думы Федерального Собрания Российской Федерации шестого созыва", vote.Subject);
      Assert.Equal(VoteResultType.Quantitative, vote.GetResultType());
      Assert.Equal(new DateTime(2011, 12, 21, 12, 20, 26), vote.Date);
      Assert.Equal(421, vote.TotalVotesCount);
      Assert.Equal(421, vote.ForVotesCount);
      Assert.Equal(0, vote.AgainstVotesCount);
      Assert.Equal(0, vote.AbstainVotesCount);
      Assert.Equal(29, vote.AbsentVotesCount);

      Assert.True(deputyResult.Count > 0);
      Assert.Equal(20, deputyResult.PageSize);
      Assert.Equal("Результаты голосования депутата Агаев Ваха Абуевич по вопросам, вынесенным для открытого голосования за период с 21.12.2011 по 31.12.2011.", deputyResult.Wording);
      Assert.Equal(17, deputyResult.Votes.Count);
      vote = deputyResult.Votes.Single(x => x.Id == 75785);
      Assert.True(vote.Personal);
      Assert.True(vote.Successful);
      Assert.Equal("(за основу) О проекте порядка работы первого заседания Государственной Думы Федерального Собрания Российской Федерации шестого созыва", vote.Subject);
      Assert.Equal(VotePersonResult.For, vote.GetPersonResult());
      Assert.Equal(VoteResultType.Quantitative, vote.GetResultType());
      Assert.Equal(new DateTime(2011, 12, 21, 12, 20, 26), vote.Date);
      Assert.Null(vote.TotalVotesCount);
      Assert.Null(vote.ForVotesCount);
      Assert.Null(vote.AgainstVotesCount);
      Assert.Null(vote.AbstainVotesCount);
      Assert.Null(vote.AbsentVotesCount);
    }
  }
}