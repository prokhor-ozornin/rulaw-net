using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeOffsetExtensions"/>.</para>
/// </summary>
public sealed class DateTimeOffsetExtensionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExtensions.AsString(DateTimeOffset)"/> method.</para>
  /// </summary>
  [Fact]
  public void DateTimeOffset_AsString_Method()
  {
    using (new AssertionScope())
    {
      Test(DateTimeOffset.MinValue);
      Test(DateTimeOffset.MaxValue);
      Test(DateTimeOffset.Now);
    }

    return;

    static void Test(DateTimeOffset date) => date.AsString().Should().BeOfType<string>().And.Be(date.ToString("yyyy-MM-dd"));
  }
}