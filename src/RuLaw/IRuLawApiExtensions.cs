namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IRuLawApi"/>.</para>
/// </summary>
/// <seealso cref="IRuLawApi"/>
public static class IRuLawApiExtensions
{
  /// <summary>
  ///   <para>Initializes a caller object to perform web requests to RuLaw API.</para>
  /// </summary>
  /// <param name="api">API caller instance.</param>
  /// <param name="action">Delegate to perform API setup process.</param>
  public static IApi Configure(this IRuLawApi api, Action<IApiConfigurator> action)
  {
    var configurator = new ApiConfigurator();

    action(configurator);

    return api.Configure(configurator);
  }
}