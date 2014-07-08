using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Phase of law's review process.</para>
  /// </summary>
  [XmlType("phase")]
  public sealed class LawEventPhase : NameableEntity<LawEventPhase>, ILawEventPhase
  {
  }
}