namespace RuLaw
{
  using System.Xml.Serialization;

  /// <summary>
  ///   <para>Deputy search results.</para>
  /// </summary>
  public sealed class DeputySearchResult
  {
    /// <summary>
    ///   <para>Deputy info.</para>
    /// </summary>
    [XmlElement("deputy")]
    public DeputyInfo Deputy { get; set; }
  }
}