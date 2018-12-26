namespace RuLaw
{
  using System;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDateTranscriptMeeting"/>.</para>
  /// </summary>
  /// <seealso cref="IDateTranscriptMeeting"/>
  public static class IDateTranscriptMeetingExtensions
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="meeting"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="meeting"/> is a <c>null</c> reference.</exception>
    public static string Text(this IDateTranscriptMeeting meeting)
    {
      Assertion.NotNull(meeting);

      return meeting.Lines.Join(Environment.NewLine);
    }
  }
}