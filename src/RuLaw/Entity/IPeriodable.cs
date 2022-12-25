namespace RuLaw;

/// <summary>
///   <para>Represents a business domain entity that is associated with a time period.</para>
/// </summary>
public interface IPeriodable
{
  /// <summary>
  ///   <para>Start date/time of period.</para>
  /// </summary>
  DateTimeOffset? FromDate { get; }

  /// <summary>
  ///   <para>End date/time of period, or a <c>null</c> reference if it's not finished.</para>
  /// </summary>
  DateTimeOffset? ToDate { get; }
}