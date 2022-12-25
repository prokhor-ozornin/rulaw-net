namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IPageable
{
  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  int? Page { get; }

  /// <summary>
  ///   <para>Number of records per page.</para>
  /// </summary>
  int? PageSize { get; }
}