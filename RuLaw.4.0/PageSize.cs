using System.ComponentModel;

namespace RuLaw
{
  /// <summary>
  ///   <para>Number of results to display per page.</para>
  /// </summary>
  public enum PageSize
  {
    /// <summary>
    ///   <para>Five.</para>
    /// </summary>
    [Description("Five")]
    Five = 5,

    /// <summary>
    ///   <para>Ten.</para>
    /// </summary>
    [Description("Ten")]
    Ten = 10,
    
    /// <summary>
    ///   <para>Twenty.</para>
    /// </summary>
    [Description("Twenty")]
    Twenty = 20,
  }
}