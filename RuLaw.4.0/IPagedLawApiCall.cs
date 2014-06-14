namespace RuLaw
{
  /// <summary>
  ///   <para>Representation of a custom web request to Russian State Duma REST API, whose result can be paged.</para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IPagedLawApiCall<T> where T : IPagedLawApiCall<T>, ILawApiCall
  {
    /// <summary>
    ///   <para>Specifies number of results page to be returned.</para>
    /// </summary>
    /// <param name="page">Number of page in paged result. Must be a positive number.</param>
    /// <returns>Back reference to the current request.</returns>
    T Page(int page);

    /// <summary>
    ///   <para>Specifies a size of page, i.e. number of records to return for each page.</para>
    /// </summary>
    /// <param name="size">Size of page of results.</param>
    /// <returns>Back reference to the current request.</returns>
    T PageSize(PageSize size);
  }
}