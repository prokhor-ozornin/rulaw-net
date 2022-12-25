using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IVotesSearchApiRequestExtensions"/>.</para>
/// </summary>
/// <seealso cref="IVotesSearchApiRequestExtensions"/>
public sealed class IVotesSearchApiRequestExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IVotesSearchApiRequestExtensions.Deputy(IVotesSearchApiRequest, IDeputy)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    AssertionExtensions.Should(() => IVotesSearchApiRequestExtensions.Deputy(null!, new Deputy())).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => new VotesSearchApiRequest().Deputy(null)).ThrowExactly<ArgumentNullException>();

    var request = new VotesSearchApiRequest();
    request.Parameters.Should().BeEmpty();
    
    request.Deputy((IDeputy) null!).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().BeNull();

    request.Deputy(new Deputy(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVotesSearchApiRequestExtensions.Convocation(IVotesSearchApiRequest, IConvocation)"/> method.</para>
  /// </summary>
  [Fact]
  public void Convocation_Method()
  {
    AssertionExtensions.Should(() => IVotesSearchApiRequestExtensions.Convocation(null!, new Convocation())).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => new VotesSearchApiRequest().Convocation(null)).ThrowExactly<ArgumentNullException>();

    var request = new VotesSearchApiRequest();
    
    request.Parameters.Should().BeEmpty();

    request.Convocation((IConvocation) null!).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["convocation"].Should().BeNull();

    request.Convocation(new Convocation(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["convocation"].Should().Be(1L);
  }
}