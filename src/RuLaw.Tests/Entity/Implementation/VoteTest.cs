using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Vote"/>.</para>
/// </summary>
public sealed class VoteTest : ClassTest<Vote>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Vote()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Vote).Should().BeDerivedFrom<object>().And.Implement<IVote>();

    var vote = new Vote();
    vote.Id.Should().BeNull();
    vote.Date.Should().BeNull();
    vote.Subject.Should().BeNull();
    vote.Successful.Should().BeNull();
    vote.ResultType.Should().BeNull();
    vote.PersonResult.Should().BeNull();
    vote.TotalVotesCount.Should().BeNull();
    vote.ForVotesCount.Should().BeNull();
    vote.AgainstVotesCount.Should().BeNull();
    vote.AbstainVotesCount.Should().BeNull();
    vote.AbsentVotesCount.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Vote { Id = int.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new Vote { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.Subject"/> property.</para>
  /// </summary>
  [Fact]
  public void Subject_Property()
  {
    new Vote { Subject = Guid.Empty.ToString() }.Subject.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.Successful"/> property.</para>
  /// </summary>
  [Fact]
  public void Successfull_Property()
  {
    new Vote { Successful = true }.Successful.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.ResultType"/> property.</para>
  /// </summary>
  [Fact]
  public void ResultType_Property()
  {
    new Vote { ResultType = Guid.Empty.ToString() }.ResultType.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.PersonResult"/> property.</para>
  /// </summary>
  [Fact]
  public void PersonResult_Property()
  {
    new Vote { PersonResult = Guid.Empty.ToString() }.PersonResult.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.TotalVotesCount"/> property.</para>
  /// </summary>
  [Fact]
  public void TotalVotesCount_Property()
  {
    new Vote { TotalVotesCount = int.MaxValue }.TotalVotesCount.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.ForVotesCount"/> property.</para>
  /// </summary>
  [Fact]
  public void ForVotesCount_Property()
  {
    new Vote { ForVotesCount = int.MaxValue }.ForVotesCount.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.AgainstVotesCount"/> property.</para>
  /// </summary>
  [Fact]
  public void AgainstVotesCount_Property()
  {
    new Vote { AgainstVotesCount = int.MaxValue }.AgainstVotesCount.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.AbstainVotesCount"/> property.</para>
  /// </summary>
  [Fact]
  public void AbstainVotesCount_Property()
  {
    new Vote { AbstainVotesCount = int.MaxValue }.AbstainVotesCount.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.AbsentVotesCount"/> property.</para>
  /// </summary>
  [Fact]
  public void AbsentVotesCount_Property()
  {
    new Vote { AbsentVotesCount = int.MaxValue }.AbsentVotesCount.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.CompareTo(IVote)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Vote.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Vote.Equals(IVote)"/></description></item>
  ///     <item><description><see cref="Vote.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Vote.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Vote.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Vote.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Vote {Subject = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Vote
      {
        Id = 1,
        AbsentVotesCount = 1,
        AbstainVotesCount = 2,
        AgainstVotesCount = 3,
        Date = DateTimeOffset.MinValue,
        ForVotesCount = 4,
        PersonResult = "personResult",
        Subject = "subject",
        Successful = true,
        TotalVotesCount = 5,
        ResultType = "type"
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}