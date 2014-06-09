namespace RuLaw
{
  /// <summary>
  ///   <para>Status of law.</para>
  /// </summary>
  public enum LawStatus
  {
    /// <summary>
    ///   <para>Proposed in Duma.</para>
    /// </summary>
    Offered = 1,

    /// <summary>
    ///   <para>Being reviewed by Duma.</para>
    /// </summary>
    ReviewStarted = 2,

    /// <summary>
    ///   <para>Included in approximate program.</para>
    /// </summary>
    InApproximateProgram = 3,

    /// <summary>
    ///   <para>Included in committees programs.</para>
    /// </summary>
    InCommitteeProgram = 4,

    /// <summary>
    ///   <para>Proposed in Duma without programs.</para>
    /// </summary>
    OutOfProgram = 5,

    /// <summary>
    ///   <para>Review finished.</para>
    /// </summary>
    ReviewFinished = 6,

    /// <summary>
    ///   <para>Signed by President of Russian Federation.</para>
    /// </summary>
    Signed = 7,

    /// <summary>
    ///   <para>Rejected by Duma.</para>
    /// </summary>
    Rejected = 8,

    /// <summary>
    ///   <para>Rejected or returned.</para>
    /// </summary>
    RejectedOrReturned = 9,

    /// <summary>
    ///   <para>Cancelled due to other reasons.</para>
    /// </summary>
    Cancelled = 99
  }
}