using System;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for inteface <see cref="IDeputiesLawApiCall"/>.</para>
  /// </summary>
  /// <seealso cref="IDeputiesLawApiCall"/>
  public static class IDeputiesLawApiCallExtensions
  {
    /// <summary>
    ///   <para>Specifies position of deputies to lookup.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="position">Position of deputies.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="call"/> is a <c>null</c> reference.</exception>
    public static IDeputiesLawApiCall Position(this IDeputiesLawApiCall call, DeputyPosition position)
    {
      Assertion.NotNull(call);

      switch (position)
      {
        case DeputyPosition.DumaDeputy :
          return call.Position("Депутат ГД");

        case DeputyPosition.FederationCouncilMember :
          return call.Position("Член СФ");

        default :
          throw new ArgumentException("Unknown deputy position");
      }
    }
  }
}