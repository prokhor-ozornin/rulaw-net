using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Duma's convocation.</para>
/// </summary>
public sealed class Convocation : IConvocation
{
  /// <summary>
  ///   <para>Unique identifier of entity.</para>
  /// </summary>
  public long? Id { get; }

  /// <summary>
  ///   <para>Name of the entity.</para>
  /// </summary>
  public string Name { get; }

  /// <summary>
  ///   <para>Start date of authority functioning.</para>
  /// </summary>
  public DateTimeOffset? FromDate { get; }

  /// <summary>
  ///   <para>End date of authority functioning.</para>
  /// </summary>
  public DateTimeOffset? ToDate { get; }

  /// <summary>
  ///   <para>Collection of sessions which are part of the convocation.</para>
  /// </summary>
  public IEnumerable<ISession> Sessions { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="fromDate"></param>
  /// <param name="toDate"></param>
  /// <param name="sessions"></param>
  public Convocation(long? id = null,
                     string name = null,
                     DateTimeOffset? fromDate = null,
                     DateTimeOffset? toDate = null,
                     IEnumerable<ISession> sessions = null)
  {
    Id = id;
    Name = name;
    FromDate = fromDate;
    ToDate = toDate;
    Sessions = sessions ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Convocation(Info info)
  {
    Id = info.Id;
    Name = info.Name;
    FromDate = info.FromDate is not null ? DateTimeOffset.Parse(info.FromDate) : null;
    ToDate = info.ToDate is not null ? DateTimeOffset.Parse(info.ToDate) : null;
    Sessions = info.Sessions ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Convocation(object info) : this(new Info().SetState(info)) {}

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

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "period")]
  public sealed record Info : IResultable<IConvocation>
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
    ///   <para>Start date of authority functioning.</para>
    /// </summary>
    [DataMember(Name = "startDate", IsRequired = true)]
    public string FromDate { get; init; }

    /// <summary>
    ///   <para>End date of authority functioning.</para>
    /// </summary>
    [DataMember(Name = "stopDate")]
    public string ToDate { get; init; }

    /// <summary>
    ///   <para>Collection of sessions which are part of the convocation.</para>
    /// </summary>
    [DataMember(Name = "sessions", IsRequired = true)]
    public List<Session> Sessions { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IConvocation ToResult() => new Convocation(this);
  }
}