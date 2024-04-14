using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Federal authority.</para>
/// </summary>
[DataContract(Name = "federalOrgan")]
public sealed class FederalAuthority : Authority
{
}