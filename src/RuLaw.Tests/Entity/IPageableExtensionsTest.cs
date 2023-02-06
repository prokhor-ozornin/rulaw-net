using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IPageableExtensions"/>.</para>
/// </summary>
public sealed class IPageableExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IPageableExtensions.Page{TEntity}(IEnumerable{TEntity}, int?, int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    AssertionExtensions.Should(() => IDeputyRequestExtensions.SignDate<IDeputyRequest>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("requests");

    var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

    var first = new DeputyRequest(new {SignDate = DateTimeOffset.MinValue});
    var second = new DeputyRequest(new {SignDate = date});
    var third = new DeputyRequest(new {SignDate = DateTimeOffset.MaxValue});

    var requests = first.ToSequence(second, third, null);
    requests.SignDate(date).Should().NotBeNullOrEmpty().And.Equal(first, second);
    requests.SignDate(null, date).Should().NotBeNullOrEmpty().And.Equal(first, second);
    requests.SignDate(DateTimeOffset.MinValue, DateTimeOffset.MaxValue).Should().NotBeNullOrEmpty().And.Equal(first, second, third);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IPageableExtensions.Page{TEntity}(IEnumerable{TEntity}, int?, int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<PageableEntity>) null).Page(0)).ThrowExactly<ArgumentNullException>().WithParameterName("entities");

    Enumerable.Empty<PageableEntity>().Page().Should().BeEmpty();

    new PageableEntity { Page = 1 }.ToSequence(new PageableEntity { Page = 2 }, null).Page(1).Should().NotBeNullOrEmpty().And.ContainSingle();
  }

  private sealed class PageableEntity : IPageable
  {
    public int? Page { get; init; }

    public int? PageSize { get; init; }
  }
}