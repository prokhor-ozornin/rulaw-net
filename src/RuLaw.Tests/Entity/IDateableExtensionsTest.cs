using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDateableExtensions"/>.</para>
/// </summary>
public sealed class IDateableExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IDateableExtensions.Date{TEntity}(IEnumerable{TEntity}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Period_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<DateableEntity>) null!).Date()).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<DateableEntity>().Date().Should().NotBeNull().And.BeEmpty();

    new[] {new DateableEntity {Date = DateTimeOffset.MinValue}, new DateableEntity {Date = DateTimeOffset.MaxValue}}.Date(DateTimeOffset.MinValue, DateTimeOffset.MaxValue).Should().NotBeNullOrEmpty().And.HaveCount(2);
    new[] {new DateableEntity {Date = DateTimeOffset.MinValue}, new DateableEntity {Date = DateTimeOffset.MaxValue}}.Date(DateTimeOffset.MinValue).Should().NotBeNullOrEmpty().And.HaveCount(2);
    new[] {new DateableEntity {Date = DateTimeOffset.MinValue}, new DateableEntity {Date = DateTimeOffset.MaxValue}}.Date(null, DateTimeOffset.MaxValue).Should().NotBeNullOrEmpty().And.HaveCount(2);
    new[] {new DateableEntity {Date = DateTimeOffset.MinValue}, new DateableEntity {Date = DateTimeOffset.MaxValue}}.Date(DateTimeOffset.MinValue.AddDays(1), DateTimeOffset.MaxValue.AddDays(-1)).Should().NotBeNull().And.BeEmpty();
    new[] {new DateableEntity {Date = DateTimeOffset.MinValue}, new DateableEntity {Date = DateTimeOffset.MinValue}}.Date(DateTimeOffset.MaxValue.AddDays(-1)).Should().NotBeNull().And.BeEmpty();
    new[] {new DateableEntity {Date = DateTimeOffset.MaxValue}, new DateableEntity {Date = DateTimeOffset.MaxValue}}.Date(null, DateTimeOffset.MaxValue.AddDays(-1)).Should().NotBeNull().And.BeEmpty();
  }

  private sealed class DateableEntity : IDateable
  {
    public DateTimeOffset? Date { get; init; }
  }
}