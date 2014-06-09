using System.ComponentModel;
using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Person who signed deputy's request.</para>
  /// </summary>
  [Description("Person who signed deputy's request")]
  [XmlType("signedBy")]
  public class DeputyRequestSigner : NameableEntity<DeputyRequestSigner>
  {
  }
}