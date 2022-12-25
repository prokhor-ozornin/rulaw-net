namespace RuLaw;

/// <summary>
///   <para>Duma work session.</para>
/// </summary>
public interface ISession : IEntity, IPeriodable, INameable, IComparable<ISession>, IEquatable<ISession>
{
}