namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IVotesSearchApiRequest"/> interface.</para>
/// </summary>
/// <seealso cref="IVotesSearchApiRequest"/>
public static class IVotesSearchApiRequestExtensions
{
  /// <param name="request"></param>
  extension(IVotesSearchApiRequest request)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="deputy"></param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public IVotesSearchApiRequest Deputy(IDeputy deputy) => request?.Deputy(deputy?.Id) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="convocation"></param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public IVotesSearchApiRequest Convocation(IConvocation convocation) => request?.Convocation(convocation?.Id) ?? throw new ArgumentNullException(nameof(request));
  }
}