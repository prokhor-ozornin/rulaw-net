using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Branch of law.</para>
  /// </summary>
  [XmlType("class")]
  public sealed class LawBranch : NameableEntity<LawBranch>, ILawBranch
  {
  }
}