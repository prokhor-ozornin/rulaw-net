using System;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyTranscriptLawApiCall"/>.</para>
  /// </summary>
  public sealed class DeputyTranscriptLawApiCallTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputyTranscriptLawApiCall()"/>
    [Fact]
    public void Constructors()
    {
      var call = new DeputyTranscriptLawApiCall();
      Assert.Empty(call.Parameters);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptLawApiCall.Page(int)"/> method.</para>
    /// </summary>
    [Fact]
    public void Page_Method()
    {
      var call = new DeputyTranscriptLawApiCall();
      Assert.False(call.Parameters.ContainsKey("page"));
      Assert.True(ReferenceEquals(call, call.Page(1)));
      Assert.Equal(1, call.Parameters["page"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptLawApiCall.PageSize(PageSize)"/> method.</para>
    /// </summary>
    [Fact]
    public void PageSize_Method()
    {
      var call = new DeputyTranscriptLawApiCall();
      Assert.False(call.Parameters.ContainsKey("limit"));
      Assert.True(ReferenceEquals(call, call.PageSize(PageSize.Five)));
      Assert.Equal(5, call.Parameters["limit"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptLawApiCall.Deputy(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deputy_Method()
    {
      var call = new DeputyTranscriptLawApiCall();
      Assert.False(call.Parameters.ContainsKey("deputy"));
      Assert.True(ReferenceEquals(call, call.Deputy(1)));
      Assert.Equal((long) 1, call.Parameters["deputy"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptLawApiCall.From(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void From_Method()
    {
      var call = new DeputyTranscriptLawApiCall();
      Assert.False(call.Parameters.ContainsKey("dateFrom"));
      Assert.True(ReferenceEquals(call, call.From(DateTime.MinValue)));
      Assert.Equal(DateTime.MinValue.RuLawDate(), call.Parameters["dateFrom"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptLawApiCall.Name(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Name_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new DeputyTranscriptLawApiCall().Name(null));
      Assert.Throws<ArgumentException>(() => new DeputyTranscriptLawApiCall().Name(string.Empty));

      var call = new DeputyTranscriptLawApiCall();
      Assert.False(call.Parameters.ContainsKey("name"));
      Assert.True(ReferenceEquals(call, call.Name("name")));
      Assert.Equal("name", call.Parameters["name"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyTranscriptLawApiCall.To(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void To_Method()
    {
      var call = new DeputyTranscriptLawApiCall();
      Assert.False(call.Parameters.ContainsKey("dateTo"));
      Assert.True(ReferenceEquals(call, call.To(DateTime.MinValue)));
      Assert.Equal(DateTime.MinValue.RuLawDate(), call.Parameters["dateTo"]);
    }
  }
}