using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IEducation"/>.</para>
  /// </summary>
  /// <seealso cref="IEducation"/>
  public static class IEducationExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of educations, leaving those associated with specified institution.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="educations">Source sequence of educations to filter.</param>
    /// <param name="institution">Full or partial name of institution to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of educations associated with given institution.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="educations"/> or <paramref name="institution"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="institution"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> Institution<ENTITY>(this IEnumerable<ENTITY> educations, string institution) where ENTITY : IEducation
    {
      Assertion.NotNull(educations);
      Assertion.NotEmpty(institution);

      return educations.Where(education => education != null && education.Institution.ToLowerInvariant().Contains(institution.ToLowerInvariant()));
    }

    /// <summary>
    ///   <para>Filters sequence of educations, leaving those that were gained in specified date period.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="educations">Source sequence of educations to filter.</param>
    /// <param name="from">Start date of period.</param>
    /// <param name="to">End date of period.</param>
    /// <returns>Filtered sequence of educations that were gained between <paramref name="from"/> and <paramref name="to"/> dates.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="educations"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> Year<ENTITY>(this IEnumerable<ENTITY> educations, short? from = null, short? to = null) where ENTITY : IEducation
    {
      Assertion.NotNull(educations);

      if (from != null)
      {
        educations = educations.Where(education => education != null && education.Year >= from.Value);
      }
      if (to != null)
      {
        educations = educations.Where(education => education != null && education.Year <= to.Value);
      }

      return educations;
    }
  }
}