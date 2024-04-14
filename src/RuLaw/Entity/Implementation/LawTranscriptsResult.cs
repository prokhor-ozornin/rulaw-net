using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma's law.</para>
/// </summary>
[DataContract(Name = "result")]
public sealed class LawTranscriptsResult : ILawTranscriptsResult
{
  /// <summary>
  ///   <para>Name of law.</para>
  /// </summary>
  [DataMember(Name = "name", IsRequired = true)]
  public string Name { get; set; }

  /// <summary>
  ///   <para>Number of law.</para>
  /// </summary>
  [DataMember(Name = "number", IsRequired = true)]
  public string Number { get; set; }

  /// <summary>
  ///   <para>Law's comments.</para>
  /// </summary>
  [DataMember(Name = "comments", IsRequired = true)]
  public string Comments { get; set; }

  /// <summary>
  ///   <para>List of law's associated meetings.</para>
  /// </summary>
  [DataMember(Name = "meetings", IsRequired = true)]
  public IEnumerable<ITranscriptMeeting> Meetings { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="ILawTranscriptsResult"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ILawTranscriptsResult"/> to compare with this instance.</param>
  public int CompareTo(ILawTranscriptsResult other) => Number.Compare(other?.Number);

  /// <summary>
  ///   <para>Determines whether two <see cref="ILawTranscriptsResult"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(ILawTranscriptsResult other) => this.Equality(other, nameof(Number));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as ILawTranscriptsResult);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Number));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="LawTranscriptsResult"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="LawTranscriptsResult"/>.</returns>
  public override string ToString() => Number ?? string.Empty;
}