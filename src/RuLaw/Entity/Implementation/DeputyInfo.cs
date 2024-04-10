using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Detailed deputy information.</para>
/// </summary>
public sealed class DeputyInfo : IDeputyInfo
{
  /// <summary>
  ///   <para>Unique identifier of deputy.</para>
  /// </summary>
  public long? Id { get; }

  /// <summary>
  ///   <para>Whether deputy has authority and power at present moment.</para>
  /// </summary>
  public bool? Active { get; }

  /// <summary>
  ///   <para>First name of deputy.</para>
  /// </summary>
  public string FirstName { get; }

  /// <summary>
  ///   <para>Last name of deputy.</para>
  /// </summary>
  public string LastName { get; }

  /// <summary>
  ///   <para>Middle name of deputy.</para>
  /// </summary>
  public string MiddleName { get; }

  /// <summary>
  ///   <para>Birth date of deputy.</para>
  /// </summary>
  public DateTimeOffset? BirthDate { get; }

  /// <summary>
  ///   <para>Start date of deputy's authorities in last convocation.</para>
  /// </summary>
  public DateTimeOffset? WorkStartDate { get; }

  /// <summary>
  ///   <para>End date of deputy's authorities in last convocation.</para>
  /// </summary>
  public DateTimeOffset? WorkEndDate { get; }

  /// <summary>
  ///   <para>Identifier of deputy's political faction.</para>
  /// </summary>
  public long? FactionId { get; }

  /// <summary>
  ///   <para>Name of deputy's political faction.</para>
  /// </summary>
  public string FactionName { get; }

  /// <summary>
  ///   <para>Association of deputy's political faction with a region.</para>
  /// </summary>
  public string FactionRegion { get; }

  /// <summary>
  ///   <para>Role of deputy's in his political faction.</para>
  /// </summary>
  public string FactionRole { get; }

  /// <summary>
  ///   <para>Number of laws which have been initiated by the deputy.</para>
  /// </summary>
  public int? LawsCount { get; }

  /// <summary>
  ///   <para>Number of deputy's public speaches.</para>
  /// </summary>
  public int? SpeechesCount { get; }

  /// <summary>
  ///   <para>URL link for transcripts of deputy's speaches.</para>
  /// </summary>
  public string TranscriptLink { get; }

  /// <summary>
  ///   <para>URL link for deputy's votes.</para>
  /// </summary>
  public string VoteLink { get; }

  /// <summary>
  ///   <para>Collection of deputy's activities in committees.</para>
  /// </summary>
  public IEnumerable<IDeputyActivity> Activities { get; }

  /// <summary>
  ///   <para>Scientific degrees of deputy.</para>
  /// </summary>
  public IEnumerable<string> Degrees { get; }

  /// <summary>
  ///   <para>Higher educations of deputy.</para>
  /// </summary>
  public IEnumerable<IEducation> Educations { get; }

  /// <summary>
  ///   <para>Scientific ranks of deputy.</para>
  /// </summary>
  public IEnumerable<string> Ranks { get; }

