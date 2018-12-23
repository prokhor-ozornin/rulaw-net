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
    ///     <item><description><see cref="ITranscriptsApiCallerExtensions.Deputy(ITranscriptsApiCaller, Action{IDeputyTranscriptLawApiCall}, out IDeputyTranscriptsResult)"/> method.</description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Search_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IVotesApiCallerExtensions.Search(null, call => { }));

      IVotesSearchResult factionResult, deputyResult;

      var factionResultCall = (Action<IVotesSearchLawApiCall>) (call => call.From(DateTime.UtcNow.Subtract(TimeSpan.FromDays(180))).To(DateTime.UtcNow));
      var deputyResultCall = (Action<IVotesSearchLawApiCall>) (call => call.From(DateTime.UtcNow.Subtract(TimeSpan.FromDays(180))).To(DateTime.UtcNow).Deputy(99111987));

      this.TestVoteSearchResult(this.xmlApiCaller.Votes().Search(factionResultCall), this.xmlApiCaller.Votes().Search(deputyResultCall));
      Assert.True(this.xmlApiCaller.Votes().Search(factionResultCall, out factionResult));
      Assert.True(this.xmlApiCaller.Votes().Search(deputyResultCall, out deputyResult));
      this.TestVoteSearchResult(factionResult, deputyResult);

      this.TestVoteSearchResult(this.jsonApiCaller.Votes().Search(factionResultCall), this.jsonApiCaller.Votes().Search(deputyResultCall));
      Assert.True(this.jsonApiCaller.Votes().Search(factionResultCall, out factionResult));
      Assert.True(this.jsonApiCaller.Votes().Search(deputyResultCall, out deputyResult));
      this.TestVoteSearchResult(factionResult, deputyResult);
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