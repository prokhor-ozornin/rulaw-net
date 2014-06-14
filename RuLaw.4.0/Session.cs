using System;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Duma work session.</para>
  /// </summary>
  [XmlType("session")]
  public class Session : IComparable<Session>, IEquatable<Session>, IRuLawEntity, IPeriodable, INameable
  {
    /// <summary>
    ///   <para>Unique identifier of work session.</para>
    /// </summary>
    [JsonProperty("id")]
    [XmlElement("id")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Date when work session was started.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime FromDate { get; set; }

    /// <summary>
    ///   <para>Date when work session was started.</para>
    /// </summary>
    [JsonProperty("startDate")]
    [XmlElement("startDate")]
    public virtual string FromDateString
    {
      get { return this.FromDate.ISO8601(); }
      set { this.FromDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Name of work session.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Date when work session was ended.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime? ToDate { get; set; }

    /// <summary>
    ///   <para>Date when work session was ended.</para>
    /// </summary>
    [JsonProperty("endDate")]
    [XmlElement("endDate")]
    public virtual string ToDateString
    {
      get { return this.ToDate != null ? this.ToDate.Value.ISO8601() : null; }
      set { this.ToDate = value.IsEmpty() ? (DateTime?)null : DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Session"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Session"/> to compare with this instance.</param>
    public virtual int CompareTo(Session other)
    {
      return this.FromDate.CompareTo(other.FromDate);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="Session"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Session other)
    {
      return this.Equality(other, session => session.Id);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Session);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(session => session.Id);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Session"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Session"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}