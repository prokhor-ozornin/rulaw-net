using System;
using Catharsis.Commons;

namespace RuLaw
{
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

      return "{0} {1} {2}".FormatSelf(deputy.LastName, deputy.FirstName, deputy.MiddleName).Trim();
    }
  }
}