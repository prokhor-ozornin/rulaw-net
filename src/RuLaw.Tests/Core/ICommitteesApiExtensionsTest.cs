﻿using FluentAssertions;
using Xunit;
using System.Configuration;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="ICommitteesApiExtensions"/>.</para>
/// </summary>
public sealed class ICommitteesApiExtensionsTest : IDisposable
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  private CancellationToken Cancellation { get; } = new(true);

  /// <summary>
  ///   <para>Performs testing of <see cref="ICommitteesApiExtensions.All(ICommitteesApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    AssertionExtensions.Should(() => ICommitteesApiExtensions.All(null)).ThrowExactly<ArgumentNullException>();

    var committees = Api.Committees.All();

    committees.Should().NotBeNullOrEmpty().And.BeOfType<List<Committee>>();
    
    var committee = committees.Single(committee => committee.Id == 6274200);
    committee.Name.Should().Be("Комитет ГД по аграрным вопросам");
    committee.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(20).And.HaveOffset(TimeSpan.Zero);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public void Dispose()
  {
    Api.Dispose();
  }
}