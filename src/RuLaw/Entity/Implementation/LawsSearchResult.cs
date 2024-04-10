using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Result of laws search.</para>
/// </summary>
public sealed class LawsSearchResult : ILawsSearchResult
{
  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  public int? Page { get; }

  /// <summary>
  ///   <para>Number of result laws.</para>
  /// </summary>
  public int? Count { get; }

  /// <summary>
  ///   <para>Text query formulation.</para>
  /// </summary>
  public string Wording { get; }

  /// <summary>
  ///   <para>List of result laws.</para>
  /// </summary>
  public IEnumerable<ILaw> Laws { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="page"></param>
  /// <param name="count"></param>
  /// <param name="wording"></param>
  /// <param name="laws"></param>
  public LawsSearchResult(int? page = null,
                          int? count = null,
                          string wording = null,
                          IEnumerable<ILaw> laws = null)
  {
    Page = page;
    Count = count;
    Wording = wording;
    Laws = laws ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawsSearchResult(Info info)
  {
    Page = info.Page;
    Count = info.Count;
    Wording = info.Wording;
    Laws = info.Laws ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawsSearchResult(object info) : this(new Info().SetState(info)) {}

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

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "result")]
  public sealed record Info : IResultable<ILawsSearchResult>
  {
    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [DataMember(Name = "page", IsRequired = true)]
    public int? Page { get; init; }

    /// <summary>
    ///   <para>Number of result laws.</para>
    /// </summary>
    [DataMember(Name = "count", IsRequired = true)]
    public int? Count { get; init; }

    /// <summary>
    ///   <para>Text query formulation.</para>
    /// </summary>
    [DataMember(Name = "wording", IsRequired = true)]
    public string Wording { get; init; }

    /// <summary>
    ///   <para>List of result laws.</para>
    /// </summary>
    [DataMember(Name = "laws", IsRequired = true)]
    public List<Law> Laws { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ILawsSearchResult ToResult() => new LawsSearchResult(this);
  }
}