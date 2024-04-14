using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Event, associated with a law.</para>
/// </summary>
[DataContract(Name = "lastEvent")]
public sealed class LawEvent : ILawEvent
{
  /// <summary>
  ///   <para>Date of event occurrence.</para>
  /// </summary>
  [DataMember(Name = "date", IsRequired = true)]
  public DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Accepted decision (formulation).</para>
  /// </summary>
  [DataMember(Name = "solution", IsRequired = true)]
  public string Solution { get; set; }

  /// <summary>
  ///   <para>Document, associated with a law's event.</para>
  /// </summary>
  [DataMember(Name = "document", IsRequired = true)]
  public ILawEventDocument Document { get; set; }

  /// <summary>
  ///   <para>Phase of law's review process.</para>
  /// </summary>
  [DataMember(Name = "phase", IsRequired = true)]
  public ILawEventPhase Phase { get; set; }

  /// <summary>
  ///   <para>Stage of law's review process.</para>
  /// </summary>
  [DataMember(Name = "stage", IsRequired = true)]
  public ILawEventStage Stage { get; set; }

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
}