using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IVoteExtensions"/>.</para>
/// </summary>
public sealed class IVoteExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.Personal(IVote)"/> method.</para>
  /// </summary>
  [Fact]
  public void Personal_Method()
  {
    AssertionExtensions.Should(() => IVoteExtensions.Personal(null)).ThrowExactly<ArgumentNullException>();

    new Vote().Personal().Should().BeFalse();
    new Vote(new {PersonResult = string.Empty}).Personal().Should().BeFalse();
    new Vote(new {PersonResult = "result"}).Personal().Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.PersonResult(IVote)"/> method.</para>
  /// </summary>
  [Fact]
  public void PersonResult_Method()
  {
    AssertionExtensions.Should(() => IVoteExtensions.PersonResult(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => new Vote(new { PersonResult = "result" }).PersonResult()).ThrowExactly<InvalidOperationException>();

    new Vote(new {}).PersonResult().Should().BeNull();
    new Vote(new {PersonResult = string.Empty}).PersonResult().Should().BeNull();
    new Vote(new {PersonResult = "for"}).PersonResult().Should().Be(VotePersonResult.For);
    new Vote(new {PersonResult = "against"}).PersonResult().Should().Be(VotePersonResult.Against);
    new Vote(new {PersonResult = "abstain"}).PersonResult().Should().Be(VotePersonResult.Abstain);
    new Vote(new {PersonResult = "absent"}).PersonResult().Should().Be(VotePersonResult.Absent);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.ResultType(IVote)"/> method.</para>
  /// </summary>
  [Fact]
  public void ResultType_Method()
  {
    AssertionExtensions.Should(() => IVoteExtensions.ResultType(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => new Vote(new { ResultType = "type" }).ResultType()).ThrowExactly<InvalidOperationException>();

    new Vote().ResultType().Should().BeNull();
    new Vote(new {ResultType = "количественное"}).ResultType().Should().Be(VoteResultType.Quantitative);
    new Vote(new {ResultType = "рейтинговое"}).ResultType().Should().Be(VoteResultType.Rating);
    new Vote(new {ResultType = "качественное"}).ResultType().Should().Be(VoteResultType.Qualitative);
    new Vote(new {ResultType = "альтернативное"}).ResultType().Should().Be(VoteResultType.Alternative);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.Subject{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Subject_Method()
  {
    AssertionExtensions.Should(() => IVoteExtensions.Subject<IVote>(null, "subject")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IVote>().Subject(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Enumerable.Empty<IVote>().Subject(string.Empty)).ThrowExactly<ArgumentException>();

    Enumerable.Empty<IVote>().Subject("subject").Should().NotBeNull().And.BeEmpty();

    var first = new Vote(new {Subject = "FIRST"});
    var second = new Vote(new {Subject = "Second"});
    var votes = new[] {null, first, second};
    votes.Subject("first").Should().NotBeNullOrEmpty().And.Equal(first);
    votes.Subject("second").Should().NotBeNullOrEmpty().And.Equal(second);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.Successful{TEntity}(IEnumerable{TEntity})"/> method.</para>
  /// </summary>
  [Fact]
  public void Successful_Method()
  {
    AssertionExtensions.Should(() => IVoteExtensions.Successful<IVote>(null)).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<IVote>().Successful().Should().NotBeNull().And.BeEmpty();

    var first = new Vote(new {Successful = true});
    var second = new Vote(new {Successful = false});
    var votes = new[] {null, first, second};
    votes.Successful().Should().NotBeNullOrEmpty().And.Equal(first);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVoteExtensions.Unsuccessful{TEntity}(IEnumerable{TEntity})"/> method.</para>
  /// </summary>
  [Fact]
  public void Unsuccessful_Method()
  {
    AssertionExtensions.Should(() => IVoteExtensions.Unsuccessful<IVote>(null)).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<IVote>().Unsuccessful().Should().NotBeNull().And.BeEmpty();

    var first = new Vote(new {Successful = true});
    var second = new Vote(new {Successful = false});
    var votes = new[] {null, first, second};
    votes.Unsuccessful().Should().NotBeNullOrEmpty().And.Equal(second);
  }
}