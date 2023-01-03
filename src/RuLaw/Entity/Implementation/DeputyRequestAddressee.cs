using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Addressee of deputy's request.</para>
/// </summary>
public sealed class DeputyRequestAddressee : IDeputyRequestAddressee
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
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  public DeputyRequestAddressee(long? id = default,
                                string name = null)
  {
    Id = id;
    Name = name;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyRequestAddressee(Info info)
  {
    Id = info.Id;
    Name = info.Name;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyRequestAddressee(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current entity with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the objects being compared.</returns>
  /// <param name="other">The <see cref="IDeputyRequestAddressee"/> to compare with this instance.</param>
  public int CompareTo(IDeputyRequestAddressee other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Determines whether two entities instances are equal.</para>
  /// </summary>
  /// <param name="other">The entity to compare with the current one.</param>
  /// <returns><c>true</c> if specified entity is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IDeputyRequestAddressee other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IDeputyRequestAddressee);

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
  [DataContract(Name = "addressee")]
  public sealed record Info : IResultable<IDeputyRequestAddressee>
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
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IDeputyRequestAddressee ToResult() => new DeputyRequestAddressee(this);
  }
}