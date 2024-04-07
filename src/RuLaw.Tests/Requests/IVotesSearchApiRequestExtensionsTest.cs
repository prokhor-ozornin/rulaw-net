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

      var request = new VotesSearchApiRequest();
      request.Parameters.Should().BeEmpty();

      request.Deputy((IDeputy)null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["deputy"].Should().BeNull();

      request.Deputy(new Deputy(new { Id = 1 })).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["deputy"].Should().Be(1L);
    }

    return;

    static void Validate()
    {

    }
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

      var request = new VotesSearchApiRequest();
      
      request.Parameters.Should().BeEmpty();

      request.Convocation((IConvocation) null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["convocation"].Should().BeNull();

      request.Convocation(new Convocation(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["convocation"].Should().Be(1L);
    }

    return;

    static void Validate()
    {

    }
  }
}