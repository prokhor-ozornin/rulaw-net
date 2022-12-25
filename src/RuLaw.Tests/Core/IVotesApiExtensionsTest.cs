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
  ///     <item><description><see cref="IVotesApiExtensions.Search(IVotesApi, Action{IVotesSearchApiRequest}, CancellationToken)"/></description></item>
  ///     <item><description><see cref="IVotesApiExtensions.Search(IVotesApi, out IVotesSearchResult?, Action{IVotesSearchApiRequest}, CancellationToken)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Search_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVotesApiExtensions.Search(Api.Votes, null!)).ThrowExactlyAsync<ArgumentNullException>().Await();
      AssertionExtensions.Should(() => Api.Votes.Search(_ => {}, Cancellation)).ThrowExactlyAsync<TaskCanceledException>().Await();

      var result = Api.Votes.Search(request => request.FromDate(DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(180))).ToDate(DateTimeOffset.UtcNow).Deputy(99111987)).Await();
      
      result.Votes.Should().NotBeNullOrEmpty().And.BeOfType<List<Vote>>();
      
      var vote = result.Votes.First();
      vote.Subject.Should().NotBeNullOrEmpty();
      vote.Date.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
      vote.TotalVotesCount.Should().BePositive();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVotesApiExtensions.Search(null!, out _, _ => {})).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Votes.Search(out _, _ => { }, Cancellation)).ThrowExactly<ArgumentNullException>();

      Api.Votes.Search(out var result, request => request.FromDate(DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(180))).ToDate(DateTimeOffset.UtcNow)).Should().BeTrue();
      
      result.Should().NotBeNull().And.BeOfType<VotesSearchResult>();
      
      result.Count.Should().BePositive();
      result.PageSize.Should().Be(20);
      result.Wording.Should().NotBeNullOrEmpty();
    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public void Dispose()
  {
    Api.Dispose();
  }
}