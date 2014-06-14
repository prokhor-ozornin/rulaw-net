using System;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Question of Duma's session.</para>
  /// </summary>
  [XmlType("question")]
  public class Question : IComparable<Question>, IEquatable<Question>, INameable, IDateable
  {
    /// <summary>
    ///   <para>Code of question.</para>
    /// </summary>
    [JsonProperty("kodvopr")]
    [XmlElement("kodvopr")]
    public virtual int Code { get; set; }

    /// <summary>
    ///   <para>Date of session.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of session.</para>
    /// </summary>
    [JsonProperty("datez")]
    [XmlElement("datez")]
    public virtual string DateString
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Last line in question's transcript.</para>
    /// </summary>
    [JsonProperty("nend")]
    [XmlElement("nend")]
    public virtual int EndLine { get; set; }
    
    /// <summary>
    ///   <para>Title of question.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Code of session.</para>
    /// </summary>
    [JsonProperty("kodz")]
    [XmlElement("kodz")]
    public virtual int SessionCode { get; set; }

    /// <summary>
    ///   <para>First line in question's transcript.</para>
    /// </summary>
    [JsonProperty("nbegin")]
    [XmlElement("nbegin")]
    public virtual int StartLine { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="Question"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Question"/> to compare with this instance.</param>
    public virtual int CompareTo(Question other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="Question"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Question other)
    {
      return this.Equality(other, question => question.Code, question => question.SessionCode);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Question);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(question => question.Code, question => question.SessionCode);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Question"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Question"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}