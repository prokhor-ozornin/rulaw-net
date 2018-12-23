using System;
using System.Collections.Generic;
using System.Linq;
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

    /// <summary>
    ///   <para>Performs testing of <see cref="IVoteExtensions.Subject{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Subject_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IVoteExtensions.Subject<IVote>(null, "subject"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IVote>().Subject(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IVote>().Subject(string.Empty));

      Assert.Empty(Enumerable.Empty<IVote>().Subject("subject"));

      var first = new Vote { Subject = "FIRST" };
      var second = new Vote { Subject = "Second" };
      var votes = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, votes.Subject("first").Single()));
      Assert.True(ReferenceEquals(second, votes.Subject("second").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IVoteExtensions.Successful{ENTITY}(IEnumerable{ENTITY})"/> method.</para>
    /// </summary>
    [Fact]
    public void Successful_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IVoteExtensions.Successful<IVote>(null));

      Assert.Empty(Enumerable.Empty<IVote>().Successful());

      var first = new Vote { Successful = true };
      var second = new Vote { Successful = false };
      var votes = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, votes.Successful().Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IVoteExtensions.Unsuccessful{ENTITY}(IEnumerable{ENTITY})"/> method.</para>
    /// </summary>
    [Fact]
    public void Unsuccessful_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IVoteExtensions.Unsuccessful<IVote>(null));

      Assert.Empty(Enumerable.Empty<IVote>().Unsuccessful());

      var first = new Vote { Successful = true };
      var second = new Vote { Successful = false };
      var votes = new[] { null, first, second };
      Assert.True(ReferenceEquals(second, votes.Unsuccessful().Single()));
    }
  }
}