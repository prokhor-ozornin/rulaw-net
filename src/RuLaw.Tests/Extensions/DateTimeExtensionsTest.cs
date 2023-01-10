using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeOffsetExtensions"/>.</para>
/// </summary>
public sealed class DateTimeOffsetExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExtensions.AsString(DateTimeOffset)"/> method.</para>
  /// </summary>
  [Fact]
  public void DateTimeOffset_AsString_Method()
  {
    foreach (var date in new[] {DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow})
    {
      date.ToString("yyyy-MM-dd").Should().NotBeNullOrEmpty().And.Be(date.AsString());
    }
  }
}