using System;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IVotesSearchLawApiCallExtensions"/>.</para>
  /// </summary>
  /// <seealso cref="IVotesSearchLawApiCallExtensions"/>
  public sealed class IVotesSearchLawApiCallExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IVotesSearchLawApiCallExtensions.Convocation(IVotesSearchLawApiCall, IConvocation)"/> method.</para>
    /// </summary>
    [Fact]
    public void Convocation_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IVotesSearchLawApiCallExtensions.Convocation(null, new Convocation()));
      Assert.Throws<ArgumentNullException>(() => new VotesSearchLawApiCall().Convocation(null));

      var call = new VotesSearchLawApiCall();
      Assert.Empty(call.Parameters);
      Assert.True(ReferenceEquals(call, call.Convocation(new Convocation { Id = 1 })));
      Assert.Equal((long)1, call.Parameters["convocation"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IVotesSearchLawApiCallExtensions.Deputy(IVotesSearchLawApiCall, IDeputy)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deputy_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IVotesSearchLawApiCallExtensions.Deputy(null, new Deputy()));
      Assert.Throws<ArgumentNullException>(() => new VotesSearchLawApiCall().Deputy(null));

      var call = new VotesSearchLawApiCall();
      Assert.Empty(call.Parameters);
      Assert.True(ReferenceEquals(call, call.Deputy(new Deputy { Id = 1 })));
      Assert.Equal((long)1, call.Parameters["deputy"]);
    }
  }
}