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
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();

      request.Page(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["page"].Should().BeNull();

      request.Page(1).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["page"].Should().Be(1);
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.PageSize(PageSize?)"/> method.</para>
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
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();

      request.PageSize(size).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["limit"].Should().Be((int?) size);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Name(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();

      request.Name(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["name"].Should().BeNull();

      request.Name("name").Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["name"].Should().Be("name");
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.Deputy(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    using (new AssertionScope())
    {
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();

      request.Deputy(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["deputy"].Should().BeNull();

      request.Deputy(1).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["deputy"].Should().Be(1L);
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.FromDate(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FromDate_Method()
  {
    using (new AssertionScope())
    {
      Validate(null);
      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(date => Validate(date));
    }

    return;

    static void Validate(DateTimeOffset? date)
    {
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();

      request.FromDate(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateFrom"].Should().BeNull();

      request.FromDate(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateFrom"].Should().Be(date?.AsString());
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputyTranscriptApiRequest.ToDate(DateTimeOffset?)"/> method.</para>
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
      var request = new DeputyTranscriptApiRequest();

      request.Parameters.Should().BeEmpty();

      request.ToDate(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateTo"].Should().BeNull();

      request.ToDate(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["dateTo"].Should().Be(date?.AsString());
    }
  }
}