using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IVotesSearchApiRequestExtensions"/>.</para>
/// </summary>
/// <seealso cref="IVotesSearchApiRequestExtensions"/>
public sealed class IVotesSearchApiRequestExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IVotesSearchApiRequestExtensions.Deputy(IVotesSearchApiRequest, IDeputy)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVotesSearchApiRequestExtensions.Deputy(null, new Deputy())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new VotesSearchApiRequest());
      Validate(new Deputy { Id = long.MinValue }, new VotesSearchApiRequest());
      Validate(new Deputy { Id = long.MaxValue }, new VotesSearchApiRequest());
    }

    return;

    static void Validate(IDeputy deputy, IVotesSearchApiRequest request) => request.Deputy(deputy).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["deputy"].Should().Be(deputy?.Id);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVotesSearchApiRequestExtensions.Convocation(IVotesSearchApiRequest, IConvocation)"/> method.</para>
  /// </summary>
  [Fact]
  public void Convocation_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVotesSearchApiRequestExtensions.Convocation(null, new Convocation())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new VotesSearchApiRequest());
      Validate(new Convocation { Id = long.MinValue }, new VotesSearchApiRequest());
      Validate(new Convocation { Id = long.MaxValue }, new VotesSearchApiRequest());
    }

    return;

    static void Validate(IConvocation convocation, IVotesSearchApiRequest request) => request.Convocation(convocation).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["convocation"].Should().Be(convocation?.Id);
  }
}