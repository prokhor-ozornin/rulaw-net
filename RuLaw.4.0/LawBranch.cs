using System.ComponentModel;
using System.Xml.Serialization;

namespace RuLaw
{
  /// <summary>
  ///   <para>Branch of law.</para>
  /// </summary>
  [Description("Branch of law")]
  [XmlType("class")]
  public class LawBranch : NameableEntity<LawBranch>
  {
  }
}