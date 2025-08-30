namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IRuLawApi"/> interface.</para>
/// </summary>
/// <seealso cref="IRuLawApi"/>
public static class IRuLawApiExtensions
{
  /// <summary>
  ///   <para>Initializes a caller object to perform web requests to RuLaw API.</para>
  /// </summary>
  /// <param name="api">API caller instance.</param>
  /// <param name="action">Delegate to perform API setup process.</param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
  public static IApi Configure(this IRuLawApi api, Action<IApiConfigurator> action)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));
    if (action is null) throw new ArgumentNullException(nameof(action));

    var configurator = new ApiConfigurator();

    action(configurator);

    return api.Configure(configurator);
  }
}