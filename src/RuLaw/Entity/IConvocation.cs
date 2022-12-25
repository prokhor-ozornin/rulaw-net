namespace RuLaw;

/// <summary>
///   <para>Duma's convocation.</para>
/// </summary>
public interface IConvocation : IEntity, INameable, IPeriodable
{
  /// <summary>
  ///   <para>Collection of sessions which are part of the convocation.</para>
  /// </summary>
  IEnumerable<ISession> Sessions { get; }
}