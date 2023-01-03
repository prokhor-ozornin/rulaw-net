using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Document, associated with a law's event.</para>
/// </summary>
public sealed class LawEventDocument : ILawEventDocument
{
  /// <summary>
  ///   <para>Name of document.</para>
  /// </summary>
  public string Name { get; }

  /// <summary>
  ///   <para>Type of document.</para>
  /// </summary>
  public string Type { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="name"></param>
  /// <param name="type"></param>
  public LawEventDocument(string name = null,
                          string type = null)
  {
    Name = name;
    Type = type;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawEventDocument(Info info)
  {
    Name = info.Name;
    Type = info.Type;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawEventDocument(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="ILawEventDocument"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ILawEventDocument"/> to compare with this instance.</param>
  public int CompareTo(ILawEventDocument other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Determines whether two <see cref="ILawEventDocument"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(ILawEventDocument other) => this.Equality(other, nameof(Name));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as ILawEventDocument);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Name));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="LawEventDocument"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="LawEventDocument"/>.</returns>
  public override string ToString() => Name ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "document")]
  public sealed record Info : IResultable<ILawEventDocument>
  {
    /// <summary>
    ///   <para>Name of document.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string Name { get; init; }

    /// <summary>
    ///   <para>Type of document.</para>
    /// </summary>
    [DataMember(Name = "type", IsRequired = true)]
    public string Type { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ILawEventDocument ToResult() => new LawEventDocument(this);
  }
}