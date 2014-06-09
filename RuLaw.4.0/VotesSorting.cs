using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public enum VotesSorting
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    DateAscending,
    
    /// <summary>
    ///   <para></para>
    /// </summary>
    DateDescending,
    
    /// <summary>
    ///   <para></para>
    /// </summary>
    DateDescendingByDay,
    
    /// <summary>
    ///   <para></para>
    /// </summary>
    ResultAscending,
    
    /// <summary>
    ///   <para></para>
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