using System;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IVotesSearchLawApiCall"/>.</para>
  /// </summary>
  /// <seealso cref="IVotesSearchLawApiCall"/>
  public static class IVotesSearchLawApiCallExtensions
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="convocation"></param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="convocation"/> is a <c>null</c> reference.</exception>
    public static IVotesSearchLawApiCall Convocation(this IVotesSearchLawApiCall call, Convocation convocation)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(convocation);

      return call.Convocation(convocation.Id);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="deputy"></param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="deputy"/> is a <c>null</c> reference.</exception>
    public static IVotesSearchLawApiCall Deputy(this IVotesSearchLawApiCall call, Deputy deputy)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(deputy);

      return call.Deputy(deputy.Id);
    }
  }
}