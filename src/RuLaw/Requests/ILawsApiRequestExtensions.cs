namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ILawsApiRequest"/> interface.</para>
/// </summary>
/// <seealso cref="ILawsApiRequest"/>
public static class ILawsApiRequestExtensions
{
  /// <param name="request">API call instance to use.</param>
  extension(ILawsApiRequest request)
  {
    /// <summary>
    ///   <para>Specifies type of laws.</para>
    /// </summary>
    /// <param name="type">Type of laws.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest Type(LawTypes? type) => request?.Type((int?) type) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies topic.</para>
    /// </summary>
    /// <param name="topic">Instance of topic.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest Topic(ITopic topic) => request?.Topic(topic?.Id) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies law's status.</para>
    /// </summary>
    /// <param name="status">Status of laws.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest Status(LawStatus? status) => request?.Status((int?) status) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies law branch.</para>
    /// </summary>
    /// <param name="branch">Instance of law branch.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest Branch(ILawBranch branch) => request?.Branch(branch?.Id) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies deputy.</para>
    /// </summary>
    /// <param name="deputy">Instance of deputy.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest Deputy(IDeputy deputy) => request?.Deputy(deputy?.Id) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies federal authority.</para>
    /// </summary>
    /// <param name="authority">Instance of authority.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest FederalAuthority(IAuthority authority) => request?.FederalAuthority(authority?.Id) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies regional authority.</para>
    /// </summary>
    /// <param name="authority">Instance of authority.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest RegionalAuthority(IAuthority authority) => request?.RegionalAuthority(authority?.Id) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies profile committee.</para>
    /// </summary>
    /// <param name="committee">Instance of committee.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest ProfileCommittee(ICommittee committee) => request.ProfileCommittee(committee?.Id) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies responsible committee.</para>
    /// </summary>
    /// <param name="committee">Instance of committee.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest ResponsibleCommittee(ICommittee committee) => request.ResponsibleCommittee(committee?.Id) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies so-executor committee.</para>
    /// </summary>
    /// <param name="committee">Instance of committee.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest SoExecutorCommittee(ICommittee committee) => request.SoExecutorCommittee(committee?.Id) ?? throw new ArgumentNullException(nameof(request));

    /// <summary>
    ///   <para>Specifies type of laws sorting.</para>
    /// </summary>
    /// <param name="sort">Laws sorting type.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest Sorting(LawsSorting? sort)
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
    /// <param name="mode">Events search mode.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public ILawsApiRequest EventsSearchMode(LawsEventsSearchMode? mode) => request.EventsSearchMode((int?) mode) ?? throw new ArgumentNullException(nameof(request));
  }
}