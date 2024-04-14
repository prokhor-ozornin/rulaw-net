using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Duma's law.</para>
/// </summary>
[DataContract(Name = "law")]
public sealed class Law : ILaw
{
  /// <summary>
  ///   <para>Unique identifier of law.</para>
  /// </summary>
  [DataMember(Name = "id", IsRequired = true)]
  public long? Id { get; set; }

  /// <summary>
  ///   <para>Name of law.</para>
  /// </summary>
  [DataMember(Name = "name", IsRequired = true)]
  public string Name { get; set; }

  /// <summary>
  ///   <para>Date when law was suggested for review.</para>
  /// </summary>
  [DataMember(Name = "introductionDate", IsRequired = true)]
  public DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Number of law.</para>
  /// </summary>
  [DataMember(Name = "number", IsRequired = true)]
  public string Number { get; set; }

  /// <summary>
  ///   <para>Subject of law.</para>
  /// </summary>
  [DataMember(Name = "subject", IsRequired = true)]
  public ILawSubject Subject { get; set; }

  /// <summary>
  ///   <para>Type of law.</para>
  /// </summary>
  [DataMember(Name = "type", IsRequired = true)]
  public ILawType Type { get; set; }

  /// <summary>
  ///   <para>URL address of law in ASOZD system.</para>
  /// </summary>
  [DataMember(Name = "url", IsRequired = true)]
  public string Url { get; set; }

  /// <summary>
  ///   <para>URL address of law's transcript.</para>
  /// </summary>
  [DataMember(Name = "transcriptUrl", IsRequired = true)]
  public string TranscriptUrl { get; set; }

  /// <summary>
  ///   <para>Law comments.</para>
  /// </summary>
  [DataMember(Name = "comments", IsRequired = true)]
  public string Comments { get; set; }

  /// <summary>
  ///   <para>Last event, associated with a law.</para>
  /// </summary>
  [DataMember(Name = "lastEvent", IsRequired = true)]
  public ILawEvent LastEvent { get; set; }

  /// <summary>
  ///   <para>Committees, associated with a law.</para>
  /// </summary>
  [DataMember(Name = "committees", IsRequired = true)]
  public ILawCommittees Committees { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="ILaw"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ILaw"/> to compare with this instance.</param>
  public int CompareTo(ILaw other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="ILaw"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(ILaw other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as ILaw);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Id));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Law"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Law"/>.</returns>
  public override string ToString() => Name ?? string.Empty;
}