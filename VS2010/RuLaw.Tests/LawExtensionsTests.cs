using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawExtensions"/>.</para>
  /// </summary>
  public sealed class LawExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="LawExtensions.Number(IEnumerable{Law}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Number_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Law>)null).Number("number"));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<Law>().Number(string.Empty));

      var laws = new[] { null, new Law { Number = "first" }, null, new Law { Number = "second" } };
      Assert.NotNull(new[] { null, new Law { Number = "first" }, null, new Law { Number = "second" } }.Number("first"));
      Assert.Null(laws.Number("third"));
    }
  }
}