using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>RuLaw API call error.</para>
/// </summary>
[DataContract(Name = "error")]
public sealed class Error : IError
{
  /// <summary>
  ///   <para>Numeric code of error.</para>
  /// </summary>
  [DataMember(Name = "code", IsRequired = true)]
  public int Code { get; set; }

  /// <summary>
  ///   <para>Text description of error.</para>
  /// </summary>
  [DataMember(Name = "text", IsRequired = true)]
  public string Text { get; set; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public Error()
  {
  }

  /// <summary>
  ///   <para>Creates new error.</para>
  /// </summary>
  /// <param name="code">Numeric code of error.</param>
  /// <param name="text">Text description of error.</param>
  public Error(int code, string text)
  {
    Code = code;
    Text = text;
  }

  /// <summary>
  ///   <para>Compares the current <see cref="IError"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IError"/> to compare with this instance.</param>
  public int CompareTo(IError other) => Code.CompareTo(other?.Code);

  /// <summary>
  ///   <para>Determines whether two errors instances are equal.</para>
  /// </summary>
  /// <param name="other">The error to compare with the current one.</param>
  /// <returns><c>true</c> if specified error is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IError other) => this.Equality(other, nameof(Code));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IError);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Code));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Error"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Error"/>.</returns>
  public override string ToString() => Text ?? string.Empty;
}