  /// <summary>
  ///   <para>Association of deputy's with regions.</para>
  /// </summary>
  public IEnumerable<string> Regions { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="active"></param>
  /// <param name="firstName"></param>
  /// <param name="lastName"></param>
  /// <param name="middleName"></param>
  /// <param name="birthDate"></param>
  /// <param name="workStartDate"></param>
  /// <param name="workEndDate"></param>
  /// <param name="factionId"></param>
  /// <param name="factionName"></param>
  /// <param name="factionRegion"></param>
  /// <param name="factionRole"></param>
  /// <param name="lawsCount"></param>
  /// <param name="speechesCount"></param>
  /// <param name="transcriptLink"></param>
  /// <param name="voteLink"></param>
  /// <param name="activities"></param>
  /// <param name="degrees"></param>
  /// <param name="educations"></param>
  /// <param name="ranks"></param>
  /// <param name="regions"></param>
  public DeputyInfo(long? id = null,
                    bool? active = null,
                    string firstName = null,
                    string lastName = null,
                    string middleName = null,
                    DateTimeOffset? birthDate = null,
                    DateTimeOffset? workStartDate = null,
                    DateTimeOffset? workEndDate = null,
                    long? factionId = null,
                    string factionName = null,
                    string factionRegion = null,
                    string factionRole = null,
                    int? lawsCount = null,
                    int? speechesCount = null,
                    string transcriptLink = null,
                    string voteLink = null,
                    IEnumerable<IDeputyActivity> activities = null,
                    IEnumerable<string> degrees = null,
                    IEnumerable<IEducation> educations = null,
                    IEnumerable<string> ranks = null,
                    IEnumerable<string> regions = null)
  {
    Id = id;
    Active = active;
    FirstName = firstName;
    LastName = lastName;
    MiddleName = middleName;
    BirthDate = birthDate;
    WorkStartDate = workStartDate;
    WorkEndDate = workEndDate;
    FactionId = factionId;
    FactionName = factionName;
    FactionRegion = factionRegion;
    FactionRole = factionRole;
    LawsCount = lawsCount;
    SpeechesCount = speechesCount;
    TranscriptLink = transcriptLink;
    VoteLink = voteLink;
    Activities = activities ?? [];
    Degrees = degrees ?? [];
    Educations = educations ?? [];
    Ranks = ranks ?? [];
    Regions = regions ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyInfo(Info info)
  {
    Id = info.Id;
    Active = info.Active;
    FirstName = info.FirstName;
    LastName = info.LastName;
    MiddleName = info.MiddleName;
    BirthDate = info.BirthDate is not null ? DateTimeOffset.Parse(info.BirthDate) : null;
    WorkStartDate = info.WorkStartDate is not null ? DateTimeOffset.Parse(info.WorkStartDate) : null;
    WorkEndDate = info.WorkEndDate is not null ? DateTimeOffset.Parse(info.WorkEndDate) : null;
    FactionId = info.FactionId;
    FactionName = info.FactionName;
    FactionRegion = info.FactionRegion;
    FactionRole = info.FactionRole;
    LawsCount = info.LawsCount;
    SpeechesCount = info.SpeechesCount;
    TranscriptLink = info.TranscriptLink;
    VoteLink = info.VoteLink;
    Activities = info.Activities ?? [];
    Degrees = info.Degrees ?? [];
    Educations = info.Educations ?? [];
    Ranks = info.Ranks ?? [];
    Regions = info.Regions ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyInfo(object info) : this(new Info().SetState(info)) {}

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

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "deputy")]
  public sealed record Info : IResultable<IDeputyInfo>
  {
    /// <summary>
    ///   <para>Unique identifier of deputy.</para>
    /// </summary>
    [DataMember(Name = "id", IsRequired = true)]
    public long? Id { get; init; }

    /// <summary>
    ///   <para>Whether deputy has authority and power at present moment.</para>
    /// </summary>
    [DataMember(Name = "isActual", IsRequired = true)]
    public bool? Active { get; init; }

    /// <summary>
    ///   <para>First name of deputy.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string FirstName { get; init; }

    /// <summary>
    ///   <para>Last name of deputy.</para>
    /// </summary>
    [DataMember(Name = "family", IsRequired = true)]
    public string LastName { get; init; }

    /// <summary>
    ///   <para>Middle name of deputy.</para>
    /// </summary>
    [DataMember(Name = "patronymic", IsRequired = true)]
    public string MiddleName { get; init; }

    /// <summary>
    ///   <para>Birth date of deputy.</para>
    /// </summary>
    [DataMember(Name = "birthdate", IsRequired = true)]
    public string BirthDate { get; init; }

    /// <summary>
    ///   <para>Start date of deputy's authorities in last convocation.</para>
    /// </summary>
    [DataMember(Name = "credentialsStart", IsRequired = true)]
    public string WorkStartDate { get; init; }

    /// <summary>
    ///   <para>End date of deputy's authorities in last convocation.</para>
    /// </summary>
    [DataMember(Name = "credentialsEnd", IsRequired = true)]
    public string WorkEndDate { get; init; }

    /// <summary>
    ///   <para>Identifier of deputy's political faction.</para>
    /// </summary>
    [DataMember(Name = "factionId", IsRequired = true)]
    public long? FactionId { get; init; }

    /// <summary>
    ///   <para>Name of deputy's political faction.</para>
    /// </summary>
    [DataMember(Name = "factionName", IsRequired = true)]
    public string FactionName { get; init; }

    /// <summary>
    ///   <para>Association of deputy's political faction with a region.</para>
    /// </summary>
    [DataMember(Name = "factionRegion", IsRequired = true)]
    public string FactionRegion { get; init; }

    /// <summary>
    ///   <para>Role of deputy's in his political faction.</para>
    /// </summary>
    [DataMember(Name = "factionRole", IsRequired = true)]
    public string FactionRole { get; init; }

    /// <summary>
    ///   <para>Number of laws which have been initiated by the deputy.</para>
    /// </summary>
    [DataMember(Name = "lawcount", IsRequired = true)]
    public int? LawsCount { get; init; }

    /// <summary>
    ///   <para>Number of deputy's public speaches.</para>
    /// </summary>
    [DataMember(Name = "speachCount", IsRequired = true)]
    public int? SpeechesCount { get; init; }

    /// <summary>
    ///   <para>URL link for transcripts of deputy's speaches.</para>
    /// </summary>
    [DataMember(Name = "transcriptLink", IsRequired = true)]
    public string TranscriptLink { get; init; }

    /// <summary>
    ///   <para>URL link for deputy's votes.</para>
    /// </summary>
    [DataMember(Name = "voteLink", IsRequired = true)]
    public string VoteLink { get; init; }

    /// <summary>
    ///   <para>Collection of deputy's activities in committees.</para>
    /// </summary>
    [DataMember(Name = "activity", IsRequired = true)]
    public List<DeputyActivity> Activities { get; init; }

    /// <summary>
    ///   <para>Scientific degrees of deputy.</para>
    /// </summary>
    [DataMember(Name = "degrees", IsRequired = true)]
    public List<string> Degrees { get; init; }

    /// <summary>
    ///   <para>Higher educations of deputy.</para>
    /// </summary>
    [DataMember(Name = "educations", IsRequired = true)]
    public List<Education> Educations { get; init; }

    /// <summary>
    ///   <para>Scientific ranks of deputy.</para>
    /// </summary>
    [DataMember(Name = "ranks", IsRequired = true)]
    public List<string> Ranks { get; init; }

    /// <summary>
    ///   <para>Association of deputy's with regions.</para>
    /// </summary>
    [DataMember(Name = "regions", IsRequired = true)]
    public List<string> Regions { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IDeputyInfo ToResult() => new DeputyInfo(this);
  }
}