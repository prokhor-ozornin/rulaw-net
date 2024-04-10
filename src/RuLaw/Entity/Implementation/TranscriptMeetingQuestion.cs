using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcript's question.</para>
/// </summary>
public sealed class TranscriptMeetingQuestion : ITranscriptMeetingQuestion
{
  /// <summary>
  ///   <para>Title of question.</para>
  /// </summary>
  public string Name { get; }

  /// <summary>
  ///   <para>Question's review stage.</para>
  /// </summary>
  public string Stage { get; }

  /// <summary>
  ///   <para>List of transcript's fragments.</para>
  /// </summary>
  public IEnumerable<ITranscriptMeetingQuestionPart> Parts { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="name"></param>
  /// <param name="stage"></param>
  /// <param name="parts"></param>
  public TranscriptMeetingQuestion(string name = null,
                                   string stage = null,
                                   IEnumerable<ITranscriptMeetingQuestionPart> parts = null)
  {
    Name = name;
    Stage = stage;
    Parts = parts ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public TranscriptMeetingQuestion(Info info)
  {
    Name = info.Name;
    Stage = info.Stage;
    Parts = info.Parts ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public TranscriptMeetingQuestion(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="ITranscriptMeetingQuestion"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ITranscriptMeetingQuestion"/> to compare with this instance.</param>
  public int CompareTo(ITranscriptMeetingQuestion other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Determines whether two <see cref="ITranscriptMeetingQuestion"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(ITranscriptMeetingQuestion other) => this.Equality(other, nameof(Name), nameof(Stage));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as ITranscriptMeetingQuestion);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Name), nameof(Stage));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="TranscriptMeetingQuestion"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="TranscriptMeetingQuestion"/>.</returns>
  public override string ToString() => Name ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "question")]
  public sealed record Info : IResultable<ITranscriptMeetingQuestion>
  {
    /// <summary>
    ///   <para>Title of question.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string Name { get; init; }

    /// <summary>
    ///   <para>Question's review stage.</para>
    /// </summary>
    [DataMember(Name = "stage", IsRequired = true)]
    public string Stage { get; init; }

    /// <summary>
    ///   <para>List of transcript's fragments.</para>
    /// </summary>
    [DataMember(Name = "parts", IsRequired = true)]
    public List<TranscriptMeetingQuestionPart> Parts { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ITranscriptMeetingQuestion ToResult() => new TranscriptMeetingQuestion(this);
  }
}