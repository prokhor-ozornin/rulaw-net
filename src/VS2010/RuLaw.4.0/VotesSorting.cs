using System;

namespace RuLaw
{
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
    public static string String(this VotesSorting sorting)
    {
      switch (sorting)
      {
        case VotesSorting.DateAscending:
          return "date_asc";

        case VotesSorting.DateDescending:
          return "date_desc_true";

        case VotesSorting.DateDescendingByDay:
          return "date_desc";

        case VotesSorting.ResultAscending:
          return "result_asc";

        case VotesSorting.ResultDescending:
          return "result_desc";

        default :
          throw new InvalidOperationException();
      }
    }
  }
}