using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Deputy's higher education information record.</para>
  /// </summary>
  [Description("Deputy's higher education information record")]
  [XmlType("education")]
  public class Education : IComparable<Education>, IEquatable<Education>
  {
    /// <summary>
    ///   <para>Name of education institution.</para>
    /// </summary>
    [Description("Name of education institution")]
    [JsonProperty("institution")]
    [XmlElement("institution")]
    public virtual string Institution { get; set; }

    /// <summary>
    ///   <para>Year of graduation.</para>
    /// </summary>
    [Description("Year of graduation")]
    [JsonProperty("year")]
    [XmlElement("year")]
    public virtual short Year { get; set; }

    /// <summary>
    ///   <para>Compares the current education with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Education"/> to compare with this instance.</param>
    public virtual int CompareTo(Education other)
    {
      return this.Year.CompareTo(other.Year);
    }

    /// <summary>
    ///   <para>Determines whether two educations instances are equal.</para>
    /// </summary>
    /// <param name="other">The education to compare with the current one.</param>
    /// <returns><c>true</c> if specified education is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Education other)
    {
      return this.Equality(other, education => education.Institution, education => education.Year);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Education);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(education => education.Institution, education => education.Year);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current deputy.</para>
    /// </summary>
    /// <returns>A string that represents the current deputy.</returns>
    public override string ToString()
    {
      return "{0} ({1})".FormatSelf(this.Institution, this.Year);
    }
  }
}