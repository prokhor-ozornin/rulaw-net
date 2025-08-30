namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IDeputyTranscriptApiRequest"/> interface.</para>
/// </summary>
/// <seealso cref="IDeputyTranscriptApiRequest"/>
public static class IDeputyTranscriptApiRequestExtensions
{
  /// <summary>
  ///   <para>Specifies deputy, transcripts of whose speeches should be looked up.</para>
  /// </summary>
  /// <param name="request">API request instance to use.</param>
  /// <param name="deputy">Subject deputy.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
  public static IDeputyTranscriptApiRequest Deputy(this IDeputyTranscriptApiRequest request, IDeputy deputy) => request?.Deputy(deputy?.Id) ?? throw new ArgumentNullException(nameof(request));
}