using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IPeriodableExtensions"/>.</para>
/// </summary>
public sealed class IPeriodableExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IPeriodableExtensions.Period{T}(IEnumerable{T}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Period_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IPeriodableExtensions.Period<IPeriodable>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("entities");

      Validate([], []);

      var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

      var first = new PeriodableEntity { FromDate = DateTimeOffset.MinValue };
      var second = new PeriodableEntity { FromDate = date };
      var third = new PeriodableEntity { FromDate = DateTimeOffset.MaxValue };
      var entities = new List<IPeriodable> { null, first, second, third, null };
      Validate([second, third], entities, date);
      Validate([first, second, third], entities, null, date);
      Validate([first, second, third], entities, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);

      first = new PeriodableEntity { FromDate = DateTimeOffset.MinValue, ToDate = DateTimeOffset.MaxValue };
      second = new PeriodableEntity { FromDate = date, ToDate = date };
      third = new PeriodableEntity { FromDate = DateTimeOffset.MaxValue, ToDate = DateTimeOffset.MaxValue };
      entities = [null, first, second, third, null];
      Validate([second, third], entities, date);
      Validate([second], entities, null, date);
      Validate([second], entities, date, date);
    }

    return;

    static void Validate(IEnumerable<IPeriodable> result, IEnumerable<IPeriodable> sequence, DateTimeOffset? from = null, DateTimeOffset? to = null) => sequence.Period(from, to).Should().BeAssignableTo<IEnumerable<IPeriodable>>().And.Equal(result);
  }

  private sealed class PeriodableEntity : IPeriodable
  {
    public DateTimeOffset? FromDate { get; init; }
    public DateTimeOffset? ToDate { get; init; }
  }
}