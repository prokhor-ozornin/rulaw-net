namespace RuLaw
{
  using System;

  /// <summary>
  ///   <para>Represents a business domain entity that is associated with a time period.</para>
  /// </summary>
  public interface IPeriodable
  {
    /// <summary>
    ///   <para>Start date/time of period.</para>
    /// </summary>
    DateTime FromDate { get; set; }

    /// <summary>
    ///   <para>End date/time of period, or a <c>null</c> reference if it's not finished.</para>
    /// </summary>
    DateTime? ToDate { get; set; }
  }
}