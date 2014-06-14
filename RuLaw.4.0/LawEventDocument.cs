using System;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Document, associated with a law's event.</para>
  /// </summary>
  [XmlType("document")]
  public class LawEventDocument : IComparable<LawEventDocument>, IEquatable<LawEventDocument>, INameable
  {
    /// <summary>
    ///   <para>Name of document.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Type of document.</para>
    /// </summary>
    [JsonProperty("type")]
    [XmlElement("type")]
    public virtual string Type { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="LawEventDocument"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="LawEventDocument"/> to compare with this instance.</param>
    public virtual int CompareTo(LawEventDocument other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="LawEventDocument"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(LawEventDocument other)
    {
      return this.Equality(other, document => document.Name);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as LawEventDocument);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(document => document.Name);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="LawEventDocument"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="LawEventDocument"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}