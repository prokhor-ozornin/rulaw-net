using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Subject of law.</para>
/// </summary>
public sealed class LawSubject : ILawSubject
{
  /// <summary>
  ///   <para>Departments that are subjects of law.</para>
  /// </summary>
  public IEnumerable<IAuthority> Departments { get; }

  /// <summary>
  ///   <para>Deputies that are subjects of law.</para>
  /// </summary>
  public IEnumerable<IDeputy> Deputies { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="departments"></param>
  /// <param name="deputies"></param>
  public LawSubject(IEnumerable<IAuthority>? departments = null,
                    IEnumerable<IDeputy>? deputies = null)
  {
    Departments = departments ?? new List<IAuthority>();
    Deputies = deputies ?? new List<IDeputy>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawSubject(Info info)
  {
    Departments = info.Departments ?? new List<Authority>();
    Deputies = info.Deputies ?? new List<Deputy>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawSubject(object info) : this(new Info().Properties(info)) {}

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "subject")]
  public sealed record Info : IResultable<ILawSubject>
  {
    /// <summary>
    ///   <para>Departments that are subjects of law.</para>
    /// </summary>
    [DataMember(Name = "departments", IsRequired = true)]
    public List<Authority>? Departments { get; init; }

    /// <summary>
    ///   <para>Deputies that are subjects of law.</para>
    /// </summary>
    [DataMember(Name = "deputies", IsRequired = true)]
    public List<Deputy>? Deputies { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ILawSubject Result() => new LawSubject(this);
  }
}