using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma's meeting.</para>
/// </summary>
public sealed class DateTranscriptMeeting : IDateTranscriptMeeting
{
  /// <summary>
  ///   <para>Date of meeting.</para>
  /// </summary>
  public DateTimeOffset? Date { get; }

  /// <summary>
  ///   <para>Number of meeting.</para>
  /// </summary>
  public int? Number { get; }

  /// <summary>
  ///   <para>Transcript's text lines.</para>
  /// </summary>
  public IEnumerable<string> Lines { get; }

  /// <summary>
  ///   <para>Meeting's votes.</para>
  /// </summary>
  public IEnumerable<ITranscriptVote> Votes { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="date"></param>
  /// <param name="number"></param>
  /// <param name="lines"></param>
  /// <param name="votes"></param>
  public DateTranscriptMeeting(DateTimeOffset? date = null,
                               int? number = null,
                               IEnumerable<string>? lines = null,
                               IEnumerable<ITranscriptVote>? votes = null)
  {
    Date = date;
    Number = number;
    Lines = lines ?? new List<string>();
    Votes = votes ?? new List<ITranscriptVote>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DateTranscriptMeeting(Info info)
  {
    Date = info.Date;
    Number = info.Number;
    Lines = info.Lines ?? new List<string>();
    Votes = info.Votes ?? new List<TranscriptVote>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DateTranscriptMeeting(object info) : this(new Info().Properties(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="IDateTranscriptMeeting"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IDateTranscriptMeeting"/> to compare with this instance.</param>
  public int CompareTo(IDateTranscriptMeeting? other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="IDateTranscriptMeeting"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IDateTranscriptMeeting? other) => this.Equality(other, nameof(Date));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object? other) => Equals(other as IDateTranscriptMeeting);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Date));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DateTranscriptMeeting"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="DateTranscriptMeeting"/>.</returns>
  public override string ToString() => (this as IDateTranscriptMeeting).Text;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "meeting")]
  public sealed record Info : IResultable<IDateTranscriptMeeting>
  {
    /// <summary>
    ///   <para>Date of meeting.</para>
    /// </summary>
    [DataMember(Name = "date", IsRequired = true)]
    public DateTimeOffset? Date { get; init; }

    /// <summary>
    ///   <para>Number of meeting.</para>
    /// </summary>
    [DataMember(Name = "number", IsRequired = true)]
    public int? Number { get; init; }

    /// <summary>
    ///   <para>Transcript's text lines.</para>
    /// </summary>
    [DataMember(Name = "lines", IsRequired = true)]
    public List<string>? Lines { get; init; }

    /// <summary>
    ///   <para>Meeting's votes.</para>
    /// </summary>
    [DataMember(Name = "votes", IsRequired = true)]
    public List<TranscriptVote>? Votes { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IDateTranscriptMeeting Result() => new DateTranscriptMeeting(this);
  }
}