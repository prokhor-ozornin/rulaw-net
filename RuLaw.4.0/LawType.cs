using System.ComponentModel;
using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Type of law.</para>
  /// </summary>
  [Description("Type of law")]
  [XmlType("type")]
  public class LawType : NameableEntity<LawType>
  {
  }
}