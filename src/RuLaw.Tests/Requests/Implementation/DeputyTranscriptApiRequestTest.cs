using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyTranscriptApiRequest"/>.</para>
/// </summary>
public sealed class DeputyTranscriptApiRequestTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyTranscriptApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(DeputyTranscriptApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<IDeputyTranscriptApiRequest>();

    using (new AssertionScope())
    {
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new DeputyTranscriptApiRequest());
      Test(int.MinValue, new DeputyTranscriptApiRequest());
      Test(int.MaxValue, new DeputyTranscriptApiRequest());
    }

    return;

    static void Test(int? page, IDeputyTranscriptApiRequest request) => request.Page(page).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["page"].Should().Be(page);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.PageSize(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new DeputyTranscriptApiRequest());
      Enum.GetValues<PageSize>().ForEach(size => Test(size, new DeputyTranscriptApiRequest()));
    }

    return;

    static void Test(PageSize? size, IDeputyTranscriptApiRequest request) => request.PageSize(size).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["limit"].Should().Be((int?) size);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Name(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new DeputyTranscriptApiRequest());
      Test(string.Empty, new DeputyTranscriptApiRequest());
      Test("name", new DeputyTranscriptApiRequest());
    }

    return;

    static void Test(string name, IDeputyTranscriptApiRequest request) => request.Name(name).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["name"].Should().Be(name);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Deputy(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new DeputyTranscriptApiRequest());
      Test(long.MinValue, new DeputyTranscriptApiRequest());
      Test(long.MaxValue, new DeputyTranscriptApiRequest());
    }

    return;

    static void Test(long? deputy, IDeputyTranscriptApiRequest request) => request.Deputy(deputy).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["deputy"].Should().Be(deputy);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.FromDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FromDate_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new DeputyTranscriptApiRequest());
      Test(DateTimeOffset.MinValue, new DeputyTranscriptApiRequest());
      Test(DateTimeOffset.MaxValue, new DeputyTranscriptApiRequest());
      Test(DateTimeOffset.Now, new DeputyTranscriptApiRequest());
    }

    return;

    static void Test(DateTimeOffset? date, IDeputyTranscriptApiRequest request) => request.FromDate(date).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["dateFrom"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.ToDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ToDate_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new DeputyTranscriptApiRequest());
      Test(DateTimeOffset.MinValue, new DeputyTranscriptApiRequest());
      Test(DateTimeOffset.MaxValue, new DeputyTranscriptApiRequest());
      Test(DateTimeOffset.Now, new DeputyTranscriptApiRequest());
    }

    return;

    static void Test(DateTimeOffset? date, IDeputyTranscriptApiRequest request) => request.ToDate(date).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["dateTo"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }
}