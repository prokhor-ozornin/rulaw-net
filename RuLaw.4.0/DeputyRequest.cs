using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Deputy's request.</para>
  /// </summary>
  [XmlType("request")]
  public class DeputyRequest : IComparable<DeputyRequest>, IEquatable<DeputyRequest>, IRuLawEntity, IDateable, INameable
  {
    /// <summary>
    ///   <para>Unique identifier of deputy's request.</para>
    /// </summary>
    [JsonProperty("requestId")]
    [XmlElement("requestId")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Addressee of deputy's request.</para>
    /// </summary>
    [JsonProperty("addressee")]
    [XmlElement("addressee")]
    public virtual DeputyRequestAddressee Addressee { get; set; }

    /// <summary>
    ///   <para>Text of answer for deputy's request.</para>
    /// </summary>
    [JsonProperty("answer")]
    [XmlElement("answer")]
    public virtual string Answer { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was in control stage.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime ControlDate { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was in control stage.</para>
    /// </summary>
    [JsonProperty("controlDate")]
    [XmlElement("controlDate")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string ControlDateString
    {
      get { return this.ControlDate.ISO8601(); }
      set { this.ControlDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Date when deputy's request was initiated.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was initiated.</para>
    /// </summary>
    [JsonProperty("requestDate")]
    [XmlElement("requestDate")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string DateString
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Number of associated document.</para>
    /// </summary>
    [JsonProperty("documentNumber")]
    [XmlElement("documentNumber")]
    public virtual string DocumentNumber { get; set; }

    /// <summary>
    ///   <para>Number of associated resolution.</para>
    /// </summary>
    [JsonProperty("resolution")]
    [XmlElement("resolution")]
    public virtual string ResolutionNumber { get; set; }

    /// <summary>
    ///   <para>Initiator person of deputy request.</para>
    /// </summary>
    [JsonProperty("initiator")]
    [XmlElement("initiator")]
    public virtual string Initiator { get; set; }

    /// <summary>
    ///   <para>Name of deputy request.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was signed.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime SignDate { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was signed.</para>
    /// </summary>
    [JsonProperty("signedDate")]
    [XmlElement("signedDate")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string SignDateString
    {
      get { return this.SignDate.ISO8601(); }
      set { this.SignDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Person who signed deputy's request.</para>
    /// </summary>
    [JsonProperty("signedBy")]
    [XmlElement("signedBy")]
    public virtual DeputyRequestSigner Signer { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="DeputyRequest"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="DeputyRequest"/> to compare with this instance.</param>
    public virtual int CompareTo(DeputyRequest other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="DeputyRequest"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(DeputyRequest other)
    {
      return this.Equality(other, request => request.Id);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as DeputyRequest);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(request => request.Id);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyRequest"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="DeputyRequest"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}