namespace RuLaw;

/// <summary>
///   <para>Type of laws sorting.</para>
/// </summary>
public enum LawsSorting
{
  /// <summary>
  ///   <para>By name of law.</para>
  /// </summary>
  Name,

  /// <summary>
  ///   <para>By number of law.</para>
  /// </summary>
  Number,

  /// <summary>
  ///   <para>By proposal date in State Duma (descending).</para>
  /// </summary>
  DateDescending,

  /// <summary>
  ///   <para>By proposal date in State Duma (ascending).</para>
  /// </summary>
  DateAscending,

  /// <summary>
  ///   <para>By date of last event (descending).</para>
  /// </summary>
  LastEventDateDescending,

  /// <summary>
  ///   <para>By date of last event (ascending).</para>
  /// </summary>
  LastEventDateAscending,

  /// <summary>
  ///   <para>By responsible committee.</para>
  /// </summary>
  ResponsibleCommittee
}