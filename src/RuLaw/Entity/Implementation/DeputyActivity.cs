using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Deputy's activity record.</para>
/// </summary>
public sealed class DeputyActivity : IDeputyActivity
{
  /// <summary>
  ///   <para>Name of entity.</para>
  /// </summary>
  public string Name { get; }

  /// <summary>
  ///   <para>Identifier of committee.</para>
  /// </summary>
  public long? CommitteeId { get; }

  /// <summary>
  ///   <para>Genitive name of committee.</para>
  /// </summary>
  public string CommitteeNameGenitive { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="name"></param>
  /// <param name="committeeId"></param>
  /// <param name="committeeNameGenitive"></param>
  public DeputyActivity(string name = null,
                        long? committeeId = null,
                        string committeeNameGenitive = null)
  {
    Name = name;
    CommitteeId = committeeId;
    CommitteeNameGenitive = committeeNameGenitive;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyActivity(Info info)
  {
    Name = info.Name;
    CommitteeId = info.CommitteeId;
    CommitteeNameGenitive = info.CommitteeNameGenitive;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyActivity(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="IDeputyActivity"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IDeputyActivity"/> to compare with this instance.</param>
  public int CompareTo(IDeputyActivity other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Determines whether two <see cref="IDeputyActivity"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IDeputyActivity other) => this.Equality(other, nameof(Name), nameof(CommitteeId));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IDeputyActivity);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Name), nameof(CommitteeId));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyActivity"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="DeputyActivity"/>.</returns>
  public override string ToString() => Name ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "activity")]
  public sealed record Info : IResultable<IDeputyActivity>
  {
    /// <summary>
    ///   <para>Name of entity.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string Name { get; init; }

    /// <summary>
    ///   <para>Identifier of committee.</para>
    /// </summary>
    [DataMember(Name = "subdivisionId", IsRequired = true)]
    public long? CommitteeId { get; init; }

    /// <summary>
    ///   <para>Genitive name of committee.</para>
    /// </summary>
    [DataMember(Name = "subdivisionNameGenitive", IsRequired = true)]
    public string CommitteeNameGenitive { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IDeputyActivity ToResult() => new DeputyActivity(this);
  }
}