using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of deputy's public speaches.</para>
  /// </summary>
  [XmlType("result")]
  public class DeputyTranscriptsResult : IComparable<DeputyTranscriptsResult>, INameable
  {
    /// <summary>
    ///   <para>Number of questions.</para>
    /// </summary>
    [JsonProperty("totalCount")]
    [XmlElement("totalCount")]
    public virtual int Count { get; set; }

    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [JsonProperty("meetings")]
    [XmlElement("meeting")]
    public virtual List<TranscriptMeeting> Meetings { get; set; }
    
    /// <summary>
    ///   <para>Full name of deputy.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [JsonProperty("page")]
    [XmlElement("page")]
    public virtual int Page { get; set; }

    /// <summary>
    ///   <para>Size of results page.</para>
    /// </summary>
    [JsonProperty("pageSize")]
    [XmlElement("pageSize")]
    public virtual int PageSize { get; set; }

    /// <summary>
    ///   <para>Creates new deputy's transcript.</para>
    /// </summary>
    public DeputyTranscriptsResult()
    {
      this.Meetings = new List<TranscriptMeeting>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="DeputyTranscriptsResult"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="DeputyTranscriptsResult"/> to compare with this instance.</param>
    public virtual int CompareTo(DeputyTranscriptsResult other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyTranscriptsResult"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="DeputyTranscriptsResult"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}