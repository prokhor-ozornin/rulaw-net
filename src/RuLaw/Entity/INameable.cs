namespace RuLaw;

/// <summary>
///   <para>Representation of a business entity which have a name.</para>
/// </summary>
public interface INameable
{
  /// <summary>
  ///   <para>Name of the entity.</para>
  /// </summary>
  string? Name { get; }
}