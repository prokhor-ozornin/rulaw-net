using System;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDeputyTranscriptLawApiCall"/>.</para>
  /// </summary>
  /// <seealso cref="IDeputyTranscriptLawApiCall"/>
  public static class IDeputyTranscriptLawApiCallExtensions
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="deputy"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="deputy"/> is a <c>null</c> reference.</exception>
    public static IDeputyTranscriptLawApiCall Deputy(this IDeputyTranscriptLawApiCall call, Deputy deputy)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(deputy);

      return call.Deputy(deputy.Id);
    }
  }
}