﻿using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Law workflow instance.</para>
/// </summary>
public sealed class Instance : IInstance
{
  /// <summary>
  ///   <para>Unique identifier of entity.</para>
  /// </summary>
  public long? Id { get; }

  /// <summary>
  ///   <para>Name of entity.</para>
  /// </summary>
  public string Name { get; }

  /// <summary>
  ///   <para>Whether the instance is active at present or not.</para>
  /// </summary>
  public bool? Active { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="active"></param>
  public Instance(long? id = null,
                  string name = null,
                  bool? active = null)
  {
    Id = id;
    Name = name;
    Active = active;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Instance(Info info)
  {
    Id = info.Id;
    Name = info.Name;
    Active = info.Active;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Instance(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current entity with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the objects being compared.</returns>
  /// <param name="other">The <see cref="IInstance"/> to compare with this instance.</param>
  public int CompareTo(IInstance other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Determines whether two entities instances are equal.</para>
  /// </summary>
  /// <param name="other">The entity to compare with the current one.</param>
  /// <returns><c>true</c> if specified entity is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IInstance other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IInstance);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Id));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "instance")]
  public record Info : IResultable<IInstance>
  {
    /// <summary>
    ///   <para>Unique identifier of entity.</para>
    /// </summary>
    [DataMember(Name = "id", IsRequired = true)]
    public long? Id { get; init; }

    /// <summary>
    ///   <para>Name of entity.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string Name { get; init; }

    /// <summary>
    ///   <para>Whether the instance is active at present or not.</para>
    /// </summary>
    [DataMember(Name = "isCurrent", IsRequired = true)]
    public bool? Active { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IInstance ToResult() => new Instance(this);
  }
}