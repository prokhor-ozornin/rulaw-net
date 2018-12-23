using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IPeriodableExtensions"/>.</para>
  /// </summary>
  public sealed class IPeriodableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IPeriodableExtensions.Period{T}(IEnumerable{T}, DateTime?, DateTime?)"/> method.</para>
    /// </summary>
    [Fact]
    public void Period_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IPeriodableExtensions.Period<IPeriodable>(null));

      Assert.Empty(Enumerable.Empty<PeriodableEntity>().Period());

      var date = new DateTime(2000, 1, 1);

      var first = new PeriodableEntity { FromDate = DateTime.MinValue };
      var second = new PeriodableEntity { FromDate = date };
      var third = new PeriodableEntity { FromDate = DateTime.MaxValue };
      var entities = new[] { null, first, second, third };
      Assert.True(entities.Period(date).SequenceEqual(new[] { second, third }));
      Assert.True(entities.Period(null, date).SequenceEqual(new[] { first, second, third }));
      Assert.True(entities.Period(DateTime.MinValue, DateTime.MaxValue).SequenceEqual(new[] { first, second, third }));

      first = new PeriodableEntity { FromDate = DateTime.MinValue, ToDate = DateTime.MaxValue };
      second = new PeriodableEntity { FromDate = date, ToDate = date };
      third = new PeriodableEntity { FromDate = DateTime.MaxValue, ToDate = DateTime.MaxValue };
      entities = new[] { null, first, second, third };
      Assert.True(entities.Period(date).SequenceEqual(new[] { second, third }));
      Assert.True(ReferenceEquals(second, entities.Period(null, date).Single()));
      Assert.True(ReferenceEquals(second, entities.Period(date, date).Single()));
    }

    private sealed class PeriodableEntity : IPeriodable
    {
      public DateTime FromDate { get; set; }

      public DateTime? ToDate { get; set; }
    }
  }
}