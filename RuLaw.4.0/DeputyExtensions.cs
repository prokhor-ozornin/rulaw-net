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
    ///   <para></para>
    /// </summary>
    /// <param name="deputies"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="deputies"/> or <paramref name="position"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Deputy> Position(this IEnumerable<Deputy> deputies, string position)
    {
      Assertion.NotNull(deputies);
      Assertion.NotEmpty(position);

      return deputies.Where(deputy => deputy != null && deputy.Position.ToLowerInvariant().Contains(position.ToLowerInvariant()));
    }
  }
}