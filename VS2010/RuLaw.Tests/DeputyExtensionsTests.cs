using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyExtensions"/>.</para>
  /// </summary>
  public sealed class DeputyExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyExtensions.Position(IEnumerable{Deputy}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Position_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DeputyExtensions.Position(null, "position"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Deputy>().Position(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<Deputy>().Position(string.Empty));

      Assert.False(Enumerable.Empty<Deputy>().Position("position").Any());

      var first = new Deputy { Position = "First" };
      var second = new Deputy { Position = "Second" };
      var deputies = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, deputies.Position("first").Single()));
    }
  }
}