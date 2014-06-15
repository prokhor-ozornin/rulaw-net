namespace RuLaw
{
  /// <summary>
  ///   <para>Represents a business domain entity that can be either in active or inactive state.</para>
  /// </summary>
  public interface IActive
  {
    /// <summary>
    ///   <para>State of entity (active/inactive).</para>
    /// </summary>
    bool Active { get; set; }
  }
}