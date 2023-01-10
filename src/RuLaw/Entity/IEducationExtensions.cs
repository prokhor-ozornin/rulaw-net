using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IEducation"/>.</para>
/// </summary>
/// <seealso cref="IEducation"/>
public static class IEducationExtensions
{
  /// <summary>
  ///   <para>Filters sequence of educations, leaving those associated with specified institution.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="educations">Source sequence of educations to filter.</param>
  /// <param name="institution">Full or partial name of institution to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of educations associated with given institution.</returns>
  public static IEnumerable<TEntity> Institution<TEntity>(this IEnumerable<TEntity> educations, string institution) where TEntity : IEducation
  {
    if (educations is null) throw new ArgumentNullException(nameof(educations));
    if (institution is null) throw new ArgumentNullException(nameof(institution));
    if (institution.IsEmpty()) throw new ArgumentException(nameof(institution));

    return educations.Where(education => education != null && education.Institution.ToLowerInvariant().Contains(institution.ToLowerInvariant()));
  }

  /// <summary>
  ///   <para>Filters sequence of educations, leaving those that were gained in specified date period.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="educations">Source sequence of educations to filter.</param>
  /// <param name="from">Start date of period.</param>
  /// <param name="to">End date of period.</param>
  /// <returns>Filtered sequence of educations that were gained between <paramref name="from"/> and <paramref name="to"/> dates.</returns>
  public static IEnumerable<TEntity> Year<TEntity>(this IEnumerable<TEntity> educations, short? from = null, short? to = null) where TEntity : IEducation
  {
    if (educations is null) throw new ArgumentNullException(nameof(educations));

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