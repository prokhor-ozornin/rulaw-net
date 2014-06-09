﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Duma's convocation.</para>
  /// </summary>
  [Description("Duma's convocation")]
  [XmlType("period")]
  public class Convocation : IComparable<Convocation>, IEquatable<Convocation>, IRuLawEntity, INameable, IPeriodable
  {
    /// <summary>
    ///   <para>Unique identifier of convocation.</para>
    /// </summary>
    [Description("Unique identifier of convocation")]
    [JsonProperty("id")]
    [XmlElement("id")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Date when convocation was started.</para>
    /// </summary>
    [Description("Date when convocation was started")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime FromDate { get; set; }

    /// <summary>
    ///   <para>Date when convocation was started.</para>
    /// </summary>
    [Description("Date when convocation was started")]
    [JsonProperty("startDate")]
    [XmlElement("startDate")]
    public virtual string FromDateString
    {
      get { return this.FromDate.ISO8601(); }
      set { this.FromDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Name of convocation.</para>
    /// </summary>
    [Description("Name of convocation")]
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Collection of sessions which are part of the convocation.</para>
    /// </summary>
    [Description("Collection of sessions which are part of the convocation")]
    [JsonProperty("sessions")]
    [XmlElement("session")]
    public virtual List<Session> Sessions { get; set; }

    /// <summary>
    ///   <para>Date when convocation was ended.</para>
    /// </summary>
    [Description("Date when convocation was ended")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime? ToDate { get; set; }

    /// <summary>
    ///   <para>Date when convocation was ended.</para>
    /// </summary>
    [Description("Date when convocation was ended")]
    [JsonProperty("endDate")]
    [XmlElement("endDate")]
    public virtual string ToDateString
    {
      get { return this.ToDate != null ? this.ToDate.Value.ISO8601() : null; }
      set { this.ToDate = value.IsEmpty() ? (DateTime?) null : DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Creates new convocation.</para>
    /// </summary>
    public Convocation()
    {
      this.Sessions = new List<Session>();
    }

    /// <summary>
    ///   <para>Compares the current convocation with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Convocation"/> to compare with this instance.</param>
    public virtual int CompareTo(Convocation other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two convocations instances are equal.</para>
    /// </summary>
    /// <param name="other">The convocation to compare with the current one.</param>
    /// <returns><c>true</c> if specified convocation is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Convocation other)
    {
      return this.Equality(other, convocation => convocation.Id);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Convocation);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(convocation => convocation.Id);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current convocation.</para>
    /// </summary>
    /// <returns>A string that represents the current convocation.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}