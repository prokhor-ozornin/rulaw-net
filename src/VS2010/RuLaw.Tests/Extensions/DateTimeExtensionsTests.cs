using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DateTimeExtensions"/>.</para>
  /// </summary>
  public sealed class DateTimeExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="DateTimeExtensions.RuLawDate(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void RuLawDate_Method()
    {
      var date = DateTime.UtcNow;
      Assert.Equal(date.ToString("yyyy-MM-dd"), date.RuLawDate());
    }
  }
}