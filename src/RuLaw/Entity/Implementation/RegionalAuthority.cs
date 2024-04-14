using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Regional authority.</para>
/// </summary>
[DataContract(Name = "regionalOrgan")]
public sealed class RegionalAuthority : Authority
{
}