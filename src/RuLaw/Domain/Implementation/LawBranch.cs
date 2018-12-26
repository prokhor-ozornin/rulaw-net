namespace RuLaw
{
  using System.Xml.Serialization;

  /// <summary>
  ///   <para>Branch of law.</para>
  /// </summary>
  [XmlType("class")]
  public sealed class LawBranch : NameableEntity<LawBranch>, ILawBranch
  {
  }
}