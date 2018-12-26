namespace RuLaw
{
  using System.Xml.Serialization;

  /// <summary>
  ///   <para>Type of law.</para>
  /// </summary>
  [XmlType("type")]
  public sealed class LawType : NameableEntity<LawType>, ILawType
  {
  }
}