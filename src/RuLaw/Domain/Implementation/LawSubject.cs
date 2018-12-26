namespace RuLaw
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Serialization;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Subject of law.</para>
  /// </summary>
  [XmlType("subject")]
  public sealed class LawSubject : ILawSubject
  {
    /// <summary>
    ///   <para>Departments that are subjects of law.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<IAuthority> Departments
    {
      get { return DepartmentsOriginal.Cast<IAuthority>(); }
    }

    /// <summary>
    ///   <para>Departments that are subjects of law.</para>
    /// </summary>
    [JsonProperty("departments")]
    [XmlElement("department")]
    public List<Authority> DepartmentsOriginal { get; set; }

    /// <summary>
    ///   <para>Deputies that are subjects of law.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<IDeputy> Deputies
    {
      get { return DeputiesOriginal.Cast<IDeputy>(); }
    }

    /// <summary>
    ///   <para>Deputies that are subjects of law.</para>
    /// </summary>
    [JsonProperty("deputies")]
    [XmlElement("deputy")]
    public List<Deputy> DeputiesOriginal { get; set; }

    /// <summary>
    ///   <para>Creates new subject of law.</para>
    /// </summary>
    public LawSubject()
    {
      DepartmentsOriginal = new List<Authority>();
      DeputiesOriginal = new List<Deputy>();
    }
  }
}