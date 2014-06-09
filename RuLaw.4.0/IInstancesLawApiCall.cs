namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IInstancesLawApiCall : ILawApiCall
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="current"></param>
    /// <returns></returns>
    IInstancesLawApiCall Current(bool current = true);
  }
}