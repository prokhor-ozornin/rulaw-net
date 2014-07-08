using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawTranscriptExtensions"/>.</para>
  /// </summary>
  public sealed class LawTranscriptExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="LawTranscriptExtensions.Number(IEnumerable{ILawTranscriptsResult>} string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Number_Method()
    {
      Assert.Throws<ArgumentNullException>(() => LawTranscriptExtensions.Number(null, "number"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<ILawTranscriptsResult>().Number(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<ILawTranscriptsResult>().Number(string.Empty));

      Assert.Null(Enumerable.Empty<ILawTranscriptsResult>().Number("number"));

      var first = new LawTranscriptsResult { Number = "FIRST" };
      var second = new LawTranscriptsResult { Number = "Second" };
      var transcripts = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, transcripts.Number("first")));
      Assert.True(ReferenceEquals(second, transcripts.Number("second")));
    }
  }
}