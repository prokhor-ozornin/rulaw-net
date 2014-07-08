using System;
using System.Collections.Generic;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDateTranscriptMeetingExtensions"/>.</para>
  /// </summary>
  public sealed class IDateTranscriptMeetingExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IDateTranscriptMeetingExtensions.Text(IDateTranscriptMeeting)"/> method.</para>
    /// </summary>
    [Fact]
    public void Text_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDateTranscriptMeetingExtensions.Text(null));

      Assert.Equal("first{0}second".FormatSelf(Environment.NewLine), new DateTranscriptMeeting { LinesOriginal = new List<string> { "first", "second" } }.Text());
    }
  }
}