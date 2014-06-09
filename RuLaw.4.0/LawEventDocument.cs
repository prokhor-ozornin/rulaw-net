using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Document, associated with a law's event.</para>
  /// </summary>
  [Description("Document, associated with a law's event")]
  [XmlType("document")]
  public class LawEventDocument : IComparable<LawEventDocument>, IEquatable<LawEventDocument>, INameable
  {
    /// <summary>
    ///   <para>Name of document.</para>
    /// </summary>
    [Description("Name of document")]
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Type of document.</para>
    /// </summary>
    [Description("Type of document")]
    [JsonProperty("type")]
    [XmlElement("type")]
    public virtual string Type { get; set; }

    /// <summary>
    ///   <para>Compares the current document with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="LawEventDocument"/> to compare with this instance.</param>
    public virtual int CompareTo(LawEventDocument other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two document instances are equal.</para>
    /// </summary>
    /// <param name="other">The document to compare with the current one.</param>
    /// <returns><c>true</c> if specified document is equal to the current, <c>false</c> otherwise.</returns>
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
    ///   <para>Returns a <see cref="string"/> that represents the current document.</para>
    /// </summary>
    /// <returns>A string that represents the current document.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}