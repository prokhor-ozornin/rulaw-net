using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawEventExtensions"/>.</para>
  /// </summary>
  public sealed class LawEventExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="LawEventExtensions.Solution(IEnumerable{LawEvent}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Solution_Method()
    {
      Assert.Throws<ArgumentNullException>(() => LawEventExtensions.Solution(null, "solution"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<LawEvent>().Solution(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<LawEvent>().Solution(string.Empty));

      Assert.False(Enumerable.Empty<LawEvent>().Solution("solution").Any());

      var first = new LawEvent { Solution = "FIRST" };
      var second = new LawEvent { Solution = "Second" };
      var events = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, events.Solution("first").Single()));
      Assert.True(ReferenceEquals(second, events.Solution("second").Single()));
    }
  }
}