namespace RuLaw
{
  using System.Xml.Serialization;

  /// <summary>
  ///   <para>Addressee of deputy's request.</para>
  /// </summary>
  [XmlType("addressee")]
  public sealed class DeputyRequestAddressee : NameableEntity<DeputyRequestAddressee>, IDeputyRequestAddressee
  {
  }
}