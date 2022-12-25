namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for structure <see cref="DateTimeOffset"/>.</para>
/// </summary>
/// <seealso cref="DateTimeOffset"/>
public static class DateTimeOffsetExtensions
{
  /// <summary>
  ///   <para>Returns a string representation of specified date in a format that used by the RuLaw API.</para>
  /// </summary>
  /// <param name="date"><see cref="DateTimeOffset"/> instance to convert to string. Only date component is used.</param>
  /// <returns>String representation of date.</returns>
  public static string AsString(this DateTimeOffset date) => date.ToString("yyyy-MM-dd");
}