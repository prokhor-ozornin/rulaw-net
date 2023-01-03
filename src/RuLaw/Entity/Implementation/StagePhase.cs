using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Phase of law's workflow stage.</para>
/// </summary>
public sealed class StagePhase : IStagePhase
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
  ///  <para>Law workflow instance.</para>
  /// </summary>
  public IInstance Instance { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="instance"></param>
  public StagePhase(long? id = null,
                    string name = null,
                    IInstance instance = null)
  {
    Id = id;
    Name = name;
    Instance = instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public StagePhase(Info info)
  {
    Id = info.Id;
    Name = info.Name;
    Instance = info.Instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public StagePhase(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current entity with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the objects being compared.</returns>
  /// <param name="other">The <see cref="IStagePhase"/> to compare with this instance.</param>
  public int CompareTo(IStagePhase other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Determines whether two entities instances are equal.</para>
  /// </summary>
  /// <param name="other">The entity to compare with the current one.</param>
  /// <returns><c>true</c> if specified entity is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IStagePhase other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IStagePhase);

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
  [DataContract(Name = "phase")]
  public record Info : IResultable<IStagePhase>
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
    ///  <para>Law workflow instance.</para>
    /// </summary>
    [DataMember(Name = "instance", IsRequired = true)]
    public Instance Instance { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IStagePhase ToResult() => new StagePhase(this);
  }
}