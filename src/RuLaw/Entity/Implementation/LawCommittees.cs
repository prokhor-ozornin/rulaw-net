using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Committees, associated with a law.</para>
/// </summary>
[DataContract(Name = "committees")]
public sealed class LawCommittees : ILawCommittees
{
  /// <summary>
  ///   <para>Responsible committee.</para>
  /// </summary>
  [DataMember(Name = "responsible", IsRequired = true)]
  public ICommittee Responsible { get; set; }

  /// <summary>
  ///   <para>List of profile committees.</para>
  /// </summary>
  [DataMember(Name = "profile", IsRequired = true)]
  public IEnumerable<ICommittee> Profile { get; set; }

  /// <summary>
  ///   <para>List of so-executor committees.</para>
  /// </summary>
  [DataMember(Name = "soexecutor", IsRequired = true)]
  public IEnumerable<ICommittee> SoExecutor { get; set; }
}