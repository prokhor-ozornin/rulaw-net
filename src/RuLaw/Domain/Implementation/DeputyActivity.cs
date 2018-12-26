namespace RuLaw
{
  using System;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Deputy's activity record.</para>
  /// </summary>
  [XmlType("activity")]
  public sealed class DeputyActivity : IComparable<IDeputyActivity>, IEquatable<IDeputyActivity>, IDeputyActivity
  {
    /// <summary>
    ///   <para>Identifier of committee.</para>
    /// </summary>
    [JsonProperty("subdivisionId")]
    [XmlElement("subdivisionId")]
    public long CommitteeId { get; set; }

    /// <summary>
    ///   <para>Genitive name of committee.</para>
    /// </summary>
    [JsonProperty("subdivisionNameGenitive")]
    [XmlElement("subdivisionNameGenitive")]
    public string CommitteeNameGenitive { get; set; }

    /// <summary>
    ///   <para>Name of activity.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="IDeputyActivity"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IDeputyActivity"/> to compare with this instance.</param>
    public int CompareTo(IDeputyActivity other)
    {
      return Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="IDeputyActivity"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(IDeputyActivity other)
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
      return Equals(other as IDeputyActivity);
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
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyActivity"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="DeputyActivity"/>.</returns>
    public override string ToString()
    {
      return Name;
    }
  }
}