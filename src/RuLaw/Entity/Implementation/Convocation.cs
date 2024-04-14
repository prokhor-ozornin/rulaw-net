using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Duma's convocation.</para>
/// </summary>
[DataContract(Name = "period")]
public sealed class Convocation : IConvocation
{
  /// <summary>
  ///   <para>Unique identifier of entity.</para>
  /// </summary>
  [DataMember(Name = "id", IsRequired = true)]
  public long? Id { get; set; }

  /// <summary>
  ///   <para>Name of the entity.</para>
  /// </summary>
  [DataMember(Name = "name", IsRequired = true)]
  public string Name { get; set; }

  /// <summary>
  ///   <para>Start date of authority functioning.</para>
  /// </summary>
  [DataMember(Name = "startDate", IsRequired = true)]
  public DateTimeOffset? FromDate { get; set; }

  /// <summary>
  ///   <para>End date of authority functioning.</para>
  /// </summary>
  [DataMember(Name = "stopDate")]
  public DateTimeOffset? ToDate { get; set; }

  /// <summary>
  ///   <para>Collection of sessions which are part of the convocation.</para>
  /// </summary>
  [DataMember(Name = "sessions", IsRequired = true)]
  public IEnumerable<ISession> Sessions { get; set; }

  /// <summary>
  ///   <para>Compares the current entity with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the objects being compared.</returns>
  /// <param name="other">The <see cref="IConvocation"/> to compare with this instance.</param>
  public int CompareTo(IConvocation other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Determines whether two entities instances are equal.</para>
  /// </summary>
  /// <param name="other">The entity to compare with the current one.</param>
  /// <returns><c>true</c> if specified entity is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IConvocation other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IConvocation);

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
}