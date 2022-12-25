using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IRuLawApi
{
  /// <summary>
  ///   <para>Initializes a caller object to perform web requests to RuLaw API.</para>
  /// </summary>
  /// <param name="configurator">Configurator to perform API setup process.</param>
  public IApi Configure(IApiConfigurator configurator)
  {
    if (configurator.ApiKeyValue.IsEmpty())
    {
      throw new InvalidOperationException("Api key was not specified when configuring API caller");
    }

    return new Api(configurator.ApiKeyValue, configurator.AppKeyValue);
  }
}