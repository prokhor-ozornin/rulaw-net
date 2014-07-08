using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IVoteExtensions"/>.</para>
  /// </summary>
  public sealed class IVoteExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IVoteExtensions.Personal(IVote)"/> method.</para>
    /// </summary>
    [Fact]
    public void Personal_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IVoteExtensions.Personal(null));

      Assert.False(new Vote().Personal());
      Assert.False(new Vote { PersonResult = string.Empty }.Personal());
      Assert.True(new Vote { PersonResult = "result" }.Personal());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IVoteExtensions.PersonResult(IVote)"/> method.</para>
    /// </summary>
    [Fact]
    public void PersonResult_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IVoteExtensions.PersonResult(null));

      Assert.Null(new Vote { PersonResult = null }.PersonResult());
      Assert.Null(new Vote { PersonResult = string.Empty }.PersonResult());
      Assert.Equal(VotePersonResult.For, new Vote { PersonResult = "for" }.PersonResult());
      Assert.Equal(VotePersonResult.Against, new Vote { PersonResult = "against" }.PersonResult());
      Assert.Equal(VotePersonResult.Abstain, new Vote { PersonResult = "abstain" }.PersonResult());
      Assert.Equal(VotePersonResult.Absent, new Vote { PersonResult = "absent" }.PersonResult());
      Assert.Throws<InvalidOperationException>(() => new Vote { PersonResult = "result" }.PersonResult());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IVoteExtensions.ResultType(IVote)"/> method.</para>
    /// </summary>
    [Fact]
    public void ResultType_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IVoteExtensions.ResultType(null));

      Assert.Null(new Vote().ResultType());
      Assert.Throws<InvalidOperationException>(() => new Vote { ResultType = "type" }.ResultType());
      Assert.Equal(VoteResultType.Quantitative, new Vote { ResultType = "количественное" }.ResultType());
      Assert.Equal(VoteResultType.Rating, new Vote { ResultType = "рейтинговое" }.ResultType());
      Assert.Equal(VoteResultType.Qualitative, new Vote { ResultType = "качественное" }.ResultType());
      Assert.Equal(VoteResultType.Alternative, new Vote { ResultType = "альтернативное" }.ResultType());
    }
  }
}