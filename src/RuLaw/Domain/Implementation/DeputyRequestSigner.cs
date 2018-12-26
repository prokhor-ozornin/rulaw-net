namespace RuLaw
{
  using System.Xml.Serialization;

  /// <summary>
  ///   <para>Person who signed deputy's request.</para>
  /// </summary>
  [XmlType("signedBy")]
  public sealed class DeputyRequestSigner : NameableEntity<DeputyRequestSigner>, IDeputyRequestSigner
  {
  }
}