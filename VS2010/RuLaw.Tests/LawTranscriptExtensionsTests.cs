using System;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawTranscriptExtensions"/>.</para>
  /// </summary>
  public sealed class LawTranscriptExtensionsTests
  {
    [Fact]
    public void Number_Method()
    {
      Assert.Throws<ArgumentNullException>(() => LawTranscriptExtensions.Number(null, "number"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<LawTranscriptsResult>().Number(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<LawTranscriptsResult>().Number(string.Empty));

      Assert.Null(Enumerable.Empty<LawTranscriptsResult>().Number("number"));

      var first = new LawTranscriptsResult { Number = "FIRST" };
      var second = new LawTranscriptsResult { Number = "Second" };
      var transcripts = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, transcripts.Number("first")));
      Assert.True(ReferenceEquals(second, transcripts.Number("second")));
    }
  }
}