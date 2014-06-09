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
  [Description("Deputy/member of Council of Federation")]
  [XmlType("deputy")]
  public class Deputy : NameableEntity<Deputy>, IActive
  {
    /// <summary>
    ///   <para>Whether the deputy is working at present or not.</para>
    /// </summary>
    [Description("Whether the deputy is working at present or not")]
    [JsonProperty("isCurrent")]
    [XmlElement("isCurrent")]
    public virtual bool Active { get; set; }

    /// <summary>
    ///   <para>Work position of deputy.</para>
    /// </summary>
    [Description("Work position of deputy")]
    [JsonProperty("position")]
    [XmlElement("position")]
    public virtual string Position { get; set; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
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