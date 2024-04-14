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

      new Vote().Personal().Should().BeFalse();
      new Vote {PersonResult = string.Empty}.Personal().Should().BeFalse();
      new Vote {PersonResult = "result"}.Personal().Should().BeFalse();
    }

    return;

    static void Validate()
    {

    }
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
      AssertionExtensions.Should(() => new Vote { PersonResult = "result" }.PersonResult()).ThrowExactly<InvalidOperationException>();

      new Vote {}.PersonResult().Should().BeNull();
      new Vote {PersonResult = string.Empty}.PersonResult().Should().BeNull();
      new Vote {PersonResult = "for"}.PersonResult().Should().Be(VotePersonResult.For);
      new Vote {PersonResult = "against"}.PersonResult().Should().Be(VotePersonResult.Against);
      new Vote {PersonResult = "abstain"}.PersonResult().Should().Be(VotePersonResult.Abstain);
      new Vote {PersonResult = "absent"}.PersonResult().Should().Be(VotePersonResult.Absent);
    }

    return;

    static void Validate()
    {

    }
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
      AssertionExtensions.Should(() => new Vote { ResultType = "type" }.ResultType()).ThrowExactly<InvalidOperationException>();

      new Vote().ResultType().Should().BeNull();
      new Vote {ResultType = "количественное"}.ResultType().Should().Be(VoteResultType.Quantitative);
      new Vote {ResultType = "рейтинговое"}.ResultType().Should().Be(VoteResultType.Rating);
      new Vote {ResultType = "качественное"}.ResultType().Should().Be(VoteResultType.Qualitative);
      new Vote {ResultType = "альтернативное"}.ResultType().Should().Be(VoteResultType.Alternative);
    }

    return;

    static void Validate()
    {

    }
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
      AssertionExtensions.Should(() => Enumerable.Empty<IVote>().Subject(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Enumerable.Empty<IVote>().Subject(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("subject");

      Enumerable.Empty<IVote>().Subject("subject").Should().NotBeNull().And.BeEmpty();

      var first = new Vote {Subject = "FIRST"};
      var second = new Vote {Subject = "Second"};
      var votes = first.ToSequence(second, null);
      votes.Subject("first").Should().NotBeNullOrEmpty().And.Equal(first);
      votes.Subject("second").Should().NotBeNullOrEmpty().And.Equal(second);
    }

    return;

    static void Validate()
    {

    }
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

      Enumerable.Empty<IVote>().Successful().Should().NotBeNull().And.BeEmpty();

      var first = new Vote {Successful = true};
      var second = new Vote {Successful = false};
      var votes = first.ToSequence(second, null);
      votes.Successful().Should().NotBeNullOrEmpty().And.Equal(first);
    }

    return;

    static void Validate()
    {

    }
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

      Enumerable.Empty<IVote>().Unsuccessful().Should().NotBeNull().And.BeEmpty();

      var first = new Vote {Successful = true};
      var second = new Vote {Successful = false};
      var votes = first.ToSequence(second, null);
      votes.Unsuccessful().Should().NotBeNullOrEmpty().And.Equal(second);
    }

    return;

    static void Validate()
    {

    }
  }
}