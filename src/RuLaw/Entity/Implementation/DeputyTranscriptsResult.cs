using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcript of deputy's public speeches.</para>
/// </summary>
[DataContract(Name = "result")]
public sealed class DeputyTranscriptsResult : IDeputyTranscriptsResult
{
  /// <summary>
  ///   <para>Full name of deputy.</para>
  /// </summary>
  [DataMember(Name = "name", IsRequired = true)]
  public string Name { get; set; }

  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  [DataMember(Name = "page", IsRequired = true)]
  public int? Page { get; set; }

  /// <summary>
  ///   <para>Size of results page.</para>
  /// </summary>
  [DataMember(Name = "pageSize", IsRequired = true)]
  public int? PageSize { get; set; }

  /// <summary>
  ///   <para>Number of questions.</para>
  /// </summary>
  [DataMember(Name = "totalCount", IsRequired = true)]
  public int? Count { get; set; }

  /// <summary>
  ///   <para>Collection of duma's meetings.</para>
  /// </summary>
  [DataMember(Name = "meetings", IsRequired = true)]
  public IEnumerable<ITranscriptMeeting> Meetings { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="IDeputyTranscriptsResult"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IDeputyTranscriptsResult"/> to compare with this instance.</param>
  public int CompareTo(IDeputyTranscriptsResult other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyTranscriptsResult"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="DeputyTranscriptsResult"/>.</returns>
  public override string ToString() => Name ?? string.Empty;
}