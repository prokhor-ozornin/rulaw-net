using System.ComponentModel;
using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Stage of law's review process.</para>
  /// </summary>
  [Description("Stage of law's review process")]
  [XmlType("stage")]
  public class LawEventStage : NameableEntity<LawEventStage>
  {
  }
}