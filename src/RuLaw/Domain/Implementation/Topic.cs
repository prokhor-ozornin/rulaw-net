namespace RuLaw
{
  using System.Xml.Serialization;

  /// <summary>
  ///   <para>Topic (thematic block).</para>
  /// </summary>
  [XmlType("topic")]
  public sealed class Topic : NameableEntity<Topic>, ITopic
  {
  }
}