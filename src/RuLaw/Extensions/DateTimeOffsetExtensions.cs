namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="DateTimeOffset"/> structure.</para>
/// </summary>
/// <seealso cref="DateTimeOffset"/>
public static class DateTimeOffsetExtensions
{
  /// <param name="date"><see cref="DateTimeOffset"/> instance to convert to string. Only date component is used.</param>
  extension(DateTimeOffset date)
  {
    /// <summary>
    ///   <para>Returns a string representation of specified date in a format that used by the RuLaw API.</para>
    /// </summary>
    /// <returns>String representation of date.</returns>
    public string AsString() => date.ToString("yyyy-MM-dd");
  }
}