namespace RuLaw
{
  /// <summary>
  ///   <para>Event, associated with a law.</para>
  /// </summary>
  public interface ILawEvent : IDateable
  {
    /// <summary>
    ///   <para>Document, associated with a law's event.</para>
    /// </summary>
    ILawEventDocument Document { get; }

    /// <summary>
    ///   <para>Phase of law's review process.</para>
    /// </summary>
    ILawEventPhase Phase { get; }

    /// <summary>
    ///   <para>Accepted decision (formulation).</para>
    /// </summary>
    string Solution { get; }

    /// <summary>
    ///   <para>Stage of law's review process.</para>
    /// </summary>
    ILawEventStage Stage { get; }
  }
}