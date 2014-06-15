using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Duma's law.</para>
  /// </summary>
  [XmlType("law")]
  public class Law : IComparable<Law>, IEquatable<Law>, IRuLawEntity, IDateable, INameable
  {
    /// <summary>
    ///   <para>Unique identifier of law.</para>
    /// </summary>
    [JsonProperty("id")]
    [XmlElement("id")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Law comments.</para>
    /// </summary>
    [JsonProperty("comments")]
    [XmlElement("comments")]
    public virtual string Comments { get; set; }

    /// <summary>
    ///   <para>Committees, associated with a law.</para>
    /// </summary>
    [JsonProperty("committees")]
    [XmlElement("committees")]
    public virtual LawCommittees Committees { get; set; }

    /// <summary>
    ///   <para>Date when law was suggested for review.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date when law was suggested for review.</para>
    /// </summary>
    [JsonProperty("introductionDate")]
    [XmlElement("introductionDate")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string DateString
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Last event, associated with a law.</para>
    /// </summary>
    [JsonProperty("lastEvent")]
    [XmlElement("lastEvent")]
    public virtual LawEvent LastEvent { get; set; }

    /// <summary>
    ///   <para>Name of law.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Number of law.</para>
    /// </summary>
    [JsonProperty("number")]
    [XmlElement("number")]
    public virtual string Number { get; set; }

    /// <summary>
    ///   <para>Subject of law.</para>
    /// </summary>
    [JsonProperty("subject")]
    [XmlElement("subject")]
    public virtual LawSubject Subject { get; set; }

    /// <summary>
    ///   <para>URL address of law's transcript.</para>
    /// </summary>
    [JsonProperty("transcriptUrl")]
    [XmlElement("transcriptUrl")]
    public virtual string TranscriptUrl { get; set; }

    /// <summary>
    ///   <para>Type of law.</para>
    /// </summary>
    [JsonProperty("type")]
    [XmlElement("type")]
    public virtual LawType Type { get; set; }

    /// <summary>
    ///   <para>URL address of law in ASOZD system.</para>
    /// </summary>
    [JsonProperty("url")]
    [XmlElement("url")]
    public virtual string Url { get; set; }

    /// <summary>
    ///   <para>Creates new Duma's law.</para>
    /// </summary>
    public Law()
    {
      this.Committees = new LawCommittees();
      this.Subject = new LawSubject();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Law"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Law"/> to compare with this instance.</param>
    public virtual int CompareTo(Law other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="Law"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Law other)
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
      return this.Equals(other as Law);
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