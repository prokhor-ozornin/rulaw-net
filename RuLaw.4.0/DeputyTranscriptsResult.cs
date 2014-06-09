using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of deputy's public speaches.</para>
  /// </summary>
  [Description("Transcript of deputy's public speaches")]
  [XmlType("result")]
  public class DeputyTranscriptsResult : IComparable<DeputyTranscriptsResult>, INameable
  {
    /// <summary>
    ///   <para>Number of questions.</para>
    /// </summary>
    [Description("Number of questions")]
    [JsonProperty("totalCount")]
    [XmlElement("totalCount")]
    public virtual int Count { get; set; }

    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [Description("Collection of duma's meetings")]
    [JsonProperty("meetings")]
    [XmlElement("meeting")]
    public virtual List<TranscriptMeeting> Meetings { get; set; }
    
    /// <summary>
    ///   <para>Full name of deputy.</para>
    /// </summary>
    [Description("Full name of deputy")]
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [Description("Number of results page")]
    [JsonProperty("page")]
    [XmlElement("page")]
    public virtual int Page { get; set; }

    /// <summary>
    ///   <para>Size of results page.</para>
    /// </summary>
    [Description("Size of results page")]
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
    ///   <para>Compares the current transcript with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="DeputyTranscriptsResult"/> to compare with this instance.</param>
    public virtual int CompareTo(DeputyTranscriptsResult other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current transcript.</para>
    /// </summary>
    /// <returns>A string that represents the current transcript.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}