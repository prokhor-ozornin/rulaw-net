namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Transcript of deputy's public speaches.</para>
  /// </summary>
  [XmlType("result")]
  public sealed class DeputyTranscriptsResult : IComparable<IDeputyTranscriptsResult>, IDeputyTranscriptsResult
  {
    /// <summary>
    ///   <para>Number of questions.</para>
    /// </summary>
    [JsonProperty("totalCount")]
    [XmlElement("totalCount")]
    public int Count { get; set; }

    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<ITranscriptMeeting> Meetings
    {
      get { return MeetingsOriginal.Cast<ITranscriptMeeting>(); }
    }

    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [JsonProperty("meetings")]
    [XmlElement("meeting")]
    public List<TranscriptMeeting> MeetingsOriginal { get; set; }
    
    /// <summary>
    ///   <para>Full name of deputy.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [JsonProperty("page")]
    [XmlElement("page")]
    public int Page { get; set; }

    /// <summary>
    ///   <para>Size of results page.</para>
    /// </summary>
    [JsonProperty("pageSize")]
    [XmlElement("pageSize")]
    public int PageSize { get; set; }

    /// <summary>
    ///   <para>Creates new deputy's transcript.</para>
    /// </summary>
    public DeputyTranscriptsResult()
    {
      MeetingsOriginal = new List<TranscriptMeeting>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="IDeputyTranscriptsResult"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IDeputyTranscriptsResult"/> to compare with this instance.</param>
    public int CompareTo(IDeputyTranscriptsResult other)
    {
      return Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyTranscriptsResult"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="DeputyTranscriptsResult"/>.</returns>
    public override string ToString()
    {
      return Name;
    }
  }
}