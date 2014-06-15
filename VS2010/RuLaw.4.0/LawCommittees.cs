using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Committees, associated with a law.</para>
  /// </summary>
  [XmlType("committees")]
  public class LawCommittees
  {
    /// <summary>
    ///   <para>List of profile committees.</para>
    /// </summary>
    [JsonProperty("profile")]
    [XmlElement("profile")]
    public virtual List<Committee> Profile { get; set; }

    /// <summary>
    ///   <para>Responsible committee.</para>
    /// </summary>
    [JsonProperty("responsible")]
    [XmlElement("responsible")]
    public virtual Committee Responsible { get; set; }

    /// <summary>
    ///   <para>List of so-executor committees.</para>
    /// </summary>
    [JsonProperty("soexecutor")]
    [XmlElement("soexecutor")]
    public virtual List<Committee> SoExecutor { get; set; }

    /// <summary>
    ///   <para>Creates new committees, associated with a law.</para>
    /// </summary>
    public LawCommittees()
    {
      this.Profile = new List<Committee>();
      this.SoExecutor = new List<Committee>();
    }
  }
}