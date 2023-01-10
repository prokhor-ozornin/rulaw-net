using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma's agenda question.</para>
/// </summary>
public sealed class QuestionTranscriptsResult : IQuestionTranscriptsResult
{
  /// <summary>
  ///   <para>Collection of duma's meetings.</para>
  /// </summary>
  public IEnumerable<ITranscriptMeeting> Meetings { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="meetings"></param>
  public QuestionTranscriptsResult(IEnumerable<ITranscriptMeeting> meetings = null) => Meetings = meetings ?? new List<ITranscriptMeeting>();

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public QuestionTranscriptsResult(Info info) => Meetings = info.Meetings ?? new List<TranscriptMeeting>();

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public QuestionTranscriptsResult(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "result")]
  public sealed record Info : IResultable<IQuestionTranscriptsResult>
  {
    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [DataMember(Name = "meetings", IsRequired = true)]
    public List<TranscriptMeeting> Meetings { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IQuestionTranscriptsResult ToResult() => new QuestionTranscriptsResult(this);
  }
}