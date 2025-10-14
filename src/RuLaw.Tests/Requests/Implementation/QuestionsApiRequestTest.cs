using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="QuestionsApiRequest"/>.</para>
/// </summary>
/// <seealso cref="QuestionsApiRequest"/>
public sealed class QuestionsApiRequestTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="QuestionsApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(QuestionsApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<IQuestionsApiRequest>();

    using (new AssertionScope())
    {
      var request = new QuestionsApiRequest();

      request.Parameters.Should().BeEmpty();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new QuestionsApiRequest());
      Test(int.MinValue, new QuestionsApiRequest());
      Test(int.MaxValue, new QuestionsApiRequest());
    }

    return;

    static void Test(int? page, IQuestionsApiRequest request) => request.Page(page).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["page"].Should().Be(page);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.PageSize(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new QuestionsApiRequest());
      Enum.GetValues<PageSize>().ForEach(size => Test(size, new QuestionsApiRequest()));
    }

    return;

    static void Test(PageSize? size, IQuestionsApiRequest request) => request.PageSize(size).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["limit"].Should().Be((int?) size);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.Name(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new QuestionsApiRequest());
      Test(string.Empty, new QuestionsApiRequest());
      Test("name", new QuestionsApiRequest());
    }

    return;

    static void Test(string name, IQuestionsApiRequest request) => request.Name(name).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["name"].Should().Be(name);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.FromDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FromDate_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new QuestionsApiRequest());
      Test(DateTimeOffset.MinValue, new QuestionsApiRequest());
      Test(DateTimeOffset.MaxValue, new QuestionsApiRequest());
      Test(DateTimeOffset.Now, new QuestionsApiRequest());
    }

    return;

    static void Test(DateTimeOffset? date, IQuestionsApiRequest request) => request.FromDate(date).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["dateFrom"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.ToDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ToDate_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new QuestionsApiRequest());
      Test(DateTimeOffset.MinValue, new QuestionsApiRequest());
      Test(DateTimeOffset.MaxValue, new QuestionsApiRequest());
      Test(DateTimeOffset.Now, new QuestionsApiRequest());
    }

    return;

    static void Test(DateTimeOffset? date, IQuestionsApiRequest request) => request.ToDate(date).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["dateTo"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }
}