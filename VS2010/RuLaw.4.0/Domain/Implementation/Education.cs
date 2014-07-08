using System;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Deputy's higher education information record.</para>
  /// </summary>
  [XmlType("education")]
  public sealed class Education : IComparable<IEducation>, IEquatable<IEducation>, IEducation
  {
    /// <summary>
    ///   <para>Name of education institution.</para>
    /// </summary>
    [JsonProperty("institution")]
    [XmlElement("institution")]
    public string Institution { get; set; }

    /// <summary>
    ///   <para>Year of graduation.</para>
    /// </summary>
    [JsonProperty("year")]
    [XmlElement("year")]
    public short Year { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="IEducation"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IEducation"/> to compare with this instance.</param>
    public int CompareTo(IEducation other)
    {
      return this.Year.CompareTo(other.Year);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="IEducation"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(IEducation other)
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
      return this.Equals(other as IEducation);
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
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Education"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Education"/>.</returns>
    public override string ToString()
    {
      return "{0} ({1})".FormatSelf(this.Institution, this.Year);
    }
  }
}