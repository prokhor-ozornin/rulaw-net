using Xunit;
using FluentAssertions;
using FluentAssertions.Execution;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IBranchesApiExtensions"/>.</para>
/// </summary>
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

      Validate(Api.Branches.All());
    }

    return;

    static void Validate(IEnumerable<ILawBranch> branches)
    {
      branches.Should().BeOfType<List<LawBranch>>().And.NotBeEmpty();

      var branch = branches.Single(branch => branch.Id == 68252);
      branch.Name.Should().Be("Безопасность и охрана правопорядка");
    }
  }
}