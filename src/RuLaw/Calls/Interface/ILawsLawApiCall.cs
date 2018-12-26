namespace RuLaw
{
  using System;

  /// <summary>
  ///   <para>Representation of ,aws search request to Russian State Duma REST API.</para>
  /// </summary>
  public interface ILawsLawApiCall : ILawApiCall, IPagedLawApiCall<ILawsLawApiCall>
  {
    /// <summary>
    ///   <para>Specifies identifier of law branch.</para>
    /// </summary>
    /// <param name="id">Identifier of law branch.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall Branch(long id);

    /// <summary>
    ///   <para>Specifies identifier of deputy.</para>
    /// </summary>
    /// <param name="id">Identifier of deputy.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall Deputy(long id);

    /// <summary>
    ///   <para>Specifies identifier of law's document.</para>
    /// </summary>
    /// <param name="number">Law's document number.</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    ILawsLawApiCall DocumentNumber(string number);

    /// <summary>
    ///   <para>Specifies identifier of federal authority.</para>
    /// </summary>
    /// <param name="id">Identifier of authority.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall FederalAuthority(long id);

    /// <summary>
    ///   <para>Specifies numeric code of law's type.</para>
    /// </summary>
    /// <param name="type">Type of laws.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall Type(int type);

    /// <summary>
    ///   <para>Specifies type of laws sorting.</para>
    /// </summary>
    /// <param name="sort">Laws sorting type.</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="sort"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="sort"/> is <see cref="string.Empty"/> string.</exception>
    ILawsLawApiCall Sorting(string sort);

    /// <summary>
    ///   <para>Specifies numeric code of law's status.</para>
    /// </summary>
    /// <param name="status">Status of laws.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall Status(int status);
    
    /// <summary>
    ///   <para>Specifies name of laws.</para>
    /// </summary>
    /// <param name="name">Full or partial name of law(s).</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">Если <paramref name="name"/> является <c>null</c> ссылкой</exception>
    /// <exception cref="ArgumentException">Если <paramref name="name"/> является <seealso cref="string.Empty"/> строкой.</exception>
    ILawsLawApiCall Name(string name);

    /// <summary>
    ///   <para>Specifies number of law.</para>
    /// </summary>
    /// <param name="number">Number of law.</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">Если <paramref name="number"/> является <c>null</c> ссылкой</exception>
    /// <exception cref="ArgumentException">Если <paramref name="number"/> является <see cref="string.Empty"/> строкой.</exception>
    ILawsLawApiCall Number(string number);

    /// <summary>
    ///   <para>Specifies identifier of profile committee.</para>
    /// </summary>
    /// <param name="id">Identifier of committee.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall ProfileCommittee(long id);

    /// <summary>
    ///   <para>Specifies identifier of regional authority.</para>
    /// </summary>
    /// <param name="id">Identifier of authority.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall RegionalAuthority(long id);

    /// <summary>
    ///   <para>Specifies upper bound (max) of laws registration date.</para>
    /// </summary>
    /// <param name="date">Laws registration date.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall RegistrationEnd(DateTime date);

    /// <summary>
    ///   <para>Specifies lower bound (min) of laws registration date.</para>
    /// </summary>
    /// <param name="date">Laws registration date.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall RegistrationStart(DateTime date);

    /// <summary>
    ///   <para>Specifies identifier of responsible committee.</para>
    /// </summary>
    /// <param name="id">Identifier of committee.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall ResponsibleCommittee(long id);

    /// <summary>
    ///   <para>Specifies identifier of so-executor committee.</para>
    /// </summary>
    /// <param name="id">Identifier of committee.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall SoExecutorCommittee(long id);

    /// <summary>
    ///   <para>Specifies numeric code of events search mode.</para>
    /// </summary>
    /// <param name="mode">Events search mode.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall EventsSearchMode(int mode);

    /// <summary>
    ///   <para>Specifies identifier of topic.</para>
    /// </summary>
    /// <param name="id">Identifier of topic.</param>
    /// <returns>Back reference to the current request.</returns>
    ILawsLawApiCall Topic(long id);
  }
}