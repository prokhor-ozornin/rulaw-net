using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of Duma's agenda question.</para>
  /// </summary>
  public sealed class QuestionTranscriptsResult
  {
    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [JsonProperty("meetings")]
    [XmlElement("meeting")]
    public List<TranscriptMeeting> Meetings { get; set; }

    /// <summary>
    ///   <para>Creates new transcript of Duma's agenda question.</para>
    /// </summary>
    public QuestionTranscriptsResult()
    {
      this.Meetings = new List<TranscriptMeeting>();
    }
  }
}