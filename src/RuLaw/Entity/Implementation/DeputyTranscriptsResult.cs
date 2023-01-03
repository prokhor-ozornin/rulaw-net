using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Transcript of deputy's public speeches.</para>
/// </summary>
public sealed class DeputyTranscriptsResult : IDeputyTranscriptsResult
{
  /// <summary>
  ///   <para>Full name of deputy.</para>
  /// </summary>
  public string Name { get; }

  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  public int? Page { get; }

  /// <summary>
  ///   <para>Size of results page.</para>
  /// </summary>
  public int? PageSize { get; }

  /// <summary>
  ///   <para>Number of questions.</para>
  /// </summary>
  public int? Count { get; }

  /// <summary>
  ///   <para>Collection of duma's meetings.</para>
  /// </summary>
  public IEnumerable<ITranscriptMeeting> Meetings { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="name"></param>
  /// <param name="page"></param>
  /// <param name="pageSize"></param>
  /// <param name="count"></param>
  /// <param name="meetings"></param>
  public DeputyTranscriptsResult(string name = null,
                                 int? page = null,
                                 int? pageSize = null,
                                 int? count = null,
                                 IEnumerable<ITranscriptMeeting> meetings = null)
  {
    Name = name;
    Page = page;
    PageSize = pageSize;
    Count = count;
    Meetings = meetings ?? new List<ITranscriptMeeting>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyTranscriptsResult(Info info)
  {
    Name = info.Name;
    Page = info.Page;
    PageSize = info.PageSize;
    Count = info.Count;
    Meetings = info.Meetings ?? new List<TranscriptMeeting>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyTranscriptsResult(object info) : this(new Info().SetState(info)) {}

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

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "result")]
  public sealed record Info : IResultable<IDeputyTranscriptsResult>
  {
    /// <summary>
    ///   <para>Full name of deputy.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string Name { get; init; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [DataMember(Name = "page", IsRequired = true)]
    public int? Page { get; init; }

    /// <summary>
    ///   <para>Size of results page.</para>
    /// </summary>
    [DataMember(Name = "pageSize", IsRequired = true)]
    public int? PageSize { get; init; }

    /// <summary>
    ///   <para>Number of questions.</para>
    /// </summary>
    [DataMember(Name = "totalCount", IsRequired = true)]
    public int? Count { get; init; }

    /// <summary>
    ///   <para>Collection of duma's meetings.</para>
    /// </summary>
    [DataMember(Name = "meetings", IsRequired = true)]
    public List<TranscriptMeeting> Meetings { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IDeputyTranscriptsResult ToResult() => new DeputyTranscriptsResult(this);
  }
}