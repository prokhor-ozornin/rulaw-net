using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Deputy's higher education information record.</para>
/// </summary>
[DataContract(Name = "education")]
public sealed class Education : IEducation
{
  /// <summary>
  ///   <para>Name of education institution.</para>
  /// </summary>
  [DataMember(Name = "institution", IsRequired = true)]
  public string Institution { get; set; }

  /// <summary>
  ///   <para>Year of graduation.</para>
  /// </summary>
  [DataMember(Name = "year", IsRequired = true)]
  public short? Year { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="IEducation"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IEducation"/> to compare with this instance.</param>
  public int CompareTo(IEducation other) => Nullable.Compare(Year, other?.Year);

  /// <summary>
  ///   <para>Determines whether two <see cref="IEducation"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IEducation other) => this.Equality(other, nameof(Institution), nameof(Year));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IEducation);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Institution), nameof(Year));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Education"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Education"/>.</returns>
  public override string ToString() => $"{Institution} ({Year})";
}