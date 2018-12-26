namespace RuLaw
{
  using System;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Deputy's request.</para>
  /// </summary>
  [XmlType("request")]
  public sealed class DeputyRequest : IComparable<IDeputyRequest>, IEquatable<IDeputyRequest>, IDeputyRequest
  {
    /// <summary>
    ///   <para>Unique identifier of deputy's request.</para>
    /// </summary>
    [JsonProperty("requestId")]
    [XmlElement("requestId")]
    public long Id { get; set; }

    /// <summary>
    ///   <para>Addressee of deputy's request.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IDeputyRequestAddressee Addressee
    {
      get { return AddresseeOriginal; }
    }

    /// <summary>
    ///   <para>Addressee of deputy's request.</para>
    /// </summary>
    [JsonProperty("addressee")]
    [XmlElement("addressee")]
    public DeputyRequestAddressee AddresseeOriginal { get; set; }

    /// <summary>
    ///   <para>Text of answer for deputy's request.</para>
    /// </summary>
    [JsonProperty("answer")]
    [XmlElement("answer")]
    public string Answer { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was in control stage.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime ControlDate { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was in control stage.</para>
    /// </summary>
    [JsonProperty("controlDate")]
    [XmlElement("controlDate")]
    public string ControlDateOriginal
    {
      get { return ControlDate.ISO8601(); }
      set { ControlDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Date when deputy's request was initiated.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was initiated.</para>
    /// </summary>
    [JsonProperty("requestDate")]
    [XmlElement("requestDate")]
    public string DateOriginal
    {
      get { return Date.ISO8601(); }
      set { Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Number of associated document.</para>
    /// </summary>
    [JsonProperty("documentNumber")]
    [XmlElement("documentNumber")]
    public string DocumentNumber { get; set; }

    /// <summary>
    ///   <para>Number of associated resolution.</para>
    /// </summary>
    [JsonProperty("resolution")]
    [XmlElement("resolution")]
    public string ResolutionNumber { get; set; }

    /// <summary>
    ///   <para>Initiator person of deputy request.</para>
    /// </summary>
    [JsonProperty("initiator")]
    [XmlElement("initiator")]
    public string Initiator { get; set; }

    /// <summary>
    ///   <para>Name of deputy request.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was signed.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime SignDate { get; set; }

    /// <summary>
    ///   <para>Date when deputy's request was signed.</para>
    /// </summary>
    [JsonProperty("signedDate")]
    [XmlElement("signedDate")]
    public string SignDateOriginal
    {
      get { return SignDate.ISO8601(); }
      set { SignDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Person who signed deputy's request.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IDeputyRequestSigner Signer
    {
      get { return SignerOriginal; }
    }

    /// <summary>
    ///   <para>Person who signed deputy's request.</para>
    /// </summary>
    [JsonProperty("signedBy")]
    [XmlElement("signedBy")]
    public DeputyRequestSigner SignerOriginal { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="IDeputyRequest"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IDeputyRequest"/> to compare with this instance.</param>
    public int CompareTo(IDeputyRequest other)
    {
      return Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="IDeputyRequest"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(IDeputyRequest other)
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
      return Equals(other as IDeputyRequest);
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
      return Name;
    }
  }
}