using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDeputy"/>.</para>
  /// </summary>
  /// <seealso cref="IDeputy"/>
  public static class IDeputyExtensions
  {
    /// <summary>
    ///   <para>Returns work position of deputy as instance of <see cref="DeputyPosition"/> enumeration.</para>
    /// </summary>
    /// <param name="deputy">Deputy instance.</param>
    /// <returns>Work position of deputy, or a <c>null</c> reference if <see cref="Position"/> property was not yet set.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputy"/> is a <c>null</c> reference.</exception>
    public static DeputyPosition? Position(this IDeputy deputy)
    {
      Assertion.NotNull(deputy);

      if (deputy.Position.IsEmpty())
      {
        return null;
      }

      switch (deputy.Position)
      {
        case "Депутат ГД":
          return DeputyPosition.DumaDeputy;

        case "Член СФ":
          return DeputyPosition.FederationCouncilMember;

        default:
          throw new InvalidOperationException();
      }
    }

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those with specified position.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="deputies">Source sequence of deputies to filter.</param>
    /// <param name="position">Position to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies with specified position.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="position"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> Position<ENTITY>(this IEnumerable<ENTITY> deputies, string position) where ENTITY : IDeputy
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(position);

      return deputies.Where(deputy => deputy != null && deputy.Position.ToLowerInvariant().Contains(position.ToLowerInvariant()));
    }
  }
}