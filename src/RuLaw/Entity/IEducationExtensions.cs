using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IEducation"/> interface.</para>
/// </summary>
/// <seealso cref="IEducation"/>
public static class IEducationExtensions
{
  /// <param name="educations">Source sequence of educations to filter.</param>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  extension<TEntity>(IEnumerable<TEntity> educations) where TEntity : IEducation
  {
    /// <summary>
    ///   <para>Filters sequence of educations, leaving those associated with specified institution.</para>
    /// </summary>
    /// <param name="institution">Full or partial name of institution to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of educations associated with given institution.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="educations"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Institution(string institution) => educations?.Where(education => education is not null && education.Institution.ToInvariantString().Contains(institution.ToInvariantString())) ?? throw new ArgumentNullException(nameof(educations));

    /// <summary>
    ///   <para>Filters sequence of educations, leaving those that were gained in specified date period.</para>
    /// </summary>
    /// <param name="from">Start date of period.</param>
    /// <param name="to">End date of period.</param>
    /// <returns>Filtered sequence of educations that were gained between <paramref name="from"/> and <paramref name="to"/> dates.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="educations"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Year(short? from = null, short? to = null)
    {
      if (educations is null) throw new ArgumentNullException(nameof(educations));

      if (from is not null)
      {
        educations = educations.Where(education => education is not null && education.Year >= from.Value);
      }

      if (to is not null)
      {
        educations = educations.Where(education => education is not null && education.Year <= to.Value);
      }

      return educations;
    }
  }
}