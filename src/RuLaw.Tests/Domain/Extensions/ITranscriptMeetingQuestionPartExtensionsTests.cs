using System;
using System.Collections.Generic;
using Xunit;

namespace RuLaw
{
    using System.Globalization;

    /// <summary>
  ///   <para>Tests set for class <see cref="ITranscriptMeetingQuestionPartExtensions"/>.</para>
  /// </summary>
  public sealed class ITranscriptMeetingQuestionPartExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ITranscriptMeetingQuestionPartExtensions.Text(ITranscriptMeetingQuestionPart)"/> method.</para>
    /// </summary>
    [Fact]
    public void Text_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ITranscriptMeetingQuestionPartExtensions.Text(null));

      Assert.Equal(string.Format(CultureInfo.InvariantCulture, "first{0}second",  Environment.NewLine), new TranscriptMeetingQuestionPart { LinesOriginal = new List<string> { "first", "second" } }.Text());
    }
  }
}