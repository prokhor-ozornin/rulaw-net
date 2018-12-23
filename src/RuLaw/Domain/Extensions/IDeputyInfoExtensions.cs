using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
    using System.Globalization;

    /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDeputyInfo"/>.</para>
  /// </summary>
  /// <seealso cref="IDeputyInfo"/>
  public static class IDeputyInfoExtensions
  {
    /// <summary>
    ///   <para>Returns full name of deputy.</para>
    /// </summary>
    /// <param name="deputy">Deputy instance.</param>
    /// <returns>Full name of deputy.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputy"/> is a <c>null</c> reference.</exception>
    public static string FullName(this IDeputyInfo deputy)
    {
      Assertion.NotNull(deputy);

      return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2}", deputy.LastName, deputy.FirstName, deputy.MiddleName).Trim();
    }

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those that were born in specified date period.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="deputies">Source sequence of deputies to filter.</param>
    /// <param name="from">Start date of period.</param>
    /// <param name="to">End date of period.</param>
    /// <returns>Filtered sequence of deputies that were born between <paramref name="from"/> and <paramref name="to"/> dates.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> BirthDate<ENTITY>(this IEnumerable<ENTITY> deputies, DateTime? from = null, DateTime? to = null) where ENTITY : IDeputyInfo
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
    ///   <para>Filters sequence of deputies, leaving those that have a specified scientific degree.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="deputies">Source sequence of deputies to filter.</param>
    /// <param name="degree">Scientific degree to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies that have a specified degree.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="degree"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="degree"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> Degree<ENTITY>(this IEnumerable<ENTITY> deputies, string degree) where ENTITY : IDeputyInfo
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(degree);

      return deputies.Where(deputy => deputy != null && deputy.Degrees.Any(x => string.Equals(x, degree, StringComparison.InvariantCultureIgnoreCase)));
    }

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those belonging to specified faction.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="deputies">Source sequence of deputies to filter.</param>
    /// <param name="faction">Faction name to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies that belong to specified faction.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="faction"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="faction"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> Faction<ENTITY>(this IEnumerable<ENTITY> deputies, string faction) where ENTITY : IDeputyInfo
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(faction);

      return deputies.Where(deputy => deputy != null && string.Equals(deputy.FactionName, faction, StringComparison.InvariantCultureIgnoreCase));
    }

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those containing a given part in their names.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="deputies">Source sequence of deputies to filter.</param>
    /// <param name="name">Part or full name to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies with specified name.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> FullName<ENTITY>(this IEnumerable<ENTITY> deputies, string name) where ENTITY : IDeputyInfo
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(name);

      return deputies.Where(deputy => deputy != null && deputy.FullName().ToLowerInvariant().Contains(name.ToLowerInvariant()));
    }

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those having a specified rank.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="deputies">Source sequence of deputies to filter.</param>
    /// <param name="rank">Rank to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies that have a specified rank.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="rank"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="rank"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> Rank<ENTITY>(this IEnumerable<ENTITY> deputies, string rank) where ENTITY : IDeputyInfo
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(rank);

      return deputies.Where(deputy => deputy != null && deputy.Ranks.Any(x => string.Equals(x, rank, StringComparison.InvariantCultureIgnoreCase)));
    }

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those linked to a specified region.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="deputies">Source sequence of deputies to filter.</param>
    /// <param name="region">Region to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies linked to a specified region.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="region"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="region"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> Region<ENTITY>(this IEnumerable<ENTITY> deputies, string region) where ENTITY : IDeputyInfo
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(region);

      return deputies.Where(deputy => deputy != null && deputy.Regions.Any(x => string.Equals(x, region, StringComparison.InvariantCultureIgnoreCase)));
    }

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those with a work timespan in specified borders.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="deputies">Source sequence of deputies to filter.</param>
    /// <param name="from">Lower bound of work starting date.</param>
    /// <param name="to">Upper bound of work ending date.</param>
    /// <returns>Filtered sequence of deputies.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> WorkDate<ENTITY>(this IEnumerable<ENTITY> deputies, DateTime? from = null, DateTime? to = null) where ENTITY : IDeputyInfo
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