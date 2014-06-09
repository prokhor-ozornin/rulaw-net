using System.ComponentModel;
using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Addressee of deputy's request.</para>
  /// </summary>
  [Description("Addressee of deputy's request")]
  [XmlType("addressee")]
  public class DeputyRequestAddressee : NameableEntity<DeputyRequestAddressee>
  {
  }
}