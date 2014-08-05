using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ILaw"/>.</para>
  /// </summary>
  /// <seealso cref="ILaw"/>
  public static class ILawExtensions
  {
    /// <summary>
    ///   <para>Searches for a law with specified number and returns it.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="laws">Source sequence of laws for searching.</param>
    /// <param name="number">Unique number of law to search for.</param>
    /// <returns>Law with a specified number, or a <c>null</c> reference if it could not be found.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="laws"/> or <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    public static ENTITY Number<ENTITY>(this IEnumerable<ENTITY> laws, string number) where ENTITY : ILaw
    {
      Assertion.NotNull(laws);
      Assertion.NotEmpty(number);

      return laws.FirstOrDefault(law => law != null && string.Equals(law.Number, number, StringComparison.InvariantCultureIgnoreCase));
    }
  }
}