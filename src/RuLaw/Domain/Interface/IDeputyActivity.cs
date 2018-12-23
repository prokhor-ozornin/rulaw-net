namespace RuLaw
{
  /// <summary>
  ///   <para>Deputy's activity record.</para>
  /// </summary>
  public interface IDeputyActivity : INameable
  {
    /// <summary>
    ///   <para>Identifier of committee.</para>
    /// </summary>
    long CommitteeId { get; }

    /// <summary>
    ///   <para>Genitive name of committee.</para>
    /// </summary>
    string CommitteeNameGenitive { get; }
  }
}