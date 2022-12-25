namespace RuLaw;

/// <summary>
///   <para>Law authority.</para>
/// </summary>
public interface IAuthority : IEntity, INameable, IActive, IPeriodable, IComparable<IAuthority>, IEquatable<IAuthority>
{
}