namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IAuthoritiesLawApiCall : ILawApiCall
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="current"></param>
    /// <returns></returns>
    IAuthoritiesLawApiCall Current(bool current = true);
  }
}