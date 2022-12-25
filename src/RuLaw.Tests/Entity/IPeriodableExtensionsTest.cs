using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IPeriodableExtensions"/>.</para>
/// </summary>
public sealed class IPeriodableExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IPeriodableExtensions.Period{T}(IEnumerable{T}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Period_Method()
  {
    AssertionExtensions.Should(() => IPeriodableExtensions.Period<IPeriodable>(null!)).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<PeriodableEntity>().Period().Should().NotBeNull().And.BeEmpty();

    var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

    var first = new PeriodableEntity {FromDate = DateTimeOffset.MinValue};
    var second = new PeriodableEntity {FromDate = date};
    var third = new PeriodableEntity {FromDate = DateTimeOffset.MaxValue};
    var entities = new[] {null, first, second, third};
    entities.Period(date).Should().NotBeNullOrEmpty().And.Equal(second, third);
    entities.Period(null, date).Should().NotBeNullOrEmpty().And.Equal(first, second, third);
    entities.Period(DateTimeOffset.MinValue, DateTimeOffset.MaxValue).Should().NotBeNullOrEmpty().And.Equal(first, second, third);

    first = new PeriodableEntity {FromDate = DateTimeOffset.MinValue, ToDate = DateTimeOffset.MaxValue};
    second = new PeriodableEntity {FromDate = date, ToDate = date};
    third = new PeriodableEntity {FromDate = DateTimeOffset.MaxValue, ToDate = DateTimeOffset.MaxValue};
    entities = new[] {null, first, second, third};
    entities.Period(date).Should().NotBeNullOrEmpty().And.Equal(second, third);
    entities.Period(null, date).Should().NotBeNullOrEmpty().And.Equal(second);
    entities.Period(date, date).Should().NotBeNullOrEmpty().And.Equal(second);
  }

  private sealed class PeriodableEntity : IPeriodable
  {
    public DateTimeOffset? FromDate { get; init; }

    public DateTimeOffset? ToDate { get; init; }
  }
}