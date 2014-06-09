using System.ComponentModel;

namespace RuLaw
{
  /// <summary>
  ///   <para>Format of RuLaw API data exchange.</para>
  /// </summary>
  public enum ApiDataFormat
  {
    /// <summary>
    ///   <para>JSON format.</para>
    /// </summary>
    [Description("JSON")]
    Json,

    /// <summary>
    ///   <para>XML format.</para>
    /// </summary>
    [Description("XML")]
    Xml
  }
}