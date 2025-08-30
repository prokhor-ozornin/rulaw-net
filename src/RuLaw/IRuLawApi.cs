using Catharsis.Extensions;

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
  /// <returns></returns>
  /// <exception cref="ArgumentNullException">If <paramref name="configurator"/> is <see langword="null"/>.</exception>
  public IApi Configure(IApiConfigurator configurator)
  {
    if (configurator is null) throw new ArgumentNullException(nameof(configurator));
    
    if (configurator.ApiKeyValue.IsUnset())
    {
      throw new InvalidOperationException("Api key was not specified when configuring API caller");
    }

    return new Api(configurator.ApiKeyValue, configurator.AppKeyValue);
  }
}