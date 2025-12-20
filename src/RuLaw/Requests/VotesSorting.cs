namespace RuLaw;

/// <summary>
///   <para>Type of votes sorting.</para>
/// </summary>
public enum VotesSorting
{
  /// <summary>
  ///   <para>By date (ascending).</para>
  /// </summary>
  DateAscending,

  /// <summary>
  ///   <para>By date (descending).</para>
  /// </summary>
  DateDescending,

  /// <summary>
  ///   <para>By date (descending), ascending for each day.</para>
  /// </summary>
  DateDescendingByDay,

  /// <summary>
  ///   <para>By result (ascending).</para>
  /// </summary>
  ResultAscending,

  /// <summary>
  ///   <para>By result (descending).</para>
  /// </summary>
  ResultDescending
}

/// <summary>
///   <para>A set of extension methods for the <see cref="VotesSorting"/> enumeration.</para>
/// </summary>
public static class VotesSortingExtensions
{
  /// <param name="sorting"></param>
  extension(VotesSorting sorting)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public string AsString()
    {
      return sorting switch
      {
        VotesSorting.DateAscending => "date_asc",
        VotesSorting.DateDescending => "date_desc_true",
        VotesSorting.DateDescendingByDay => "date_desc",
        VotesSorting.ResultAscending => "result_asc",
        VotesSorting.ResultDescending => "result_desc",
        _ => string.Empty
      };
    }
  }
}