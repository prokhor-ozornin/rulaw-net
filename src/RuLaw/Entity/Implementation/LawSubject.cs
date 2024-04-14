using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Subject of law.</para>
/// </summary>
[DataContract(Name = "subject")]
public sealed class LawSubject : ILawSubject
{
  /// <summary>
  ///   <para>Departments that are subjects of law.</para>
  /// </summary>
  [DataMember(Name = "departments", IsRequired = true)]
  public IEnumerable<IAuthority> Departments { get; set; }

  /// <summary>
  ///   <para>Deputies that are subjects of law.</para>
  /// </summary>
  [DataMember(Name = "deputies", IsRequired = true)]
  public IEnumerable<IDeputy> Deputies { get; set; }
}