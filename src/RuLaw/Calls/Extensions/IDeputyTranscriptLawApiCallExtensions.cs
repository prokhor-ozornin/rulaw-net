namespace RuLaw
{
  using System;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDeputyTranscriptLawApiCall"/>.</para>
  /// </summary>
  /// <seealso cref="IDeputyTranscriptLawApiCall"/>
  public static class IDeputyTranscriptLawApiCallExtensions
  {
    /// <summary>
    ///   <para>Specifies deputy, transcripts of whose speeches should be looked up.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="deputy">Subject deputy.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="deputy"/> is a <c>null</c> reference.</exception>
    public static IDeputyTranscriptLawApiCall Deputy(this IDeputyTranscriptLawApiCall call, IDeputy deputy)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(deputy);

      return call.Deputy(deputy.Id);
    }
  }
}