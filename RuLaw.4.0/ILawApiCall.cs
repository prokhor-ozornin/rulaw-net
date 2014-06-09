using System.Collections.Generic;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface ILawApiCall
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    IDictionary<string, object> Parameters { get; }
  }
}