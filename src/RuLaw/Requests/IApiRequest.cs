namespace RuLaw;

/// <summary>
///   <para>Representation of a custom web request to Russian State Duma REST API.</para>
/// </summary>
public interface IApiRequest
{
  /// <summary>
  ///   <para>Map of parameters name/values which are to be send with request.</para>
  /// </summary>
  IReadOnlyDictionary<string, object> Parameters { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="name"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  IApiRequest WithParameter(string name, object value);
}