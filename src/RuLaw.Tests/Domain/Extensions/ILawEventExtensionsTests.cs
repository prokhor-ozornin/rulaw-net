using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ILawEventExtensions"/>.</para>
  /// </summary>
  public sealed class ILawEventExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ILawEventExtensions.Solution{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Solution_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ILawEventExtensions.Solution<ILawEvent>(null, "solution"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<ILawEvent>().Solution(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<ILawEvent>().Solution(string.Empty));

      Assert.Empty(Enumerable.Empty<ILawEvent>().Solution("solution"));

      var first = new LawEvent { Solution = "FIRST" };
      var second = new LawEvent { Solution = "Second" };
      var events = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, events.Solution("first").Single()));
      Assert.True(ReferenceEquals(second, events.Solution("second").Single()));
    }
  }
}