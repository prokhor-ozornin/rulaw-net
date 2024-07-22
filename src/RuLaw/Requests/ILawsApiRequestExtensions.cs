namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ILawsApiRequest"/> interface.</para>
/// </summary>
/// <seealso cref="ILawsApiRequest"/>
public static class ILawsApiRequestExtensions
{
  /// <summary>
  ///   <para>Specifies type of laws.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="type">Type of laws.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest Type(this ILawsApiRequest request, LawTypes? type) => request is not null ? request.Type((int?) type) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies topic.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="topic">Instance of topic.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest Topic(this ILawsApiRequest request, ITopic topic) => request is not null ? request.Topic(topic?.Id) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies law's status.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="status">Status of laws.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest Status(this ILawsApiRequest request, LawStatus? status) => request is not null ? request.Status((int?) status) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies law branch.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="branch">Instance of law branch.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest Branch(this ILawsApiRequest request, ILawBranch branch) => request is not null ? request.Branch(branch?.Id) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies deputy.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="deputy">Instance of deputy.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest Deputy(this ILawsApiRequest request, IDeputy deputy) => request is not null ? request.Deputy(deputy?.Id) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies federal authority.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="authority">Instance of authority.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest FederalAuthority(this ILawsApiRequest request, IAuthority authority) => request is not null ? request.FederalAuthority(authority?.Id) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies regional authority.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="authority">Instance of authority.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest RegionalAuthority(this ILawsApiRequest request, IAuthority authority) => request is not null ? request.RegionalAuthority(authority?.Id) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies profile committee.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="committee">Instance of committee.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest ProfileCommittee(this ILawsApiRequest request, ICommittee committee) => request is not null ? request.ProfileCommittee(committee?.Id) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies responsible committee.</para>
  /// </summary>
  /// <param name="committee">Instance of committee.</param>
  /// <param name="request">API call instance to use.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest ResponsibleCommittee(this ILawsApiRequest request, ICommittee committee) => request is not null ? request.ResponsibleCommittee(committee?.Id) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies so-executor committee.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="committee">Instance of committee.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest SoExecutorCommittee(this ILawsApiRequest request, ICommittee committee) => request is not null ? request.SoExecutorCommittee(committee?.Id) : throw new ArgumentNullException(nameof(request));

  /// <summary>
  ///   <para>Specifies type of laws sorting.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="sort">Laws sorting type.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest Sorting(this ILawsApiRequest request, LawsSorting? sort)
  {
    if (request is null) throw new ArgumentNullException(nameof(request));

    return sort switch
    {
      LawsSorting.Name => request.Sorting("name"),
      LawsSorting.Number => request.Sorting("number"),
      LawsSorting.DateDescending => request.Sorting("date"),
      LawsSorting.DateAscending => request.Sorting("date_asc"),
      LawsSorting.LastEventDateDescending => request.Sorting("last_event_date"),
      LawsSorting.LastEventDateAscending => request.Sorting("last_event_date_asc"),
      LawsSorting.ResponsibleCommittee => request.Sorting("responsible_committee"),
      _ => request.Sorting(null)
    };
  }

  /// <summary>
  ///   <para>Specifies events search mode.</para>
  /// </summary>
  /// <param name="request">API call instance to use.</param>
  /// <param name="mode">Events search mode.</param>
  /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
  public static ILawsApiRequest EventsSearchMode(this ILawsApiRequest request, LawsEventsSearchMode? mode) => request is not null ? request.EventsSearchMode((int?) mode) : throw new ArgumentNullException(nameof(request));
}