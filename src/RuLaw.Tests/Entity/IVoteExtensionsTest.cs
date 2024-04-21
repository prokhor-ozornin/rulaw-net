using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IVoteExtensions"/>.</para>
/// </summary>
public sealed class IVoteExtensionsTest : UnitTest
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

      Enum.GetValues<VotePersonResult>().ForEach(result => Validate(true, new Vote { PersonResult = result.ToString() }));
      Validate(false, new Vote());
      Validate(false, new Vote { PersonResult = string.Empty });
      Validate(false, new Vote { PersonResult = "result" });
    }

    return;

    static void Validate(bool result, IVote vote) => vote.Personal().Should().Be(result);
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

      Validate(null, new Vote());
      Validate(null, new Vote { PersonResult = string.Empty });
      Validate(VotePersonResult.For, new Vote { PersonResult = "for" });
      Validate(VotePersonResult.Against, new Vote { PersonResult = "against" });
      Validate(VotePersonResult.Abstain, new Vote { PersonResult = "abstain" });
      Validate(VotePersonResult.Absent, new Vote { PersonResult = "absent" });
    }

    return;

    static void Validate(VotePersonResult? result, IVote vote) => vote.PersonResult().Should().Be(result);
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

      Validate(null, new Vote());
      Validate(null, new Vote { ResultType = string.Empty });
      Validate(VoteResultType.Quantitative, new Vote { ResultType = "количественное" });
      Validate(VoteResultType.Rating, new Vote { ResultType = "рейтинговое" });
      Validate(VoteResultType.Qualitative, new Vote { ResultType = "качественное" });
      Validate(VoteResultType.Alternative, new Vote { ResultType = "альтернативное" });
    }

    return;

    static void Validate(VoteResultType? result, IVote vote) => vote.ResultType().Should().Be(result);
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

      Validate([], [], null);
      Validate([], [], "subject");

      var first = new Vote { Subject = "first" };
      var second = new Vote { Subject = "second" };
      Validate([], [null], null);
      Validate([first], [null, first, second, null], first.Subject);
    }

    return;

    static void Validate(IEnumerable<IVote> result, IEnumerable<IVote> votes, string subject) => votes.Subject(subject).Should().BeAssignableTo<IEnumerable<IVote>>().And.Equal(result);
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

      Validate([], []);

      var first = new Vote { Successful = true };
      var second = new Vote { Successful = false };
      var third = new Vote { Successful = null };
      Validate([first], [null, first, second, third, null]);
    }

    return;

    static void Validate(IEnumerable<IVote> result, IEnumerable<IVote> votes) => votes.Successful().Should().BeAssignableTo<IEnumerable<IVote>>().And.Equal(result);
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
      Validate([second, third], [null, first, second, third, null]);
    }

    return;

    static void Validate(IEnumerable<IVote> result, IEnumerable<IVote> votes) => votes.Unsuccessful().Should().BeAssignableTo<IEnumerable<IVote>>().And.Equal(result);
  }
}