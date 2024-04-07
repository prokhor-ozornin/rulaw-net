using Xunit;
using System.Configuration;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IBranchesApiExtensions"/>.</para>
/// </summary>
public sealed class IBranchesApiExtensionsTest : UnitTest
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of <see cref="IBranchesApiExtensions.All(IBranchesApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IBranchesApiExtensions.All(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      var branches = Api.Branches.All();

      branches.Should().NotBeNullOrEmpty().And.BeOfType<List<LawBranch>>();

      var branch = branches.Single(branch => branch.Id == 68252);
      branch.Name.Should().Be("Безопасность и охрана правопорядка");
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose() => Api.Dispose();
}