using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="VotesSearchApiRequest"/>.</para>
/// </summary>
public sealed class VotesSearchApiRequestTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="VotesSearchApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    var request = new VotesSearchApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Number(string?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Number_Method()
  {
    var request = new VotesSearchApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Number(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["number"].Should().BeNull();

    request.Number("number").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["number"].Should().Be("number");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Faction(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Faction_Method()
  {
    var request = new VotesSearchApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Faction(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["faction"].Should().BeNull();

    request.Faction(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["faction"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Deputy(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    var request = new VotesSearchApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Deputy(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().BeNull();

    request.Deputy(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Convocation(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Convocation_Method()
  {
    var request = new VotesSearchApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Convocation(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["convocation"].Should().BeNull();

    request.Convocation(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["convocation"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.FromDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FromDate_Method()
  {
    using (new AssertionScope())
    {
      Validate(null);
      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow}.ForEach(date => Validate(date));
    }

    return;

    static void Validate(DateTimeOffset? date)
    {
      var request = new VotesSearchApiRequest();

      request.Parameters.Should().BeEmpty();

      request.FromDate(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["from"].Should().BeNull();

      request.FromDate(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["from"].Should().Be(date?.AsString());
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.ToDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ToDate_Method()
  {
    using (new AssertionScope())
    {
      Validate(null);
      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(date => Validate(date));
    }

    return;

    static void Validate(DateTimeOffset? date)
    {
      var request = new VotesSearchApiRequest();

      request.Parameters.Should().BeEmpty();

      request.ToDate(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["to"].Should().BeNull();

      request.ToDate(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["to"].Should().Be(date?.AsString());
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Keywords(string?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Keywords_Method()
  {
    var request = new VotesSearchApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Keywords(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["keywords"].Should().BeNull();

    request.Keywords("key").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["keywords"].Should().Be("key");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    var request = new VotesSearchApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Page(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["page"].Should().BeNull();

    request.Page(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["page"].Should().Be(1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Sorting(VotesSorting?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Sorting_Method()
  {
    var request = new VotesSearchApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Sorting(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().BeNull();

    request.Sorting(VotesSorting.DateAscending).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("date_asc");

    request.Sorting(VotesSorting.DateDescending).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("date_desc_true");

    request.Sorting(VotesSorting.DateDescendingByDay).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("date_desc");

    request.Sorting(VotesSorting.ResultAscending).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("result_asc");

    request.Sorting(VotesSorting.ResultDescending).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("result_desc");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Limit(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Limit_Method()
  {
    using (new AssertionScope())
    {
      Validate(null);
      Enum.GetValues<PageSize>().ForEach(size => Validate(size));
    }

    return;

    static void Validate(PageSize? size)
    {
      var request = new VotesSearchApiRequest();

      request.Parameters.Should().BeEmpty();

      request.Limit(size).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["limit"].Should().Be((int?) size);
    }
  }
}