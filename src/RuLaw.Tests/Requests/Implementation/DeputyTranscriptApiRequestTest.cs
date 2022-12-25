using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputyTranscriptApiRequest"/>.</para>
/// </summary>
public sealed class DeputyTranscriptApiRequestTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputyTranscriptApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    var request = new DeputyTranscriptApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    var request = new DeputyTranscriptApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Page(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["page"].Should().BeNull();

    request.Page(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["page"].Should().Be(1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.PageSize(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    void Validate(PageSize? size)
    {
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();

      request.PageSize(size).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["limit"].Should().Be((int?) size);
    }

    using (new AssertionScope())
    {
      Validate(null);
      Enum.GetValues<PageSize>().ForEach(size => Validate(size));
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Name(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    var request = new DeputyTranscriptApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Name(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["name"].Should().BeNull();

    request.Name("name").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["name"].Should().Be("name");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Deputy(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    var request = new DeputyTranscriptApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Deputy(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().BeNull();

    request.Deputy(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.FromDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FromDate_Method()
  {
    void Validate(DateTimeOffset? date)
    {
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();

      request.FromDate(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateFrom"].Should().BeNull();

      request.FromDate(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateFrom"].Should().Be(date?.AsString());
    }

    using (new AssertionScope())
    {
      Validate(null);
      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(date => Validate(date));
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.ToDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ToDate_Method()
  {
    void Validate(DateTimeOffset? date)
    {
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();

      request.ToDate(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateTo"].Should().BeNull();

      request.ToDate(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateTo"].Should().Be(date?.AsString());
    }

    using (new AssertionScope())
    {
      Validate(null);
      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(date => Validate(date));
    }
  }
}