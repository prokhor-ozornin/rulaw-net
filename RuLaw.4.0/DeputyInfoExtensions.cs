using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="DeputyInfo"/>.</para>
  /// </summary>
  /// <seealso cref="DeputyInfo"/>
  public static class DeputyInfoExtensions
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="deputies"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<DeputyInfo> BirthDate(this IEnumerable<DeputyInfo> deputies, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(deputies);

      if (from != null)
      {
        deputies = deputies.Where(deputy => deputy != null && deputy.BirthDate >= from.Value);
      }

      if (to != null)
      {
        deputies = deputies.Where(deputy => deputy != null && deputy.BirthDate <= to.Value);
      }

      return deputies;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="deputies"></param>
    /// <param name="degree"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="degree"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="degree"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<DeputyInfo> Degree(this IEnumerable<DeputyInfo> deputies, string degree)
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(degree);

      return deputies.Where(deputy => deputy != null && deputy.Degrees.Any(x => string.Equals(x, degree, StringComparison.InvariantCultureIgnoreCase)));
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="deputies"></param>
    /// <param name="faction"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="faction"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="faction"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<DeputyInfo> Faction(this IEnumerable<DeputyInfo> deputies, string faction)
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(faction);

      return deputies.Where(deputy => deputy != null && string.Equals(deputy.FactionName, faction, StringComparison.InvariantCultureIgnoreCase));
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="deputies"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<DeputyInfo> Name(this IEnumerable<DeputyInfo> deputies, string name)
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(name);

      return deputies.Where(deputy => deputy != null && deputy.FullName.ToLowerInvariant().Contains(name.ToLowerInvariant()));
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="deputies"></param>
    /// <param name="rank"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="rank"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="rank"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<DeputyInfo> Rank(this IEnumerable<DeputyInfo> deputies, string rank)
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(rank);

      return deputies.Where(deputy => deputy != null && deputy.Ranks.Any(x => string.Equals(x, rank, StringComparison.InvariantCultureIgnoreCase)));
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="deputies"></param>
    /// <param name="region"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="region"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="region"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<DeputyInfo> Region(this IEnumerable<DeputyInfo> deputies, string region)
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(region);

      return deputies.Where(deputy => deputy != null && deputy.Regions.Any(x => string.Equals(x, region, StringComparison.InvariantCultureIgnoreCase)));
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="deputies"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<DeputyInfo> WorkDate(this IEnumerable<DeputyInfo> deputies, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(deputies);

      if (from != null)
      {
        deputies = deputies.Where(deputy => deputy != null && deputy.WorkStartDate >= from.Value);
      }

      if (to != null)
      {
        deputies = deputies.Where(deputy => deputy != null && ((deputy.WorkEndDate.HasValue && deputy.WorkEndDate <= to.Value) || deputy.WorkEndDate == null));
      }

      return deputies;
    }
  }
}