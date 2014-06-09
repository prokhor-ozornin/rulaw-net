using System.ComponentModel;
using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Topic (thematic block).</para>
  /// </summary>
  [Description("Topic")]
  [XmlType("topic")]
  public class Topic : NameableEntity<Topic>
  {
  }
}