﻿using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IBranchesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IBranchesApi"/>
public static class IBranchesApiExtensions
{
  /// <summary>
  ///   <para>Returns list of laws branches.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-otrasley-zakonodatelstva"/>
  public static IEnumerable<ILawBranch> All(this IBranchesApi api) => api is not null ? api.AllAsync().ToListAsync().Result : throw new ArgumentNullException(nameof(api));
}