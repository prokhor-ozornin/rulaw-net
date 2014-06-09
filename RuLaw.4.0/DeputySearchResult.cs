using System.ComponentModel;
using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Deputy search results.</para>
  /// </summary>
  [Description("Deputy search results")]
  public sealed class DeputySearchResult
  {
    /// <summary>
    ///   <para>Deputy info.</para>
    /// </summary>
    [Description("Deputy info")]
    [XmlElement("deputy")]
    public DeputyInfo Deputy { get; set; }
  }
}