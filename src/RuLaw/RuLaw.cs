namespace RuLaw;

/// <summary>
///   <para>Entry point to RuLaw API client service, allowing to perform remote calls to API web service.</para>
/// </summary>
/// <seealso href="http://api.duma.gov.ru"/>
public static class RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public static IRuLawApi Api { get; } = new RuLawApi();

  private sealed class RuLawApi : IRuLawApi
  {
  }
}