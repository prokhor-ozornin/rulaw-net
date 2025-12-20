namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IDeputiesApiRequest"/> interface.</para>
/// </summary>
/// <seealso cref="IDeputiesApiRequest"/>
public static class IDeputiesApiRequestExtensions
{
  /// <param name="request">API request instance to use.</param>
  extension(IDeputiesApiRequest request)
  {
    /// <summary>
    ///   <para>Specifies position of deputies to lookup.</para>
    /// </summary>
    /// <param name="position">Position of deputies.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public IDeputiesApiRequest Position(DeputyPosition? position)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));

      return position switch
      {
        DeputyPosition.DumaDeputy => request.Position("Депутат ГД"),
        DeputyPosition.FederationCouncilMember => request.Position("Член СФ"),
        _ => request.Position(null)
      };
    }
  }
}