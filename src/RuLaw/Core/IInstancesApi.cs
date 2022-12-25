namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IInstancesApi
{
  /// <summary>
  ///   <para>Returns list of instances.</para>
  /// </summary>
  /// <param name="request">Additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of instances.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya"/>
  IAsyncEnumerable<IInstance> Search(IInstancesApiRequest? request = null, CancellationToken cancellation = default);
}