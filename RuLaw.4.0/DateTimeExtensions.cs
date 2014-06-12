using System;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for structure <see cref="DateTime"/>.</para>
  /// </summary>
  /// <seealso cref="DateTime"/>
  public static class DateTimeExtensions
  {
    /// <summary>
    ///   <para>Returns a string representation of specified date in a format that used by the RuLaw API.</para>
    /// </summary>
    /// <param name="date"><see cref="DateTime"/> instance to convert to string. Only date component is used.</param>
    /// <returns>String representation of date.</returns>
    public static string RuLawDate(this DateTime date)
    {
      return date.ToString("yyyy-MM-dd");
    }
  }
}