using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Result of laws search.</para>
/// </summary>
[DataContract(Name = "result")]
public sealed class LawsSearchResult : ILawsSearchResult
{
  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  [DataMember(Name = "page", IsRequired = true)]
  public int? Page { get; set; }

  /// <summary>
  ///   <para>Number of result laws.</para>
  /// </summary>
  [DataMember(Name = "count", IsRequired = true)]
  public int? Count { get; set; }

  /// <summary>
  ///   <para>Text query formulation.</para>
  /// </summary>
  [DataMember(Name = "wording", IsRequired = true)]
  public string Wording { get; set; }

  /// <summary>
  ///   <para>List of result laws.</para>
  /// </summary>
  [DataMember(Name = "laws", IsRequired = true)]
  public IEnumerable<ILaw> Laws { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="ILawsSearchResult"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ILawsSearchResult"/> to compare with this instance.</param>
  public int CompareTo(ILawsSearchResult other) => Nullable.Compare(Count, other?.Count);

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="LawsSearchResult"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="LawsSearchResult"/>.</returns>
  public override string ToString() => Wording ?? string.Empty;
}