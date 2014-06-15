using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Vote"/>.</para>
  /// </summary>
  public sealed class VoteTests : UnitTestsBase<Vote>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new Vote(), new { id = 0, result = false, voteDate = default(DateTime) });
      this.TestJson(
        new Vote
        {
          Id = 1,
          AbsentVotesCount = 1,
          AbstainVotesCount = 2,
          AgainstVotesCount = 3,
          Date = DateTime.MinValue,
          ForVotesCount = 4,
          PersonResult = "personResult",
          Subject = "subject",
          Successful = true,
          TotalVotesCount = 5,
          ResultType = "type"
        },
        new { id = 1, absentCount = 1, abstainCount = 2, againstCount = 3, forCount = 4, personResult = "personResult", result = true, resultType = "type", subject = "subject", voteCount = 5, voteDate = DateTime.MinValue }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new Vote(), "vote", new { id = 0, result = false, voteDate = default(DateTime).ISO8601() });
      this.TestXml(
        new Vote
        {
          Id = 1,
          AbsentVotesCount = 1,
          AbstainVotesCount = 2,
          AgainstVotesCount = 3,
          Date = DateTime.MinValue,
          ForVotesCount = 4,
          PersonResult = "personResult",
          Subject = "subject",
          Successful = true,
          TotalVotesCount = 5,
          ResultType = "type"
        },
        "vote",
        new { id = 1, absentCount = 1, abstainCount = 2, againstCount = 3, forCount = 4, personResult = "personResult", result = true, resultType = "type", subject = "subject", voteCount = 5, voteDate = DateTime.MinValue.ISO8601() }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Vote()"/>
    [Fact]
    public void Constructors()
    {
      var vote = new Vote();
      Assert.Equal(0, vote.Id);
      Assert.Null(vote.AbsentVotesCount);
      Assert.Null(vote.AbstainVotesCount);
      Assert.Null(vote.AgainstVotesCount);
      Assert.Equal(default(DateTime), vote.Date);
      Assert.Null(vote.ForVotesCount);
      Assert.False(vote.Personal);
      Assert.Null(vote.PersonResult);
      Assert.Null(vote.ResultType);
      Assert.Null(vote.Subject);
      Assert.False(vote.Successful);
      Assert.Null(vote.TotalVotesCount);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Vote { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.AbsentVotesCount"/> property.</para>
    /// </summary>
    [Fact]
    public void AbsentVotesCount_Property()
    {
      Assert.Equal(1, new Vote { AbsentVotesCount = 1 }.AbsentVotesCount);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.AbstainVotesCount"/> property.</para>
    /// </summary>
    [Fact]
    public void AbstainVotesCount_Property()
    {
      Assert.Equal(1, new Vote { AbstainVotesCount = 1 }.AbstainVotesCount);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.AgainstVotesCount"/> property.</para>
    /// </summary>
    [Fact]
    public void AgainstVotesCount_Property()
    {
      Assert.Equal(1, new Vote { AgainstVotesCount = 1 }.AgainstVotesCount);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new Vote { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.ForVotesCount"/> property.</para>
    /// </summary>
    [Fact]
    public void ForVotesCount_Property()
    {
      Assert.Equal(1, new Vote { ForVotesCount = 1 }.ForVotesCount);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.PersonResult"/> property.</para>
    /// </summary>
    [Fact]
    public void PersonResult_Property()
    {
      Assert.Equal("result", new Vote { PersonResult = "result" }.PersonResult);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.ResultType"/> property.</para>
    /// </summary>
    [Fact]
    public void ResultType_Property()
    {
      Assert.Equal("type", new Vote { ResultType = "type" }.ResultType);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.Subject"/> property.</para>
    /// </summary>
    [Fact]
    public void Subject_Property()
    {
      Assert.Equal("subject", new Vote { Subject = "subject" }.Subject);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.Successful"/> property.</para>
    /// </summary>
    [Fact]
    public void Successfull_Property()
    {
      Assert.True(new Vote { Successful = true }.Successful);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.TotalVotesCount"/> property.</para>
    /// </summary>
    [Fact]
    public void TotalVotesCount_Property()
    {
      Assert.Equal(1, new Vote { TotalVotesCount = 1 }.TotalVotesCount);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.GetPersonResult()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetPersonResult_Method()
    {
      Assert.Null(new Vote().GetPersonResult());
      Assert.Throws<InvalidOperationException>(() => new Vote { PersonResult = "result" }.GetPersonResult());
      Assert.Equal(VotePersonResult.For, new Vote { PersonResult = "for" }.GetPersonResult());
      Assert.Equal(VotePersonResult.Against, new Vote { PersonResult = "against" }.GetPersonResult());
      Assert.Equal(VotePersonResult.Abstain, new Vote { PersonResult = "abstain" }.GetPersonResult());
      Assert.Equal(VotePersonResult.Absent, new Vote { PersonResult = "absent" }.GetPersonResult());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.GetResultType()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetResultType_Method()
    {
      Assert.Null(new Vote().GetResultType());
      Assert.Throws<InvalidOperationException>(() => new Vote { ResultType = "type" }.GetResultType());
      Assert.Equal(VoteResultType.Quantitative, new Vote { ResultType = "количественное" }.GetResultType());
      Assert.Equal(VoteResultType.Rating, new Vote { ResultType = "рейтинговое" }.GetResultType());
      Assert.Equal(VoteResultType.Qualitative, new Vote { ResultType = "качественное" }.GetResultType());
      Assert.Equal(VoteResultType.Alternative, new Vote { ResultType = "альтернативное" }.GetResultType());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.CompareTo(Vote)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Vote.Equals(Vote)"/></description></item>
    ///     <item><description><see cref="Vote.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Vote.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("subject", new Vote { Subject = "subject" }.ToString());
    }
  }
}