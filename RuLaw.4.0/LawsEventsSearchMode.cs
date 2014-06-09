using System.ComponentModel;

namespace RuLaw
{
  /// <summary>
  ///   <para>Search mode for law's events.</para>
  /// </summary>
  public enum LawsEventsSearchMode
  {
    /// <summary>
    ///   <para>Search by all events.</para>
    /// </summary>
    [Description("All events")]
    All = 1,

    /// <summary>
    ///   <para>Search by last event.</para>
    /// </summary>
    [Description("Last event")]
    Last = 2,

    /// <summary>
    ///   <para>Search for expected event.</para>
    /// </summary>
    [Description("Expected event")]
    Expected = 3
  }
}