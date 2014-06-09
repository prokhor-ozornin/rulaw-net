using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Deputy's activity record.</para>
  /// </summary>
  [Description("Deputy's activity record")]
  [XmlType("activity")]
  public class DeputyActivity : IComparable<DeputyActivity>, IEquatable<DeputyActivity>, INameable
  {
    /// <summary>
    ///   <para>Identifier of committee.</para>
    /// </summary>
    [Description("Identifier of committee")]
    [JsonProperty("subdivisionId")]
    [XmlElement("subdivisionId")]
    public virtual long CommitteeId { get; set; }

    /// <summary>
    ///   <para>Genitive name of committee.</para>
    /// </summary>
    [Description("Genitive name of committee")]
    [JsonProperty("subdivisionNameGenitive")]
    [XmlElement("subdivisionNameGenitive")]
    public virtual string CommitteeNameGenitive { get; set; }

    /// <summary>
    ///   <para>Name of activity.</para>
    /// </summary>
    [Description("Name of activity")]
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Compares the current activity with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="DeputyActivity"/> to compare with this instance.</param>
    public virtual int CompareTo(DeputyActivity other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two activities instances are equal.</para>
    /// </summary>
    /// <param name="other">The activity to compare with the current one.</param>
    /// <returns><c>true</c> if specified activity is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(DeputyActivity other)
    {
      return this.Equality(other, activity => activity.Name, activity => activity.CommitteeId);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as DeputyActivity);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(activity => activity.Name, activity => activity.CommitteeId);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current activity.</para>
    /// </summary>
    /// <returns>A string that represents the current activity.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}