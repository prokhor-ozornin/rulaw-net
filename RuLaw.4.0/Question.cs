using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Question of Duma's session.</para>
  /// </summary>
  [Description("Question of Duma's session")]
  [XmlType("question")]
  public class Question : IComparable<Question>, IEquatable<Question>, INameable, IDateable
  {
    /// <summary>
    ///   <para>Code of question.</para>
    /// </summary>
    [Description("Code of question")]
    [JsonProperty("kodvopr")]
    [XmlElement("kodvopr")]
    public virtual int Code { get; set; }

    /// <summary>
    ///   <para>Date of session.</para>
    /// </summary>
    [Description("Date of session")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of session.</para>
    /// </summary>
    [Description("Date of session")]
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
    [Description("Last line in question's transcript.")]
    [JsonProperty("nend")]
    [XmlElement("nend")]
    public virtual int EndLine { get; set; }
    
    /// <summary>
    ///   <para>Title of question.</para>
    /// </summary>
    [Description("Title of question")]
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Code of session.</para>
    /// </summary>
    [Description("Code of session")]
    [JsonProperty("kodz")]
    [XmlElement("kodz")]
    public virtual int SessionCode { get; set; }

    /// <summary>
    ///   <para>First line in question's transcript.</para>
    /// </summary>
    [Description("First line in question's transcript")]
    [JsonProperty("nbegin")]
    [XmlElement("nbegin")]
    public virtual int StartLine { get; set; }

    /// <summary>
    ///   <para>Compares the current question with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Question"/> to compare with this instance.</param>
    public virtual int CompareTo(Question other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two questions instances are equal.</para>
    /// </summary>
    /// <param name="other">The question to compare with the current one.</param>
    /// <returns><c>true</c> if specified question is equal to the current, <c>false</c> otherwise.</returns>
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
    ///   <para>Returns a <see cref="string"/> that represents the current question.</para>
    /// </summary>
    /// <returns>A string that represents the current question.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}