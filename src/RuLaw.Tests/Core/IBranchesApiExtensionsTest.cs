using Xunit;
using System.Configuration;
using FluentAssertions;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IBranchesApiExtensions"/>.</para>
/// </summary>
public sealed class IBranchesApiExtensionsTest : IDisposable
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  private CancellationToken Cancellation { get; } = new(true);

  /// <summary>
  ///   <para>Performs testing of <see cref="IBranchesApiExtensions.All(IBranchesApi, out IEnumerable{ILawBranch}?, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    AssertionExtensions.Should(() => IBranchesApiExtensions.All(null!, out _)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Api.Branches.All(out _, Cancellation)).ThrowExactly<TaskCanceledException>();

    Api.Branches.All(out var branches).Should().BeTrue();

    branches.Should().NotBeNullOrEmpty().And.BeOfType<List<LawBranch>>();

    var branch = branches!.Single(branch => branch.Id == 68252);
    branch.Name.Should().Be("Безопасность и охрана правопорядка");
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public void Dispose()
  {
    Api.Dispose();
  }
}