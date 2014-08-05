using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of Duma's agenda question.</para>
  /// </summary>
  public sealed class QuestionTranscriptsResult : IQuestionTranscriptsResult
  {
    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<ITranscriptMeeting> Meetings
    {
      get { return this.MeetingsOriginal.Cast<ITranscriptMeeting>(); }
    }

    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [JsonProperty("meetings")]
    [XmlElement("meeting")]
    public List<TranscriptMeeting> MeetingsOriginal { get; set; }

    /// <summary>
    ///   <para>Creates new transcript of Duma's agenda question.</para>
    /// </summary>
    public QuestionTranscriptsResult()
    {
      this.MeetingsOriginal = new List<TranscriptMeeting>();
    }
  }
}