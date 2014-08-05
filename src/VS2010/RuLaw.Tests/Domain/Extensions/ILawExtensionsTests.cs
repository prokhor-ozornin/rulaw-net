using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ILawExtensions"/>.</para>
  /// </summary>
  public sealed class ILawExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ILawExtensions.Number{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Number_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<ILaw>)null).Number("number"));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<ILaw>().Number(string.Empty));

      var laws = new[] { null, new Law { Number = "first" }, null, new Law { Number = "second" } };
      Assert.NotNull(new[] { null, new Law { Number = "first" }, null, new Law { Number = "second" } }.Number("first"));
      Assert.Null(laws.Number("third"));
    }
  }
}