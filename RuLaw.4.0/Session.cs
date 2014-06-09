using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Duma work session.</para>
  /// </summary>
  [Description("Duma work session")]
  [XmlType("session")]
  public class Session : IComparable<Session>, IEquatable<Session>, IRuLawEntity, IPeriodable, INameable
  {
    /// <summary>
    ///   <para>Unique identifier of work session.</para>
    /// </summary>
    [Description("Unique identifier of work session")]
    [JsonProperty("id")]
    [XmlElement("id")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Date when work session was started.</para>
    /// </summary>
    [Description("Date when work session was started")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime FromDate { get; set; }

    /// <summary>
    ///   <para>Date when work session was started.</para>
    /// </summary>
    [Description("Date when work session was started")]
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
    [Description("Name of work session")]
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Date when work session was ended.</para>
    /// </summary>
    [Description("Date when work session was ended")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime? ToDate { get; set; }

    /// <summary>
    ///   <para>Date when work session was ended.</para>
    /// </summary>
    [Description("Date when work session was ended")]
    [JsonProperty("endDate")]
    [XmlElement("endDate")]
    public virtual string ToDateString
    {
      get { return this.ToDate != null ? this.ToDate.Value.ISO8601() : null; }
      set { this.ToDate = value.IsEmpty() ? (DateTime?)null : DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Compares the current work session with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Session"/> to compare with this instance.</param>
    public virtual int CompareTo(Session other)
    {
      return this.FromDate.CompareTo(other.FromDate);
    }

    /// <summary>
    ///   <para>Determines whether two work sessions instances are equal.</para>
    /// </summary>
    /// <param name="other">The work session to compare with the current one.</param>
    /// <returns><c>true</c> if specified work session is equal to the current, <c>false</c> otherwise.</returns>
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
    ///   <para>Returns a <see cref="string"/> that represents the current work session.</para>
    /// </summary>
    /// <returns>A string that represents the current work session.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}