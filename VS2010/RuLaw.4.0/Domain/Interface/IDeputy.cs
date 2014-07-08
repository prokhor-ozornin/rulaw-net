namespace RuLaw
{
  /// <summary>
  ///   <para>Deputy/member of Council of Federation.</para>
  /// </summary>
  public interface IDeputy : IEntity, INameable, IActive
  {
    /// <summary>
    ///   <para>Work position of deputy.</para>
    /// </summary>
    string Position { get; }
  }
}