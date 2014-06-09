using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of Duma's agenda question.</para>
  /// </summary>
  [Description("Transcript of Duma's agenda question")]
  [XmlType("result")]
  public sealed class QuestionTranscriptsResult
  {
    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [Description("Collection of duma's meetings")]
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