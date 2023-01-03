namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IVotesSearchApiRequest"/>.</para>
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
  public static IVotesSearchApiRequest Deputy(this IVotesSearchApiRequest request, IDeputy deputy) => request.Deputy(deputy?.Id);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="request"></param>
  /// <param name="convocation"></param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static IVotesSearchApiRequest Convocation(this IVotesSearchApiRequest request, IConvocation convocation) => request.Convocation(convocation?.Id);
}