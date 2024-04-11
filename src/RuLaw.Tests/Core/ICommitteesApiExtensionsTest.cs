using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="ICommitteesApiExtensions"/>.</para>
/// </summary>
public sealed class ICommitteesApiExtensionsTest : IntegrationTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ICommitteesApiExtensions.All(ICommitteesApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICommitteesApiExtensions.All(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      Validate(Api.Committees.All());
    }

    return;

    static void Validate(IEnumerable<ICommittee> committees)
    {
      committees.Should().BeOfType<List<Committee>>().And.NotBeEmpty();

      var committee = committees.Single(committee => committee.Id == 6274200);
      committee.Name.Should().Be("Комитет ГД по аграрным вопросам");
      committee.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(20).And.HaveOffset(TimeSpan.Zero);
    }
  }
}