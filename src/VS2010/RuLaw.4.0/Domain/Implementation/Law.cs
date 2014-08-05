using System;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Duma's law.</para>
  /// </summary>
  [XmlType("law")]
  public sealed class Law : IComparable<ILaw>, IEquatable<ILaw>, ILaw
  {
    /// <summary>
    ///   <para>Unique identifier of law.</para>
    /// </summary>
    [JsonProperty("id")]
    [XmlElement("id")]
    public long Id { get; set; }

    /// <summary>
    ///   <para>Law comments.</para>
    /// </summary>
    [JsonProperty("comments")]
    [XmlElement("comments")]
    public string Comments { get; set; }

    /// <summary>
    ///   <para>Committees, associated with a law.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public ILawCommittees Committees
    {
      get { return this.CommitteesOriginal; }
    }

    /// <summary>
    ///   <para>Committees, associated with a law.</para>
    /// </summary>
    [JsonProperty("committees")]
    [XmlElement("committees")]
    public LawCommittees CommitteesOriginal { get; set; }

    /// <summary>
    ///   <para>Date when law was suggested for review.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date when law was suggested for review.</para>
    /// </summary>
    [JsonProperty("introductionDate")]
    [XmlElement("introductionDate")]
    public string DateOriginal
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Last event, associated with a law.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public ILawEvent LastEvent
    {
      get { return this.LastEventOriginal; }
    }

    /// <summary>
    ///   <para>Last event, associated with a law.</para>
    /// </summary>
    [JsonProperty("lastEvent")]
    [XmlElement("lastEvent")]
    public LawEvent LastEventOriginal { get; set; }

    /// <summary>
    ///   <para>Name of law.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    ///   <para>Number of law.</para>
    /// </summary>
    [JsonProperty("number")]
    [XmlElement("number")]
    public string Number { get; set; }

    /// <summary>
    ///   <para>Subject of law.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public ILawSubject Subject
    {
      get { return this.SubjectOriginal; }
    }

    /// <summary>
    ///   <para>Subject of law.</para>
    /// </summary>
    [JsonProperty("subject")]
    [XmlElement("subject")]
    public LawSubject SubjectOriginal { get; set; }

    /// <summary>
    ///   <para>URL address of law's transcript.</para>
    /// </summary>
    [JsonProperty("transcriptUrl")]
    [XmlElement("transcriptUrl")]
    public string TranscriptUrl { get; set; }

    /// <summary>
    ///   <para>Type of law.</para>
    /// </summary>
    [JsonProperty("type")]
    [XmlElement("type")]
    public LawType Type { get; set; }

    /// <summary>
    ///   <para>URL address of law in ASOZD system.</para>
    /// </summary>
    [JsonProperty("url")]
    [XmlElement("url")]
    public string Url { get; set; }

    /// <summary>
    ///   <para>Creates new Duma's law.</para>
    /// </summary>
    public Law()
    {
      this.CommitteesOriginal = new LawCommittees();
      this.SubjectOriginal = new LawSubject();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="ILaw"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="ILaw"/> to compare with this instance.</param>
    public int CompareTo(ILaw other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="ILaw"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(ILaw other)
    {
      return this.Equality(other, law => law.Id);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as ILaw);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(law => law.Id);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Law"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Law"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}