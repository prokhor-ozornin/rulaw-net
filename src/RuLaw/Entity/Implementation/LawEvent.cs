using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Event, associated with a law.</para>
/// </summary>
public sealed class LawEvent : ILawEvent
{
  /// <summary>
  ///   <para>Date of event occurrence.</para>
  /// </summary>
  public DateTimeOffset? Date { get; }

  /// <summary>
  ///   <para>Accepted decision (formulation).</para>
  /// </summary>
  public string Solution { get; }

  /// <summary>
  ///   <para>Document, associated with a law's event.</para>
  /// </summary>
  public ILawEventDocument Document { get; }

  /// <summary>
  ///   <para>Phase of law's review process.</para>
  /// </summary>
  public ILawEventPhase Phase { get; }

  /// <summary>
  ///   <para>Stage of law's review process.</para>
  /// </summary>
  public ILawEventStage Stage { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="date"></param>
  /// <param name="solution"></param>
  /// <param name="document"></param>
  /// <param name="phase"></param>
  /// <param name="stage"></param>
  public LawEvent(DateTimeOffset? date = null,
                  string solution = null,
                  ILawEventDocument document = null,
                  ILawEventPhase phase = null,
                  ILawEventStage stage = null)
  {
    Date = date;
    Solution = solution;
    Document = document;
    Phase = phase;
    Stage = stage;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawEvent(Info info)
  {
    Date = info.Date != null ? DateTimeOffset.Parse(info.Date) : null;
    Solution = info.Solution;
    Document = info.Document;
    Phase = info.Phase;
    Stage = info.Stage;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public LawEvent(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="ILawEvent"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ILawEvent"/> to compare with this instance.</param>
  public int CompareTo(ILawEvent other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="LawEvent"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="LawEvent"/>.</returns>
  public override string ToString() => Solution ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "lastEvent")]
  public sealed record Info : IResultable<ILawEvent>
  {
    /// <summary>
    ///   <para>Date of event occurrence.</para>
    /// </summary>
    [DataMember(Name = "date", IsRequired = true)]
    public string Date { get; init; }

    /// <summary>
    ///   <para>Accepted decision (formulation).</para>
    /// </summary>
    [DataMember(Name = "solution", IsRequired = true)]
    public string Solution { get; init; }

    /// <summary>
    ///   <para>Document, associated with a law's event.</para>
    /// </summary>
    [DataMember(Name = "document", IsRequired = true)]
    public LawEventDocument Document { get; init; }

    /// <summary>
    ///   <para>Phase of law's review process.</para>
    /// </summary>
    [DataMember(Name = "phase", IsRequired = true)]
    public LawEventPhase Phase { get; init; }

    /// <summary>
    ///   <para>Stage of law's review process.</para>
    /// </summary>
    [DataMember(Name = "stage", IsRequired = true)]
    public LawEventStage Stage { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public ILawEvent ToResult() => new LawEvent(this);
  }
}