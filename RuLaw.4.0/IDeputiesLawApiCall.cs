using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IDeputiesLawApiCall : ILawApiCall
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    IDeputiesLawApiCall Name(string name);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="position"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="position"/> is <see cref="string.Empty"/> string.</exception>
    IDeputiesLawApiCall Position(string position);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="current"></param>
    /// <returns></returns>
    IDeputiesLawApiCall Current(bool current = true);
  }
}