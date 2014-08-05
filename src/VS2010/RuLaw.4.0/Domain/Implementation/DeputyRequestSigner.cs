using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Person who signed deputy's request.</para>
  /// </summary>
  [XmlType("signedBy")]
  public sealed class DeputyRequestSigner : NameableEntity<DeputyRequestSigner>, IDeputyRequestSigner
  {
  }
}