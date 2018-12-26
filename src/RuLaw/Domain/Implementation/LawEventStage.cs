namespace RuLaw
{
  using System.Xml.Serialization;

  /// <summary>
  ///   <para>Stage of law's review process.</para>
  /// </summary>
  [XmlType("stage")]
  public sealed class LawEventStage : NameableEntity<LawEventStage>, ILawEventStage
  {
  }
}