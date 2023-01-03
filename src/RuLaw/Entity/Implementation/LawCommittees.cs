using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Committees, associated with a law.</para>
/// </summary>
public sealed class LawCommittees : ILawCommittees
{
  /// <summary>
  ///   <para>Responsible committee.</para>
  /// </summary>
  public ICommittee Responsible { get; }

  /// <summary>
  ///   <para>List of profile committees.</para>
  /// </summary>
  public IEnumerable<ICommittee> Profile { get; }

  /// <summary>
  ///   <para>List of so-executor committees.</para>
  /// </summary>
  public IEnumerable<ICommittee> SoExecutor { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="responsible"></param>
  /// <param name="profile"></param>
  /// <param name="soExecutor"></param>
  public LawCommittees(ICommittee responsible = null,
                       IEnumerable<ICommittee> profile = null,
                       IEnumerable<ICommittee> soExecutor = null)
  {
    Responsible = responsible;
    Profile = profile ?? new List<ICommittee>();
    SoExecutor = soExecutor ?? new List<ICommittee>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawCommittees(Info info)
  {
    Responsible = info.Responsible;
    Profile = info.Profile ?? new List<Committee>();
    SoExecutor = info.SoExecutor ?? new List<Committee>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawCommittees(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "committees")]
  public sealed record Info : IResultable<ILawCommittees>
  {
    /// <summary>
    ///   <para>Responsible committee.</para>
    /// </summary>
    [DataMember(Name = "responsible", IsRequired = true)]
    public Committee Responsible { get; init; }

    /// <summary>
    ///   <para>List of profile committees.</para>
    /// </summary>
    [DataMember(Name = "profile", IsRequired = true)]
    public List<Committee> Profile { get; init; }

    /// <summary>
    ///   <para>List of so-executor committees.</para>
    /// </summary>
    [DataMember(Name = "soexecutor", IsRequired = true)]
    public List<Committee> SoExecutor { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ILawCommittees ToResult() => new LawCommittees(this);
  }
}