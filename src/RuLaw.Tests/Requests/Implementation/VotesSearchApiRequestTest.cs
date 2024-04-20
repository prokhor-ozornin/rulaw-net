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
    typeof(VotesSearchApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<IVotesSearchApiRequest>();

    var request = new VotesSearchApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Number(string?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Number_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new VotesSearchApiRequest());
      Validate("number", new VotesSearchApiRequest());
    }

    return;

    static void Validate(string number, IVotesSearchApiRequest request) => request.Number(number).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["number"].Should().Be(number);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Faction(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Faction_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new VotesSearchApiRequest());
      Validate(1L, new VotesSearchApiRequest());
    }

    return;

    static void Validate(long? faction, IVotesSearchApiRequest request) => request.Faction(faction).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["faction"].Should().Be(faction);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Deputy(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new VotesSearchApiRequest());
      Validate(long.MinValue, new VotesSearchApiRequest());
      Validate(long.MaxValue, new VotesSearchApiRequest());
    }

    return;

    static void Validate(long? deputy, IVotesSearchApiRequest request) => request.Deputy(deputy).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["deputy"].Should().Be(deputy);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Convocation(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Convocation_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new VotesSearchApiRequest());
      Validate(long.MinValue, new VotesSearchApiRequest());
      Validate(long.MaxValue, new VotesSearchApiRequest());
    }

    return;

    static void Validate(long? convocation, IVotesSearchApiRequest request) => request.Convocation(convocation).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["convocation"].Should().Be(convocation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.FromDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FromDate_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new VotesSearchApiRequest());
      Validate(DateTimeOffset.MinValue, new VotesSearchApiRequest());
      Validate(DateTimeOffset.MaxValue, new VotesSearchApiRequest());
      Validate(DateTimeOffset.Now, new VotesSearchApiRequest());
    }

    return;

    static void Validate(DateTimeOffset? date, IVotesSearchApiRequest request) => request.FromDate(date).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["from"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.ToDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ToDate_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new VotesSearchApiRequest());
      Validate(DateTimeOffset.MinValue, new VotesSearchApiRequest());
      Validate(DateTimeOffset.MaxValue, new VotesSearchApiRequest());
      Validate(DateTimeOffset.Now, new VotesSearchApiRequest());
    }

    return;

    static void Validate(DateTimeOffset? date, IVotesSearchApiRequest request) => request.ToDate(date).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["to"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Keywords(string?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Keywords_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new VotesSearchApiRequest());
      Validate(string.Empty, new VotesSearchApiRequest());
      Validate("keywords", new VotesSearchApiRequest());
    }

    return;

    static void Validate(string keywords, IVotesSearchApiRequest request) => request.Keywords(keywords).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["keywords"].Should().Be(keywords);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new VotesSearchApiRequest());
      Validate(int.MinValue, new VotesSearchApiRequest());
      Validate(int.MaxValue, new VotesSearchApiRequest());
    }

    return;

    static void Validate(int? page, IVotesSearchApiRequest request) => request.Page(page).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["page"].Should().Be(page);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.Sorting(VotesSorting?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Sorting_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, null, new VotesSearchApiRequest());
      Validate("date_asc", VotesSorting.DateAscending, new VotesSearchApiRequest());
      Validate("date_desc_true", VotesSorting.DateDescending, new VotesSearchApiRequest());
      Validate("date_desc", VotesSorting.DateDescendingByDay, new VotesSearchApiRequest());
      Validate("result_asc", VotesSorting.ResultAscending, new VotesSearchApiRequest());
      Validate("result_desc", VotesSorting.ResultDescending, new VotesSearchApiRequest());
    }

    return;

    static void Validate(string result, VotesSorting? sorting, IVotesSearchApiRequest request) => request.Sorting(sorting).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["sort"].Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="VotesSearchApiRequest.PageSize(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new VotesSearchApiRequest());
      Enum.GetValues<PageSize>().ForEach(size => Validate(size, new VotesSearchApiRequest()));
    }

    return;

    static void Validate(PageSize? size, IVotesSearchApiRequest request) => request.PageSize(size).Should().BeSameAs(request).And.BeOfType<VotesSearchApiRequest>().Which.Parameters["limit"].Should().Be((int?) size);
  }
}