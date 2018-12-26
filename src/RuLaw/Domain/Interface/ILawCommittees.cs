namespace RuLaw
{
  using System.Collections.Generic;

  /// <summary>
  ///   <para>Committees, associated with a law.</para>
  /// </summary>
  public interface ILawCommittees
  {
    /// <summary>
    ///   <para>List of profile committees.</para>
    /// </summary>
    IEnumerable<ICommittee> Profile { get; }

    /// <summary>
    ///   <para>Responsible committee.</para>
    /// </summary>
    ICommittee Responsible { get; }

    /// <summary>
    ///   <para>List of so-executor committees.</para>
    /// </summary>
    IEnumerable<ICommittee> SoExecutor { get; }
  }
}