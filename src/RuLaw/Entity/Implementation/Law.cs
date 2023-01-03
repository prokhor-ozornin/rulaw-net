using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Duma's law.</para>
/// </summary>
public sealed class Law : ILaw
{
  /// <summary>
  ///   <para>Unique identifier of law.</para>
  /// </summary>
  public long? Id { get; }

  /// <summary>
  ///   <para>Name of law.</para>
  /// </summary>
  public string Name { get; }

  /// <summary>
  ///   <para>Date when law was suggested for review.</para>
  /// </summary>
  public DateTimeOffset? Date { get; }

  /// <summary>
  ///   <para>Number of law.</para>
  /// </summary>
  public string Number { get; }

  /// <summary>
  ///   <para>Subject of law.</para>
  /// </summary>
  public ILawSubject Subject { get; }

  /// <summary>
  ///   <para>Type of law.</para>
  /// </summary>
  public ILawType Type { get; }

  /// <summary>
  ///   <para>URL address of law in ASOZD system.</para>
  /// </summary>
  public string Url { get; }

  /// <summary>
  ///   <para>URL address of law's transcript.</para>
  /// </summary>
  public string TranscriptUrl { get; }

  /// <summary>
  ///   <para>Law comments.</para>
  /// </summary>
  public string Comments { get; }

  /// <summary>
  ///   <para>Last event, associated with a law.</para>
  /// </summary>
  public ILawEvent LastEvent { get; }

  /// <summary>
  ///   <para>Committees, associated with a law.</para>
  /// </summary>
  public ILawCommittees Committees { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="date"></param>
  /// <param name="number"></param>
  /// <param name="subject"></param>
  /// <param name="type"></param>
  /// <param name="url"></param>
  /// <param name="transcriptUrl"></param>
  /// <param name="comments"></param>
  /// <param name="lastEvent"></param>
  /// <param name="committees"></param>
  public Law(long? id = null,
             string name = null,
             DateTimeOffset? date = null,
             string number = null,
             ILawSubject subject = null,
             ILawType type = null,
             string url = null,
             string transcriptUrl = null,
             string comments = null,
             ILawEvent lastEvent = null,
             ILawCommittees committees = null)
  {
    Id = id;
    Name = name;
    Date = date;
    Number = number;
    Subject = subject;
    Type = type;
    Url = url;
    TranscriptUrl = transcriptUrl;
    Comments = comments;
    LastEvent = lastEvent;
    Committees = committees;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Law(Info info)
  {
    Id = info.Id;
    Name = info.Name;
    Date = info.Date != null ? DateTimeOffset.Parse(info.Date) : null;
    Number = info.Number;
    Subject = info.Subject;
    Type = info.Type;
    Url = info.Url;
    TranscriptUrl = info.TranscriptUrl;
    Comments = info.Comments;
    LastEvent = info.LastEvent;
    Committees = info.Committees;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Law(object info) : this(new Info().SetState(info)) {}

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
  public override string ToString() => Name;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "law")]
  public sealed record Info : IResultable<ILaw>
  {
    /// <summary>
    ///   <para>Unique identifier of law.</para>
    /// </summary>
    [DataMember(Name = "id", IsRequired = true)]
    public long? Id { get; init; }

    /// <summary>
    ///   <para>Name of law.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string Name { get; init; }

    /// <summary>
    ///   <para>Date when law was suggested for review.</para>
    /// </summary>
    [DataMember(Name = "introductionDate", IsRequired = true)]
    public string Date { get; init; }

    /// <summary>
    ///   <para>Number of law.</para>
    /// </summary>
    [DataMember(Name = "number", IsRequired = true)]
    public string Number { get; init; }

    /// <summary>
    ///   <para>Subject of law.</para>
    /// </summary>
    [DataMember(Name = "subject", IsRequired = true)]
    public LawSubject Subject { get; init; }

    /// <summary>
    ///   <para>Type of law.</para>
    /// </summary>
    [DataMember(Name = "type", IsRequired = true)]
    public LawType Type { get; init; }

    /// <summary>
    ///   <para>URL address of law in ASOZD system.</para>
    /// </summary>
    [DataMember(Name = "url", IsRequired = true)]
    public string Url { get; init; }

    /// <summary>
    ///   <para>URL address of law's transcript.</para>
    /// </summary>
    [DataMember(Name = "transcriptUrl", IsRequired = true)]
    public string TranscriptUrl { get; init; }

    /// <summary>
    ///   <para>Law comments.</para>
    /// </summary>
    [DataMember(Name = "comments", IsRequired = true)]
    public string Comments { get; init; }

    /// <summary>
    ///   <para>Last event, associated with a law.</para>
    /// </summary>
    [DataMember(Name = "lastEvent", IsRequired = true)]
    public LawEvent LastEvent { get; init; }

    /// <summary>
    ///   <para>Committees, associated with a law.</para>
    /// </summary>
    [DataMember(Name = "committees", IsRequired = true)]
    public LawCommittees Committees { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ILaw ToResult() => new Law(this);
  }
}