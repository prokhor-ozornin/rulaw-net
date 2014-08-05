using System.Collections.Generic;

namespace RuLaw
{
  /// <summary>
  ///   <para>Subject of law.</para>
  /// </summary>
  public interface ILawSubject
  {
    /// <summary>
    ///   <para>Departments that are subjects of law.</para>
    /// </summary>
    IEnumerable<IAuthority> Departments { get; }

    /// <summary>
    ///   <para>Deputies that are subjects of law.</para>
    /// </summary>
    IEnumerable<IDeputy> Deputies { get; }
  }
}