using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Question of Duma's session.</para>
/// </summary>
[DataContract(Name = "question")]
public sealed class Question : IQuestion
{
  /// <summary>
  ///   <para>Title of question.</para>
  /// </summary>
  [DataMember(Name = "name", IsRequired = true)]
  public string Name { get; set; }

  /// <summary>
  ///   <para>Date of session.</para>
  /// </summary>
  [DataMember(Name = "datez", IsRequired = true)]
  public DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Code of question.</para>
  /// </summary>
  [DataMember(Name = "kodvopr", IsRequired = true)]
  public int? Code { get; set; }

  /// <summary>
  ///   <para>Code of session.</para>
  /// </summary>
  [DataMember(Name = "kodz", IsRequired = true)]
  public int? SessionCode { get; set; }

  /// <summary>
  ///   <para>First line in question's transcript.</para>
  /// </summary>
  [DataMember(Name = "nbegin", IsRequired = true)]
  public int? StartLine { get; set; }

  /// <summary>
  ///   <para>Last line in question's transcript.</para>
  /// </summary>
  [DataMember(Name = "nend", IsRequired = true)]
  public int? EndLine { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="IQuestion"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IQuestion"/> to compare with this instance.</param>
  public int CompareTo(IQuestion other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Determines whether two <see cref="IQuestion"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IQuestion other) => this.Equality(other, nameof(Code), nameof(SessionCode));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IQuestion);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Code), nameof(SessionCode));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Question"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Question"/>.</returns>
  public override string ToString() => Name ?? string.Empty;
}