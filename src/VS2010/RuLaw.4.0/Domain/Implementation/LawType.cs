using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Type of law.</para>
  /// </summary>
  [XmlType("type")]
  public sealed class LawType : NameableEntity<LawType>, ILawType
  {
  }
}