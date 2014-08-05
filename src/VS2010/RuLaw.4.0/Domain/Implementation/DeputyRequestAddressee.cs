using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Addressee of deputy's request.</para>
  /// </summary>
  [XmlType("addressee")]
  public sealed class DeputyRequestAddressee : NameableEntity<DeputyRequestAddressee>, IDeputyRequestAddressee
  {
  }
}