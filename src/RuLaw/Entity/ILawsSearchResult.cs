﻿namespace RuLaw;

/// <summary>
///   <para>Result of laws search.</para>
/// </summary>
public interface ILawsSearchResult : IComparable<ILawsSearchResult>
{
  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  int? Page { get; }

  /// <summary>
  ///   <para>Number of result laws.</para>
  /// </summary>
  int? Count { get; }

  /// <summary>
  ///   <para>Text query formulation.</para>
  /// </summary>
  string Wording { get; }

  /// <summary>
  ///   <para>List of result laws.</para>
  /// </summary>
  IEnumerable<ILaw> Laws { get; }
}