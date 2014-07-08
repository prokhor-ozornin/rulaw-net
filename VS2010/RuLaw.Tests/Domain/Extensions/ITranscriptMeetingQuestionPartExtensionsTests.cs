using System;
using System.Collections.Generic;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
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

      Assert.Equal("first{0}second".FormatSelf(Environment.NewLine), new TranscriptMeetingQuestionPart { LinesOriginal = new List<string> { "first", "second" } }.Text());
    }
  }
}