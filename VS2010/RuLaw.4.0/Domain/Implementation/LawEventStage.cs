using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Stage of law's review process.</para>
  /// </summary>
  [XmlType("stage")]
  public sealed class LawEventStage : NameableEntity<LawEventStage>, ILawEventStage
  {
  }
}