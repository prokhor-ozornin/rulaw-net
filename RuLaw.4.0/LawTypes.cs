using System.ComponentModel;

namespace RuLaw
{
  /// <summary>
  ///   <para>Type of law.</para>
  /// </summary>
  public enum LawTypes
  {
    /// <summary>
    ///   <para>Federal law.</para>
    /// </summary>
    [Description("Federal law")]
    Federal = 38,

    /// <summary>
    ///   <para>Federal constitutional law.</para>
    /// </summary>
    [Description("Federal constitutional law")]
    FederalConstitutional = 39,

    /// <summary>
    ///   <para>Law on amendments to the Constitution of the Russian Federation.</para>
    /// </summary>
    [Description("Law on amendments to the Constitution of the Russian Federation")]
    ConstitutionAmendments = 41
  }
}