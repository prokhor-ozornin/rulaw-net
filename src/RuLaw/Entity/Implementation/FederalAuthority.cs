using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Federal authority.</para>
/// </summary>
public sealed class FederalAuthority : Authority
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="active"></param>
  /// <param name="fromDate"></param>
  /// <param name="toDate"></param>
  public FederalAuthority(long? id = null,
                          string name = null,
                          bool? active = null,
                          DateTimeOffset? fromDate = null,
                          DateTimeOffset? toDate = null) : base(id, name, active, fromDate, toDate)
  {
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public FederalAuthority(Info info) : base(info) {}

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public FederalAuthority(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "federalOrgan")]
  public sealed record Info : Authority.Info
  {
  }
}