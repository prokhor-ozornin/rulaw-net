using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Detailed deputy information.</para>
/// </summary>
[DataContract(Name = "deputy")]
public sealed class DeputyInfo : IDeputyInfo
{
  /// <summary>
  ///   <para>Unique identifier of deputy.</para>
  /// </summary>
  [DataMember(Name = "id", IsRequired = true)]
  public long? Id { get; set; }

  /// <summary>
  ///   <para>Whether deputy has authority and power at present moment.</para>
  /// </summary>
  [DataMember(Name = "isActual", IsRequired = true)]
  public bool? Active { get; set; }

  /// <summary>
  ///   <para>First name of deputy.</para>
  /// </summary>
  [DataMember(Name = "name", IsRequired = true)]
  public string FirstName { get; set; }

  /// <summary>
  ///   <para>Last name of deputy.</para>
  /// </summary>
  [DataMember(Name = "family", IsRequired = true)]
  public string LastName { get; set; }

  /// <summary>
  ///   <para>Middle name of deputy.</para>
  /// </summary>
  [DataMember(Name = "patronymic", IsRequired = true)]
  public string MiddleName { get; set; }

  /// <summary>
  ///   <para>Birth date of deputy.</para>
  /// </summary>
  [DataMember(Name = "birthdate", IsRequired = true)]
  public DateTimeOffset? BirthDate { get; set; }

  /// <summary>
  ///   <para>Start date of deputy's authorities in last convocation.</para>
  /// </summary>
  [DataMember(Name = "credentialsStart", IsRequired = true)]
  public DateTimeOffset? WorkStartDate { get; set; }

  /// <summary>
  ///   <para>End date of deputy's authorities in last convocation.</para>
  /// </summary>
  [DataMember(Name = "credentialsEnd", IsRequired = true)]
  public DateTimeOffset? WorkEndDate { get; set; }

  /// <summary>
  ///   <para>Identifier of deputy's political faction.</para>
  /// </summary>
  [DataMember(Name = "factionId", IsRequired = true)]
  public long? FactionId { get; set; }

  /// <summary>
  ///   <para>Name of deputy's political faction.</para>
  /// </summary>
  [DataMember(Name = "factionName", IsRequired = true)]
  public string FactionName { get; set; }

  /// <summary>
  ///   <para>Association of deputy's political faction with a region.</para>
  /// </summary>
  [DataMember(Name = "factionRegion", IsRequired = true)]
  public string FactionRegion { get; set; }

  /// <summary>
  ///   <para>Role of deputy's in his political faction.</para>
  /// </summary>
  [DataMember(Name = "factionRole", IsRequired = true)]
  public string FactionRole { get; set; }

  /// <summary>
  ///   <para>Number of laws which have been initiated by the deputy.</para>
  /// </summary>
  [DataMember(Name = "lawcount", IsRequired = true)]
  public int? LawsCount { get; set; }

  /// <summary>
  ///   <para>Number of deputy's public speaches.</para>
  /// </summary>
  [DataMember(Name = "speachCount", IsRequired = true)]
  public int? SpeechesCount { get; set; }

  /// <summary>
  ///   <para>URL link for transcripts of deputy's speaches.</para>
  /// </summary>
  [DataMember(Name = "transcriptLink", IsRequired = true)]
  public string TranscriptLink { get; set; }

  /// <summary>
  ///   <para>URL link for deputy's votes.</para>
  /// </summary>
  [DataMember(Name = "voteLink", IsRequired = true)]
  public string VoteLink { get; set; }

  /// <summary>
  ///   <para>Collection of deputy's activities in committees.</para>
  /// </summary>
  [DataMember(Name = "activity", IsRequired = true)]
  public IEnumerable<IDeputyActivity> Activities { get; set; }

  /// <summary>
  ///   <para>Scientific degrees of deputy.</para>
  /// </summary>
  [DataMember(Name = "degrees", IsRequired = true)]
  public IEnumerable<string> Degrees { get; set; }

  /// <summary>
  ///   <para>Higher educations of deputy.</para>
  /// </summary>
  [DataMember(Name = "educations", IsRequired = true)]
  public IEnumerable<IEducation> Educations { get; set; }

  /// <summary>
  ///   <para>Scientific ranks of deputy.</para>
  /// </summary>
  [DataMember(Name = "ranks", IsRequired = true)]
  public IEnumerable<string> Ranks { get; set; }

  /// <summary>
  ///   <para>Association of deputy's with regions.</para>
  /// </summary>
  [DataMember(Name = "regions", IsRequired = true)]
  public IEnumerable<string> Regions { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="IDeputyInfo"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IDeputyInfo"/> to compare with this instance.</param>
  public int CompareTo(IDeputyInfo other) => string.Compare((this as IDeputyInfo).FullName, other?.FullName, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="IDeputyInfo"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IDeputyInfo other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IDeputyInfo);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Id));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyInfo"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="DeputyInfo"/>.</returns>
  public override string ToString() => (this as IDeputyInfo).FullName;
}