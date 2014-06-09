using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IPeriodable
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    DateTime FromDate { get; set; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    DateTime? ToDate { get; set; }
  }
}