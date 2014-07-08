using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Deputy"/>.</para>
  /// </summary>
  /// <seealso cref="Deputy"/>
  public static class DeputyExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those with specified position.</para>
    /// </summary>
    /// <param name="deputies">Source sequence of deputies to filter.</param>
    /// <param name="position">Position to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies with specified position.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="position"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<IDeputy> Position(this IEnumerable<IDeputy> deputies, string position)
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(position);

      return deputies.Where(deputy => deputy != null && deputy.Position.ToLowerInvariant().Contains(position.ToLowerInvariant()));
    }
  }
}