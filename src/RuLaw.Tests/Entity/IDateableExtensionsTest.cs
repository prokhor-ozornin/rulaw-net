using AutoFixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDateableExtensions"/>.</para>
/// </summary>
public sealed class IDateableExtensionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IDateableExtensions.Date{TEntity}(IEnumerable{TEntity}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Date_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ((IEnumerable<DateableEntity>) null).Date()).ThrowExactly<ArgumentNullException>().WithParameterName("entities");

      Test([], []);

      var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

      var first = new DateableEntity { Date = DateTimeOffset.MinValue };
      var second = new DateableEntity { Date = date };
      var third = new DateableEntity { Date = DateTimeOffset.MaxValue };
      var entities = new List<IDateable> { null, first, second, third, null };

      Test([second, third], entities, date);
      Test([first, second], entities, null, date);
      Test([first, second, third], entities, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    }

    return;

    static void Test(IEnumerable<IDateable> result, IEnumerable<IDateable> entities, DateTimeOffset? from = null, DateTimeOffset? to = null) => entities.Date(from, to).Should().BeAssignableTo<IEnumerable<IDateable>>().And.Equal(result);
  }

  private sealed class DateableEntity : IDateable
  {
    public DateTimeOffset? Date { get; init; }
  }
}