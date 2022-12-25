namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IQuestionsApi
{
  /// <summary>
  ///   <para>Returns list of questions of the meetings agenda of the State Duma.</para>
  /// </summary>
  /// <param name="request">Additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Questions search result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi"/>
  Task<IQuestionsSearchResult> Search(IQuestionsApiRequest? request = null, CancellationToken cancellation = default);
}