namespace RuLaw;

/// <summary>
///   <para>Law workflow instance.</para>
/// </summary>
public interface IInstance : IEntity, IActive, INameable, IEquatable<IInstance>, IComparable<IInstance>
{
}