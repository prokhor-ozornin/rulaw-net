namespace RuLaw
{
  using System;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Question of Duma's session.</para>
  /// </summary>
  [XmlType("question")]
  public sealed class Question : IComparable<IQuestion>, IEquatable<IQuestion>, IQuestion
  {
    /// <summary>
    ///   <para>Code of question.</para>
    /// </summary>
    [JsonProperty("kodvopr")]
    [XmlElement("kodvopr")]
    public int Code { get; set; }

    /// <summary>
    ///   <para>Date of session.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of session.</para>
    /// </summary>
    [JsonProperty("datez")]
    [XmlElement("datez")]
    public string DateOriginal
    {
      get { return Date.ISO8601(); }
      set { Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Last line in question's transcript.</para>
    /// </summary>
    [JsonProperty("nend")]
    [XmlElement("nend")]
    public int EndLine { get; set; }
    
    /// <summary>
    ///   <para>Title of question.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    ///   <para>Code of session.</para>
    /// </summary>
    [JsonProperty("kodz")]
    [XmlElement("kodz")]
    public int SessionCode { get; set; }

    /// <summary>
    ///   <para>First line in question's transcript.</para>
    /// </summary>
    [JsonProperty("nbegin")]
    [XmlElement("nbegin")]
    public int StartLine { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="IQuestion"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IQuestion"/> to compare with this instance.</param>
    public int CompareTo(IQuestion other)
    {
      return Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="IQuestion"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(IQuestion other)
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
      return Equals(other as IQuestion);
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
      return Name;
    }
  }
}