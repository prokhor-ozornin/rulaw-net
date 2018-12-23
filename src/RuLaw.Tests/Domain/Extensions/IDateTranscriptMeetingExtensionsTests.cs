using System;
using System.Collections.Generic;
using Xunit;

namespace RuLaw
{
    using System.Globalization;

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

      Assert.Equal(string.Format(CultureInfo.InvariantCulture, "first{0}second", Environment.NewLine), new DateTranscriptMeeting { LinesOriginal = new List<string> { "first", "second" } }.Text());
    }
  }
}