namespace RuLaw
{
  using System;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Represents abstract business domain entity that can have a have.</para>
  /// </summary>
  public abstract class NameableEntity<ENTITY> : IComparable<ENTITY>, IEquatable<ENTITY>, IEntity, INameable where ENTITY : NameableEntity<ENTITY>
  {
    /// <summary>
    ///   <para>Unique identifier of entity.</para>
    /// </summary>
    [JsonProperty("id")]
    [XmlElement("id")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Name of entity.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Compares the current entity with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="ENTITY"/> to compare with this instance.</param>
    public virtual int CompareTo(ENTITY other)
    {
      return Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two entities instances are equal.</para>
    /// </summary>
    /// <param name="other">The entity to compare with the current one.</param>
    /// <returns><c>true</c> if specified entity is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(ENTITY other)
    {
      return this.Equality(other, entity => entity.Id);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return Equals(other as ENTITY);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(entity => entity.Id);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
    /// </summary>
    /// <returns>A string that represents the current entity.</returns>
    public override string ToString()
    {
      return Name;
    }
  }
}