using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Detailed deputy information.</para>
  /// </summary>
  [Description("Detailed deputy information")]
  [XmlType("deputy")]
  public class DeputyInfo : IComparable<DeputyInfo>, IEquatable<DeputyInfo>, IRuLawEntity, IActive
  {
    /// <summary>
    ///   <para>Unique identifier of deputy.</para>
    /// </summary>
    [Description("Unique identifier of deputy")]
    [JsonProperty("id")]
    [XmlElement("id")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Whether deputy has authority and power at present moment.</para>
    /// </summary>
    [Description("Whether deputy has authority and power at present moment")]
    [JsonProperty("isActual")]
    [XmlElement("isActual")]
    public virtual bool Active { get; set; }

    /// <summary>
    ///   <para>Collection of deputy's activities in committees.</para>
    /// </summary>
    [Description("Collection of deputy's activities in committees")]
    [JsonProperty("activity")]
    [XmlElement("activity")]
    public virtual List<DeputyActivity> Activities { get; set; }

    /// <summary>
    ///   <para>Birth date of deputy.</para>
    /// </summary>
    [Description("Birth date of deputy")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime BirthDate { get; set; }

    /// <summary>
    ///   <para>Birth date of deputy.</para>
    /// </summary>
    [Description("Birth date of deputy")]
    [JsonProperty("birthdate")]
    [XmlElement("birthdate")]
    public virtual string BirthDateString
    {
      get { return this.BirthDate.ISO8601(); }
      set { this.BirthDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Scientific degrees of deputy.</para>
    /// </summary>
    [Description("Scientific degrees of deputy")]
    [JsonProperty("degrees")]
    [XmlElement("degree")]
    public virtual List<string> Degrees { get; set; }

    /// <summary>
    ///   <para>Higher educations of deputy.</para>
    /// </summary>
    [Description("Higher educations of deputy")]
    [JsonProperty("educations")]
    [XmlElement("education")]
    public virtual List<Education> Educations { get; set; }

    /// <summary>
    ///   <para>Identifier of deputy's political faction.</para>
    /// </summary>
    [Description("Identifier of deputy's political factionn")]
    [JsonProperty("factionId")]
    [XmlElement("factionId")]
    public virtual long FactionId { get; set; }

    /// <summary>
    ///   <para>Name of deputy's political faction.</para>
    /// </summary>
    [Description("Name of deputy's political faction")]
    [JsonProperty("factionName")]
    [XmlElement("factionName")]
    public virtual string FactionName { get; set; }

    /// <summary>
    ///   <para>Association of deputy's political faction with a region.</para>
    /// </summary>
    [Description("Association of deputy's political faction with a region")]
    [JsonProperty("factionRegion")]
    [XmlElement("factionRegion")]
    public virtual string FactionRegion { get; set; }

    /// <summary>
    ///   <para>Role of deputy's in his political faction.</para>
    /// </summary>
    [Description("Role of deputy's in his political faction")]
    [JsonProperty("factionRole")]
    [XmlElement("factionRole")]
    public virtual string FactionRole { get; set; }

    /// <summary>
    ///   <para>First name of deputy.</para>
    /// </summary>
    [Description("First name of deputy")]
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string FirstName { get; set; }

    /// <summary>
    ///   <para>Full name of deputy.</para>
    /// </summary>
    [Description("Full name of deputy")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual string FullName
    {
      get { return "{0} {1} {2}".FormatSelf(this.LastName, this.FirstName, this.MiddleName).Trim(); }
    }

    /// <summary>
    ///   <para>Last name of deputy.</para>
    /// </summary>
    [Description("Last name of deputy")]
    [JsonProperty("family")]
    [XmlElement("family")]
    public virtual string LastName { get; set; }

    /// <summary>
    ///   <para>Number of laws which have been initiated by the deputy.</para>
    /// </summary>
    [Description("Number of laws which have been initiated by the deputy")]
    [JsonProperty("lawcount")]
    [XmlElement("lawcount")]
    public virtual int LawsCount { get; set; }

    /// <summary>
    ///   <para>Middle name of deputy.</para>
    /// </summary>
    [Description("Middle name of deputy")]
    [JsonProperty("patronymic")]
    [XmlElement("patronymic")]
    public virtual string MiddleName { get; set; }

    /// <summary>
    ///   <para>Scientific ranks of deputy.</para>
    /// </summary>
    [Description("Scientific ranks of deputy")]
    [JsonProperty("ranks")]
    [XmlElement("rank")]
    public virtual List<string> Ranks { get; set; }

    /// <summary>
    ///   <para>Association of deputy's with regions.</para>
    /// </summary>
    [Description("Association of deputy's with regions")]
    [JsonProperty("regions")]
    [XmlElement("region")]
    public virtual List<string> Regions { get; set; }

    /// <summary>
    ///   <para>Number of deputy's public speaches.</para>
    /// </summary>
    [Description("Number of deputy's public speaches")]
    [JsonProperty("speachCount")]
    [XmlElement("speachCount")]
    public virtual int SpeachesCount { get; set; }

    /// <summary>
    ///   <para>URL link for transcripts of deputy's speaches.</para>
    /// </summary>
    [Description("URL link for transcripts of deputy's speaches")]
    [JsonProperty("transcriptLink")]
    [XmlElement("transcriptLink")]
    public virtual string TranscriptLink { get; set; }

    /// <summary>
    ///   <para>URL link for deputy's votes.</para>
    /// </summary>
    [Description("URL link for deputy's votes")]
    [JsonProperty("voteLink")]
    [XmlElement("voteLink")]
    public virtual string VoteLink { get; set; }

    /// <summary>
    ///   <para>Start date of deputy's authorities in last convocation.</para>
    /// </summary>
    [Description("Start date of deputy's authorities in last convocation")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime WorkStartDate { get; set; }

    /// <summary>
    ///   <para>Start date of deputy's authorities in last convocation.</para>
    /// </summary>
    [Description("Start date of deputy's authorities in last convocation")]
    [JsonProperty("credentialsStart")]
    [XmlElement("credentialsStart")]
    public virtual string WorkStartDateString
    {
      get { return this.WorkStartDate.ISO8601(); }
      set { this.WorkStartDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>End date of deputy's authorities in last convocation.</para>
    /// </summary>
    [Description("End date of deputy's authorities in last convocation")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual DateTime? WorkEndDate { get; set; }

    /// <summary>
    ///   <para>End date of deputy's authorities in last convocation.</para>
    /// </summary>
    [Description("End date of deputy's authorities in last convocation")]
    [JsonProperty("credentialsEnd")]
    [XmlElement("credentialsEnd")]
    public virtual string WorkEndDateString
    {
      get { return this.WorkEndDate != null ? this.WorkEndDate.Value.ISO8601() : null; }
      set { this.WorkEndDate = value.IsEmpty() ? (DateTime?)null : DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Creates new deputy info.</para>
    /// </summary>
    public DeputyInfo()
    {
      this.Activities = new List<DeputyActivity>();
      this.Degrees = new List<string>();
      this.Educations = new List<Education>();
      this.Ranks = new List<string>();
      this.Regions = new List<string>();
    }

    /// <summary>
    ///   <para>Compares the current deputy with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="DeputyInfo"/> to compare with this instance.</param>
    public virtual int CompareTo(DeputyInfo other)
    {
      return this.FullName.CompareTo(other.FullName, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two deputies instances are equal.</para>
    /// </summary>
    /// <param name="other">The deputy to compare with the current one.</param>
    /// <returns><c>true</c> if specified deputy is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(DeputyInfo other)
    {
      return this.Equality(other, deputy => deputy.Id);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as DeputyInfo);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(deputy => deputy.Id);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current deputy.</para>
    /// </summary>
    /// <returns>A string that represents the current deputy.</returns>
    public override string ToString()
    {
      return this.FullName;
    }
  }
}