using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Education"/>.</para>
  /// </summary>
  /// <seealso cref="Education"/>
  public static class EducationExtensions
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="educations"></param>
    /// <param name="institution"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="educations"/> or <paramref name="institution"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="institution"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<Education> Institution(this IEnumerable<Education> educations, string institution)
    {
      Assertion.NotNull(educations);
      Assertion.NotEmpty(institution);

      return educations.Where(education => education != null && education.Institution.ToLowerInvariant().Contains(institution.ToLowerInvariant()));
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="educations"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="educations"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Education> Year(this IEnumerable<Education> educations, short? from = null, short? to = null)
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