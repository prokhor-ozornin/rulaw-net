using System.Configuration;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IVotesApiExtensions"/>.</para>
/// </summary>
public sealed class IVotesApiExtensionsTest : IDisposable
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  private CancellationToken Cancellation { get; } = new(true);

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IVotesApiExtensions.Search(IVotesApi, IVotesSearchApiRequest)"/></description></item>
  ///     <item><description><see cref="IVotesApiExtensions.Search(IVotesApi, Action{IVotesSearchApiRequest})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Search_Methods()
  {
    static void Validate(IVotesSearchResult result)
    {
      result.Votes.Should().NotBeNullOrEmpty().And.BeOfType<List<Vote>>();

      var vote = result.Votes.First();
      vote.Subject.Should().NotBeNullOrEmpty();
      vote.Date.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
      vote.TotalVotesCount.Should().BePositive();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVotesApiExtensions.Search(null, new VotesSearchApiRequest())).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Votes.Search((IVotesSearchApiRequest) null)).ThrowExactly<ArgumentNullException>();

      var result = Api.Votes.Search(new VotesSearchApiRequest().FromDate(DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(180))).ToDate(DateTimeOffset.UtcNow).Deputy(99111987));
      Validate(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVotesApiExtensions.Search(null, _ => {})).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Votes.Search((Action<IVotesSearchApiRequest>) null)).ThrowExactly<ArgumentNullException>();

      var result = Api.Votes.Search(request => request.FromDate(DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(180))).ToDate(DateTimeOffset.UtcNow).Deputy(99111987));
      Validate(result);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IQuestionsApiExtensions.SearchAsync(IQuestionsApi, Action{IQuestionsApiRequest}, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void SearchAsync_Method()
  {
    static void Validate(IVotesSearchResult result)
    {
      result.Votes.Should().NotBeNullOrEmpty().And.BeOfType<List<Vote>>();

      var vote = result.Votes.First();
      vote.Subject.Should().NotBeNullOrEmpty();
      vote.Date.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
      vote.TotalVotesCount.Should().BePositive();
    }

    AssertionExtensions.Should(() => IVotesApiExtensions.SearchAsync(null, _ => {})).ThrowExactlyAsync<ArgumentNullException>().Await();
    AssertionExtensions.Should(() => IVotesApiExtensions.SearchAsync(Api.Votes, null)).ThrowExactlyAsync<ArgumentNullException>().Await();
    AssertionExtensions.Should(() => Api.Votes.SearchAsync(_ => { }, Cancellation)).ThrowExactlyAsync<TaskCanceledException>().Await();

    var result = Api.Votes.SearchAsync(request => request.FromDate(DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(180))).ToDate(DateTimeOffset.UtcNow).Deputy(99111987)).Await();
    Validate(result);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public void Dispose()
  {
    Api.Dispose();
  }
}