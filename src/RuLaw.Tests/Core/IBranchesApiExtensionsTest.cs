using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IBranchesApiExtensions"/>.</para>
/// </summary>
/// <seealso cref="IBranchesApiExtensions"/>
public sealed class IBranchesApiExtensionsTest : IntegrationTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IBranchesApiExtensions.All(IBranchesApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IBranchesApiExtensions.All(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      Test(Api.Branches.All());
    }

    return;

    static void Test(IEnumerable<ILawBranch> branches)
    {
      branches.Should().BeOfType<List<LawBranch>>().And.NotBeEmpty();

      var branch = branches.Single(branch => branch.Id == 68252);
      branch.Name.Should().Be("Безопасность и охрана правопорядка");
    }
  }
}