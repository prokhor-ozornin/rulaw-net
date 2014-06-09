using System.ComponentModel;
using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Phase of law's review process.</para>
  /// </summary>
  [Description("Phase of law's review review")]
  [XmlType("phase")]
  public class LawEventPhase : NameableEntity<LawEventPhase>
  {
  }
}