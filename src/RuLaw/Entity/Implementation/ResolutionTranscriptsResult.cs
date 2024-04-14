using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma law's resolution.</para>
/// </summary>
[DataContract(Name = "result")]
public sealed class ResolutionTranscriptsResult : IResolutionTranscriptsResult
{
  /// <summary>
  ///   <para>Number of resolution.</para>
  /// </summary>
  [DataMember(Name = "number", IsRequired = true)]
  public string Number { get; set; }

  /// <summary>
  ///   <para>Collection of Duma's meetings.</para>
  /// </summary>
  [DataMember(Name = "meetings", IsRequired = true)]
  public IEnumerable<ITranscriptMeeting> Meetings { get; set; }

  /// <summary>
  ///   <para>Determines whether two <see cref="IResolutionTranscriptsResult"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IResolutionTranscriptsResult other) => this.Equality(other, nameof(Number));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IResolutionTranscriptsResult);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Number));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="ResolutionTranscriptsResult"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="ResolutionTranscriptsResult"/>.</returns>
  public override string ToString() => Number ?? string.Empty;
}