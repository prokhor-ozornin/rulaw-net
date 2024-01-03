using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="QuestionsApiRequest"/>.</para>
/// </summary>
public sealed class QuestionsApiRequestTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="QuestionsApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    var request = new QuestionsApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    var request = new QuestionsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Page(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["page"].Should().BeNull();

    request.Page(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["page"].Should().Be(1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.PageSize(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    using (new AssertionScope())
    {
      Validate(null);
      Enum.GetValues<PageSize>().ForEach(size => Validate(size));
    }

    return;

    static void Validate(PageSize? size)
    {
      var request = new QuestionsApiRequest();

      request.Parameters.Should().BeEmpty();

      request.PageSize(size).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["limit"].Should().Be((int?) size);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.Name(string?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    var request = new QuestionsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Name(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["name"].Should().Be("name");

    request.Name("name").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["name"].Should().Be("name");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.FromDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FromDate_Method()
  {
    var request = new QuestionsApiRequest();
    
    request.Parameters.Should().BeEmpty();

    request.FromDate(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["dateFrom"].Should().BeNull();

    foreach (var date in new[] {DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow})
    {
      request.FromDate(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateFrom"].Should().Be(date.AsString());
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.ToDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ToDate_Method()
  {
    var request = new QuestionsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.ToDate(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["dateTo"].Should().BeNull();

    foreach (var date in new[] {DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow})
    {
      request.ToDate(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateTo"].Should().Be(date.AsString());
    }
  }
}