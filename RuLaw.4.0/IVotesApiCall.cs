using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IVotesApiCall
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    IVotesApiCall Id(long id);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    IVotesApiCall Convocation(long id);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    IVotesApiCall From(DateTime from);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="to"></param>
    /// <returns></returns>
    IVotesApiCall To(DateTime to);
  }
}