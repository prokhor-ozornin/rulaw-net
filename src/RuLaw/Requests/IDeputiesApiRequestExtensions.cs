namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IDeputiesApiRequest"/>.</para>
/// </summary>
/// <seealso cref="IDeputiesApiRequest"/>
public static class IDeputiesApiRequestExtensions
{
  /// <summary>
  ///   <para>Specifies position of deputies to lookup.</para>
  /// </summary>
  /// <param name="request">API request instance to use.</param>
  /// <param name="position">Position of deputies.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static IDeputiesApiRequest Position(this IDeputiesApiRequest request, DeputyPosition? position)
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