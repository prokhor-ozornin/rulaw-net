using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of Duma's law.</para>
  /// </summary>
  [XmlType("result")]
  public class LawTranscriptsResult : IComparable<LawTranscriptsResult>, IEquatable<LawTranscriptsResult>, INameable
  {
    /// <summary>
    ///   <para>Law's comments.</para>
    /// </summary>
    [JsonProperty("comments")]
    [XmlElement("comments")]
    public virtual string Comments { get; set; }

    /// <summary>
    ///   <para>List of law's associated meetings.</para>
    /// </summary>
    [JsonProperty("meetings")]
    [XmlElement("meeting")]
    public virtual List<TranscriptMeeting> Meetings { get; set; }

    /// <summary>
    ///   <para>Name of law.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Number of law.</para>
    /// </summary>
    [JsonProperty("number")]
    [XmlElement("number")]
    public virtual string Number { get; set; }

    /// <summary>
    ///   <para>Creates new transcript of Duma's law.</para>
    /// </summary>
    public LawTranscriptsResult()
    {
      this.Meetings = new List<TranscriptMeeting>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="LawTranscriptsResult"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="LawTranscriptsResult"/> to compare with this instance.</param>
    public virtual int CompareTo(LawTranscriptsResult other)
    {
      return this.Number.CompareTo(other.Number, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="LawTranscriptsResult"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(LawTranscriptsResult other)
    {
      return this.Equality(other, transcript => transcript.Number);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as LawTranscriptsResult);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(transcript => transcript.Number);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="LawTranscriptsResult"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="LawTranscriptsResult"/>.</returns>
    public override string ToString()
    {
      return this.Number;
    }
  }
}