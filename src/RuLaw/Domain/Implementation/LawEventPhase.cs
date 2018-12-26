namespace RuLaw
{
  using System.Xml.Serialization;

  /// <summary>
  ///   <para>Phase of law's review process.</para>
  /// </summary>
  [XmlType("phase")]
  public sealed class LawEventPhase : NameableEntity<LawEventPhase>, ILawEventPhase
  {
  }
}