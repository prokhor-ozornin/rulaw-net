using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Part of meeting question's transcript.</para>
/// </summary>
public sealed class TranscriptMeetingQuestionPart : ITranscriptMeetingQuestionPart
{
  /// <summary>
  ///   <para>Start line of transcript's text fragment.</para>
  /// </summary>
  public int? StartLine { get; }

  /// <summary>
  ///   <para>End line of transcript's text fragment.</para>
  /// </summary>
  public int? EndLine { get; }

  /// <summary>
  ///   <para>Lines of transcript's fragment.</para>
  /// </summary>
  public IEnumerable<string> Lines { get; }

  /// <summary>
  ///   <para>List of question' votes.</para>
  /// </summary>
  public IEnumerable<ITranscriptVote> Votes { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="startLine"></param>
  /// <param name="endLine"></param>
  /// <param name="lines"></param>
  /// <param name="votes"></param>
  public TranscriptMeetingQuestionPart(int? startLine = null,
                                       int? endLine = null,
                                       IEnumerable<string> lines = null,
                                       IEnumerable<ITranscriptVote> votes = null)
  {
    StartLine = startLine;
    EndLine = endLine;
    Lines = lines ?? new List<string>();
    Votes = votes ?? new List<ITranscriptVote>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public TranscriptMeetingQuestionPart(Info info)
  {
    StartLine = info.StartLine;
    EndLine = info.EndLine;
    Lines = info.Lines ?? new List<string>();
    Votes = info.Votes ?? new List<TranscriptVote>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public TranscriptMeetingQuestionPart(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="ITranscriptMeetingQuestionPart"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ITranscriptMeetingQuestionPart"/> to compare with this instance.</param>
  public int CompareTo(ITranscriptMeetingQuestionPart other) => Nullable.Compare(StartLine, other?.StartLine);

  /// <summary>
  ///   <para>Determines whether two <see cref="ITranscriptMeetingQuestionPart"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(ITranscriptMeetingQuestionPart other) => this.Equality(other, nameof(StartLine), nameof(EndLine));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as ITranscriptMeetingQuestionPart);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(StartLine), nameof(EndLine));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="TranscriptMeetingQuestionPart"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="TranscriptMeetingQuestionPart"/>.</returns>
  public override string ToString() => (this as ITranscriptMeetingQuestionPart).Text;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "part")]
  public sealed record Info : IResultable<ITranscriptMeetingQuestionPart>
  {
    /// <summary>
    ///   <para>Start line of transcript's text fragment.</para>
    /// </summary>
    [DataMember(Name = "startLine", IsRequired = true)]
    public int? StartLine { get; init; }

    /// <summary>
    ///   <para>End line of transcript's text fragment.</para>
    /// </summary>
    [DataMember(Name = "endLine", IsRequired = true)]
    public int? EndLine { get; init; }

    /// <summary>
    ///   <para>Lines of transcript's fragment.</para>
    /// </summary>
    [DataMember(Name = "lines", IsRequired = true)]
    public List<string> Lines { get; init; }

    /// <summary>
    ///   <para>List of question' votes.</para>
    /// </summary>
    [DataMember(Name = "votes", IsRequired = true)]
    public List<TranscriptVote> Votes { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ITranscriptMeetingQuestionPart ToResult() => new TranscriptMeetingQuestionPart(this);
  }
}