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
    typeof(QuestionsApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<IQuestionsApiRequest>();

    var request = new QuestionsApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new QuestionsApiRequest());
      Validate(int.MinValue, new QuestionsApiRequest());
      Validate(int.MaxValue, new QuestionsApiRequest());
    }

    return;

    static void Validate(int? page, IQuestionsApiRequest request) => request.Page(page).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["page"].Should().Be(page);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.PageSize(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new QuestionsApiRequest());
      Enum.GetValues<PageSize>().ForEach(size => Validate(size, new QuestionsApiRequest()));
    }

    return;

    static void Validate(PageSize? size, IQuestionsApiRequest request) => request.PageSize(size).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["limit"].Should().Be((int?) size);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.Name(string?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new QuestionsApiRequest());
      Validate(string.Empty, new QuestionsApiRequest());
      Validate("name", new QuestionsApiRequest());
    }

    return;

    static void Validate(string name, IQuestionsApiRequest request) => request.Name(name).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["name"].Should().Be(name);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.FromDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FromDate_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new QuestionsApiRequest());
      Validate(DateTimeOffset.MinValue, new QuestionsApiRequest());
      Validate(DateTimeOffset.MaxValue, new QuestionsApiRequest());
      Validate(DateTimeOffset.Now, new QuestionsApiRequest());
    }

    return;

    static void Validate(DateTimeOffset? date, IQuestionsApiRequest request) => request.FromDate(date).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["dateFrom"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="QuestionsApiRequest.ToDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ToDate_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new QuestionsApiRequest());
      Validate(DateTimeOffset.MinValue, new QuestionsApiRequest());
      Validate(DateTimeOffset.MaxValue, new QuestionsApiRequest());
      Validate(DateTimeOffset.Now, new QuestionsApiRequest());
    }

    return;

    static void Validate(DateTimeOffset? date, IQuestionsApiRequest request) => request.ToDate(date).Should().BeSameAs(request).And.BeOfType<QuestionsApiRequest>().Which.Parameters["dateTo"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }
}