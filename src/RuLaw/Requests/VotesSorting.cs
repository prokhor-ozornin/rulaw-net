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
///   <para>Set of extension methods for enumeration <see cref="VotesSorting"/>.</para>
/// </summary>
public static class VotesSortingExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="sorting"></param>
  /// <returns></returns>
  public static string AsString(this VotesSorting sorting)
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