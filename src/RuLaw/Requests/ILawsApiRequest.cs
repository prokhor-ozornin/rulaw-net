namespace RuLaw;

/// <summary>
///   <para>Representation of ,aws search request to Russian State Duma REST API.</para>
/// </summary>
public interface ILawsApiRequest : IApiRequest, IPagedApiRequest<ILawsApiRequest>
{
  /// <summary>
  ///   <para>Specifies name of laws.</para>
  /// </summary>
  /// <param name="name">Full or partial name of law(s).</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest Name(string? name);

  /// <summary>
  ///   <para>Specifies numeric code of law's type.</para>
  /// </summary>
  /// <param name="type">Type of laws.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest Type(int? type);

  /// <summary>
  ///   <para>Specifies identifier of topic.</para>
  /// </summary>
  /// <param name="id">Identifier of topic.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest Topic(long? id);

  /// <summary>
  ///   <para>Specifies number of law.</para>
  /// </summary>
  /// <param name="number">Number of law.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest Number(string? number);

  /// <summary>
  ///   <para>Specifies identifier of law's document.</para>
  /// </summary>
  /// <param name="number">Law's document number.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest DocumentNumber(string? number);

  /// <summary>
  ///   <para>Specifies numeric code of law's status.</para>
  /// </summary>
  /// <param name="status">Status of laws.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest Status(int? status);

  /// <summary>
  ///   <para>Specifies identifier of law branch.</para>
  /// </summary>
  /// <param name="id">Identifier of law branch.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest Branch(long? id);

  /// <summary>
  ///   <para>Specifies lower bound (min) of laws registration date.</para>
  /// </summary>
  /// <param name="date">Laws registration date.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest RegistrationStart(DateTimeOffset? date);

  /// <summary>
  ///   <para>Specifies upper bound (max) of laws registration date.</para>
  /// </summary>
  /// <param name="date">Laws registration date.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest RegistrationEnd(DateTimeOffset? date);

  /// <summary>
  ///   <para>Specifies identifier of deputy.</para>
  /// </summary>
  /// <param name="id">Identifier of deputy.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest Deputy(long? id);

  /// <summary>
  ///   <para>Specifies identifier of federal authority.</para>
  /// </summary>
  /// <param name="id">Identifier of authority.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest FederalAuthority(long? id);

  /// <summary>
  ///   <para>Specifies identifier of regional authority.</para>
  /// </summary>
  /// <param name="id">Identifier of authority.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest RegionalAuthority(long? id);

  /// <summary>
  ///   <para>Specifies identifier of profile committee.</para>
  /// </summary>
  /// <param name="id">Identifier of committee.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest ProfileCommittee(long? id);

  /// <summary>
  ///   <para>Specifies identifier of responsible committee.</para>
  /// </summary>
  /// <param name="id">Identifier of committee.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest ResponsibleCommittee(long? id);

  /// <summary>
  ///   <para>Specifies identifier of so-executor committee.</para>
  /// </summary>
  /// <param name="id">Identifier of committee.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest SoExecutorCommittee(long? id);

  /// <summary>
  ///   <para>Specifies type of laws sorting.</para>
  /// </summary>
  /// <param name="sort">Laws sorting type.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest Sorting(string? sort);

  /// <summary>
  ///   <para>Specifies numeric code of events search mode.</para>
  /// </summary>
  /// <param name="mode">Events search mode.</param>
  /// <returns>Back reference to the current request.</returns>
  ILawsApiRequest EventsSearchMode(int? mode);
}