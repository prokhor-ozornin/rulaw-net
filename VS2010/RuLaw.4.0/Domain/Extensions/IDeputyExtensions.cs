using System;
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
  }
}