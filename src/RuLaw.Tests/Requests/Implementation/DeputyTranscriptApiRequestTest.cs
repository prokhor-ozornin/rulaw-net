using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyTranscriptApiRequest"/>.</para>
/// </summary>
public sealed class DeputyTranscriptApiRequestTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyTranscriptApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(DeputyTranscriptApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<IDeputyTranscriptApiRequest>();

    var request = new DeputyTranscriptApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new DeputyTranscriptApiRequest());
      Validate(int.MinValue, new DeputyTranscriptApiRequest());
      Validate(int.MaxValue, new DeputyTranscriptApiRequest());
    }

    return;

    static void Validate(int? page, IDeputyTranscriptApiRequest request) => request.Page(page).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["page"].Should().Be(page);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.PageSize(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new DeputyTranscriptApiRequest());
      Enum.GetValues<PageSize>().ForEach(size => Validate(size, new DeputyTranscriptApiRequest()));
    }

    return;

    static void Validate(PageSize? size, IDeputyTranscriptApiRequest request) => request.PageSize(size).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["limit"].Should().Be((int?) size);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Name(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new DeputyTranscriptApiRequest());
      Validate(string.Empty, new DeputyTranscriptApiRequest());
      Validate("name", new DeputyTranscriptApiRequest());
    }

    return;

    static void Validate(string name, IDeputyTranscriptApiRequest request) => request.Name(name).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["name"].Should().Be(name);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Deputy(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new DeputyTranscriptApiRequest());
      Validate(long.MinValue, new DeputyTranscriptApiRequest());
      Validate(long.MaxValue, new DeputyTranscriptApiRequest());
    }

    return;

    static void Validate(long? deputy, IDeputyTranscriptApiRequest request) => request.Deputy(deputy).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["deputy"].Should().Be(deputy);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.FromDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FromDate_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new DeputyTranscriptApiRequest());
      Validate(DateTimeOffset.MinValue, new DeputyTranscriptApiRequest());
      Validate(DateTimeOffset.MaxValue, new DeputyTranscriptApiRequest());
      Validate(DateTimeOffset.Now, new DeputyTranscriptApiRequest());
    }

    return;

    static void Validate(DateTimeOffset? date, IDeputyTranscriptApiRequest request) => request.FromDate(date).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["dateFrom"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.ToDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ToDate_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new DeputyTranscriptApiRequest());
      Validate(DateTimeOffset.MinValue, new DeputyTranscriptApiRequest());
      Validate(DateTimeOffset.MaxValue, new DeputyTranscriptApiRequest());
      Validate(DateTimeOffset.Now, new DeputyTranscriptApiRequest());
    }

    return;

    static void Validate(DateTimeOffset? date, IDeputyTranscriptApiRequest request) => request.ToDate(date).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["dateTo"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }
}