using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Duma work session.</para>
/// </summary>
public sealed class Session : ISession
{
  /// <summary>
  ///   <para>Unique identifier of work session.</para>
  /// </summary>
  public long? Id { get; }

  /// <summary>
  ///   <para>Name of work session.</para>
  /// </summary>
  public string? Name { get; }

  /// <summary>
  ///   <para>Date when work session was started.</para>
  /// </summary>
  public DateTimeOffset? FromDate { get; }

  /// <summary>
  ///   <para>Date when work session was ended.</para>
  /// </summary>
  public DateTimeOffset? ToDate { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="fromDate"></param>
  /// <param name="toDate"></param>
  public Session(long? id = null,
                 string? name = null,
                 DateTimeOffset? fromDate = null,
                 DateTimeOffset? toDate = null)
  {
    Id = id;
    Name = name;
    FromDate = fromDate;
    ToDate = toDate;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Session(Info info)
  {
    Id = info.Id;
    Name = info.Name;
    FromDate = info.FromDate != null ? DateTimeOffset.Parse(info.FromDate) : null;
    ToDate = info.ToDate != null ? DateTimeOffset.Parse(info.ToDate) : null;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Session(object info) : this(new Info().Properties(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="ISession"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ISession"/> to compare with this instance.</param>
  public int CompareTo(ISession? other) => Nullable.Compare(FromDate, other?.FromDate);

  /// <summary>
  ///   <para>Determines whether two <see cref="ISession"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(ISession? other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object? other) => Equals(other as ISession);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Id));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Session"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Session"/>.</returns>
  public override string ToString() => Name ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "session")]
  public sealed record Info : IResultable<ISession>
  {
    /// <summary>
    ///   <para>Unique identifier of work session.</para>
    /// </summary>
    [DataMember(Name = "id", IsRequired = true)]
    public long? Id { get; init; }

    /// <summary>
    ///   <para>Name of work session.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string? Name { get; init; }

    /// <summary>
    ///   <para>Date when work session was started.</para>
    /// </summary>
    [DataMember(Name = "startDate", IsRequired = true)]
    public string? FromDate { get; init; }

    /// <summary>
    ///   <para>Date when work session was ended.</para>
    /// </summary>
    [DataMember(Name = "endDate", IsRequired = true)]
    public string? ToDate { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ISession Result() => new Session(this);
  }
}