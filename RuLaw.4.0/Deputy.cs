using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Deputy/member of Council of Federation.</para>
  /// </summary>
  [XmlType("deputy")]
  public class Deputy : NameableEntity<Deputy>, IActive
  {
    /// <summary>
    ///   <para>Whether the deputy is working at present or not.</para>
    /// </summary>
    [JsonProperty("isCurrent")]
    [XmlElement("isCurrent")]
    public virtual bool Active { get; set; }

    /// <summary>
    ///   <para>Work position of deputy.</para>
    /// </summary>
    [JsonProperty("position")]
    [XmlElement("position")]
    public virtual string Position { get; set; }

    /// <summary>
    ///   <para>Returns work position of deputy as instance of <see cref="DeputyPosition"/> enumeration.</para>
    /// </summary>
    /// <returns>Work position of deputy, or a <c>null</c> reference if <see cref="Position"/> property was not yet set.</returns>
    public virtual DeputyPosition? GetPosition()
    {
      if (this.Position.IsEmpty())
      {
        return null;
      }

      switch (this.Position)
      {
        case "Депутат ГД" :
          return DeputyPosition.DumaDeputy;

        case "Член СФ" :
          return DeputyPosition.FederationCouncilMember;

        default :
          throw new InvalidOperationException();
      }
    }
  }
}