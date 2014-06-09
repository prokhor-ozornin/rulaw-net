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
    ///   <para></para>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string RuLawDate(this DateTime date)
    {
      return date.ToString("yyyy-MM-dd");
    }
  }
}