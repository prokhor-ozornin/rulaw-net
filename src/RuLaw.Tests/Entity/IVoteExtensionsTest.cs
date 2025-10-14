using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IVoteExtensions"/>.</para>
/// </summary>
/// <seealso cref="IVoteExtensions"/>
public sealed class IVoteExtensionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.Personal(IVote)"/> method.</para>
  /// </summary>
  [Fact]
  public void Personal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVoteExtensions.Personal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("vote");

      Enum.GetValues<VotePersonResult>().ForEach(result => Test(true, new Vote { PersonResult = result.ToString() }));
      Test(false, new Vote());
      Test(false, new Vote { PersonResult = string.Empty });
      Test(false, new Vote { PersonResult = "result" });
    }

    return;

    static void Test(bool result, IVote vote) => vote.Personal().Should().Be(result);
}

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.PersonResult(IVote)"/> method.</para>
  /// </summary>
  [Fact]
  public void PersonResult_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVoteExtensions.PersonResult(null)).ThrowExactly<ArgumentNullException>().WithParameterName("vote");

      Test(null, new Vote());
      Test(null, new Vote { PersonResult = string.Empty });
      Test(VotePersonResult.For, new Vote { PersonResult = "for" });
      Test(VotePersonResult.Against, new Vote { PersonResult = "against" });
      Test(VotePersonResult.Abstain, new Vote { PersonResult = "abstain" });
      Test(VotePersonResult.Absent, new Vote { PersonResult = "absent" });
    }

    return;

    static void Test(VotePersonResult? result, IVote vote) => vote.PersonResult().Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.ResultType(IVote)"/> method.</para>
  /// </summary>
  [Fact]
  public void ResultType_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVoteExtensions.ResultType(null)).ThrowExactly<ArgumentNullException>().WithParameterName("vote");

      Test(null, new Vote());
      Test(null, new Vote { ResultType = string.Empty });
      Test(VoteResultType.Quantitative, new Vote { ResultType = "количественное" });
      Test(VoteResultType.Rating, new Vote { ResultType = "рейтинговое" });
      Test(VoteResultType.Qualitative, new Vote { ResultType = "качественное" });
      Test(VoteResultType.Alternative, new Vote { ResultType = "альтернативное" });
    }

    return;

    static void Test(VoteResultType? result, IVote vote) => vote.ResultType().Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.Subject{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Subject_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVoteExtensions.Subject<IVote>(null, "subject")).ThrowExactly<ArgumentNullException>().WithParameterName("votes");

      Test([], [], null);
      Test([], [], "subject");

      var first = new Vote { Subject = "first" };
      var second = new Vote { Subject = "second" };
      Test([], [null], null);
      Test([first], [null, first, second, null], first.Subject);
    }

    return;

    static void Test(IEnumerable<IVote> result, IEnumerable<IVote> votes, string subject) => votes.Subject(subject).Should().BeAssignableTo<IEnumerable<IVote>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.Successful{TEntity}(IEnumerable{TEntity})"/> method.</para>
  /// </summary>
  [Fact]
  public void Successful_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVoteExtensions.Successful<IVote>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("votes");

      Test([], []);

      var first = new Vote { Successful = true };
      var second = new Vote { Successful = false };
      var third = new Vote { Successful = null };
      Test([first], [null, first, second, third, null]);
    }

    return;

    static void Test(IEnumerable<IVote> result, IEnumerable<IVote> votes) => votes.Successful().Should().BeAssignableTo<IEnumerable<IVote>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.Unsuccessful{TEntity}(IEnumerable{TEntity})"/> method.</para>
  /// </summary>
  [Fact]
  public void Unsuccessful_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IVoteExtensions.Unsuccessful<IVote>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("votes");

      var first = new Vote { Successful = true };
      var second = new Vote { Successful = false };
      var third = new Vote { Successful = null };
      Test([second, third], [null, first, second, third, null]);
    }

    return;

    static void Test(IEnumerable<IVote> result, IEnumerable<IVote> votes) => votes.Unsuccessful().Should().BeAssignableTo<IEnumerable<IVote>>().And.Equal(result);
  }
}