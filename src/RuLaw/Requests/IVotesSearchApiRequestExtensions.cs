namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IVotesSearchApiRequest"/> interface.</para>
/// </summary>
/// <seealso cref="IVotesSearchApiRequest"/>
public static class IVotesSearchApiRequestExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="request"></param>
  /// <param name="deputy"></param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
  public static IVotesSearchApiRequest Deputy(this IVotesSearchApiRequest request, IDeputy deputy) => request?.Deputy(deputy?.Id) ?? throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="request"></param>
  /// <param name="convocation"></param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
  public static IVotesSearchApiRequest Convocation(this IVotesSearchApiRequest request, IConvocation convocation) => request?.Convocation(convocation?.Id) ?? throw new ArgumentNullException(nameof(request));
}