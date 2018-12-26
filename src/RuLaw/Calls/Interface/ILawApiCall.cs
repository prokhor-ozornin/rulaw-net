namespace RuLaw
{
  using System.Collections.Generic;

  /// <summary>
  ///   <para>Representation of a custom web request to Russian State Duma REST API.</para>
  /// </summary>
  public interface ILawApiCall
  {
    /// <summary>
    ///   <para>Map of parameters name/values which are to be send with request.</para>
    /// </summary>
    IDictionary<string, object> Parameters { get; }
  }
}