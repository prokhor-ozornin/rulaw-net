using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma's agenda question.</para>
/// </summary>
[DataContract(Name = "result")]
public sealed class QuestionTranscriptsResult : IQuestionTranscriptsResult
{
  /// <summary>
  ///   <para>Collection of duma's meetings.</para>
  /// </summary>
  [DataMember(Name = "meetings", IsRequired = true)]
  public IEnumerable<ITranscriptMeeting> Meetings { get; set; }
}