using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Regional authority.</para>
/// </summary>
public sealed class RegionalAuthority : Authority
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="active"></param>
  /// <param name="fromDate"></param>
  /// <param name="toDate"></param>
  public RegionalAuthority(long? id = null,
                           string? name = null,
                           bool? active = null,
                           DateTimeOffset? fromDate = null,
                           DateTimeOffset? toDate = null) : base(id, name, active, fromDate, toDate)
  {
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public RegionalAuthority(Info info) : base(info) {}

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public RegionalAuthority(object info) : this(new Info().Properties(info)) {}

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "regionalOrgan")]
  public sealed record Info : Authority.Info
  {
  }
}