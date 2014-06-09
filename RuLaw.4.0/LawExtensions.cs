using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Law"/>.</para>
  /// </summary>
  /// <seealso cref="Law"/>
  public static class LawExtensions
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="laws"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="laws"/> or <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    public static Law Number(this IEnumerable<Law> laws, string number)
    {
      Assertion.NotNull(laws);
      Assertion.NotEmpty(number);

      return laws.FirstOrDefault(law => law != null && string.Equals(law.Number, number, StringComparison.InvariantCultureIgnoreCase));
    }
  }
}