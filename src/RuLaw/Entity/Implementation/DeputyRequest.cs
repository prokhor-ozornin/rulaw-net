using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Deputy's request.</para>
/// </summary>
[DataContract(Name = "request")]
public sealed class DeputyRequest : IDeputyRequest
{
  /// <summary>
  ///   <para>Unique identifier of deputy's request.</para>
  /// </summary>
  [DataMember(Name = "requestId", IsRequired = true)]
  public long? Id { get; set; }

  /// <summary>
  ///   <para>Name of deputy request.</para>
  /// </summary>
  [DataMember(Name = "name", IsRequired = true)]
  public string Name { get; set; }

  /// <summary>
  ///   <para>Date when deputy's request was initiated.</para>
  /// </summary>
  [DataMember(Name = "date", IsRequired = true)]
  public DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Number of associated document.</para>
  /// </summary>
  [DataMember(Name = "documentNumber", IsRequired = true)]
  public string DocumentNumber { get; set; }

  /// <summary>
  ///   <para>Initiator person of deputy request.</para>
  /// </summary>
  [DataMember(Name = "initiator", IsRequired = true)]
  public string Initiator { get; set; }

  /// <summary>
  ///   <para>Addressee of deputy's request.</para>
  /// </summary>
  [DataMember(Name = "addressee", IsRequired = true)]
  public IDeputyRequestAddressee Addressee { get; set; }

  /// <summary>
  ///   <para>Text of answer for deputy's request.</para>
  /// </summary>
  [DataMember(Name = "answer", IsRequired = true)]
  public string Answer { get; set; }

  /// <summary>
  ///   <para>Person who signed deputy's request.</para>
  /// </summary>
  [DataMember(Name = "signedBy", IsRequired = true)]
  public IDeputyRequestSigner Signer { get; set; }

  /// <summary>
  ///   <para>Date when deputy's request was signed.</para>
  /// </summary>
  [DataMember(Name = "signedDate", IsRequired = true)]
  public DateTimeOffset? SignDate { get; set; }

  /// <summary>
  ///   <para>Date when deputy's request was in control stage.</para>
  /// </summary>
  [DataMember(Name = "controlDate", IsRequired = true)]
  public DateTimeOffset? ControlDate { get; set; }

  /// <summary>
  ///   <para>Number of associated resolution.</para>
  /// </summary>
  [DataMember(Name = "resolution", IsRequired = true)]
  public string ResolutionNumber { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="IDeputyRequest"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IDeputyRequest"/> to compare with this instance.</param>
  public int CompareTo(IDeputyRequest other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="IDeputyRequest"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IDeputyRequest other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IDeputyRequest);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Id));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyRequest"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="DeputyRequest"/>.</returns>
  public override string ToString() => Name ?? string.Empty;
}