namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IPagedLawApiCall<T> where T : IPagedLawApiCall<T>
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    T Page(int page);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    T PageSize(PageSize size);
  }
}