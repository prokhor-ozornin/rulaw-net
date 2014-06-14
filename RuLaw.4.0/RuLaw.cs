using System;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Entry point to RuLaw API client service, allowing to perform remote calls to API web service.</para>
  /// </summary>
  /// <seealso cref="http://api.duma.gov.ru"/>
  public static class RuLaw
  {
    /// <summary>
    ///   <para>Initializes a caller object to perform web requests to RuLaw API.</para>
    /// </summary>
    /// <param name="configurator">Delegate to perform API setup process.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="configurator"/> is a <c>null</c> reference.</exception>
    public static IApiCaller API(Action<IApiConfigurator> configurator)
    {
      Assertion.NotNull(configurator);

      var apiConfigurator = new ApiConfigurator();
      configurator(apiConfigurator);

      if (apiConfigurator.GetApiKey().IsEmpty())
      {
        throw new InvalidOperationException("API Key was not specified when configuring API caller");
      }

      return new ApiCaller(apiConfigurator.GetFormat(), apiConfigurator.GetApiKey(), apiConfigurator.GetAppKey());
    }
  }
}