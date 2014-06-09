using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IApiConfigurator
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="format"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="format"/> is <see cref="string.Empty"/> string.</exception>
    IApiConfigurator Format(ApiDataFormat format);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="key"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="key"/> is <see cref="string.Empty"/> string.</exception>
    IApiConfigurator ApiKey(string key);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="key"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="key"/> is <see cref="string.Empty"/> string.</exception>
    IApiConfigurator AppKey(string key);
  }
}