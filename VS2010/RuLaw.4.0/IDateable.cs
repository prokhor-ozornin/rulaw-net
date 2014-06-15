using System;

namespace RuLaw
{
  /// <summary>
  ///   <para>Representation of a business entity that have an associated date.</para>
  /// </summary>
  public interface IDateable
  {
    /// <summary>
    ///   <para>Date/time of the associated entity.</para>
    /// </summary>
    DateTime Date { get; set; }
  }
}