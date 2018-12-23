using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDateableExtensions"/>.</para>
  /// </summary>
  public sealed class IDateableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IDateableExtensions.Date{ENTITY}(IEnumerable{ENTITY}, DateTime?, DateTime?)"/> method.</para>
    /// </summary>
    [Fact]
    public void Period_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<DateableEntity>)null).Date());

      Assert.Empty(Enumerable.Empty<DateableEntity>().Date());

      Assert.Equal(2, new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(null, DateTime.MaxValue).Count());
      Assert.Empty(new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)));
      Assert.Empty(new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MinValue } }.Date(DateTime.MaxValue.AddDays(-1)));
      Assert.Empty(new[] { new DateableEntity { Date = DateTime.MaxValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(null, DateTime.MaxValue.AddDays(-1)));
    }

    private sealed class DateableEntity : IDateable
    {
      public DateTime Date { get; set; }
    }
  }
}
