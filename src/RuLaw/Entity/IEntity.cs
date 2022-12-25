namespace RuLaw;

/// <summary>
///   <para>Representation of a generic bussiness entity for Russian State Duma REST web service domain model.</para>
/// </summary>
public interface IEntity
{
  /// <summary>
  ///   <para>Unique identifier of entity.</para>
  /// </summary>
  long? Id { get; }
}