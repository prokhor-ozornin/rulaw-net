using System;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="QuestionsLawApiCall"/>.</para>
  /// </summary>
  public sealed class QuestionsLawApiCallTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="QuestionsLawApiCall()"/>
    [Fact]
    public void Constructors()
    {
      var call = new QuestionsLawApiCall();
      Assert.False(call.Parameters.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionsLawApiCall.Page(int)"/> method.</para>
    /// </summary>
    [Fact]
    public void Page_Method()
    {
      var call = new QuestionsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("page"));
      Assert.True(ReferenceEquals(call.Page(1), call));
      Assert.Equal(1, call.Parameters["page"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionsLawApiCall.PageSize(PageSize)"/> method.</para>
    /// </summary>
    [Fact]
    public void PageSize_Method()
    {
      var call = new QuestionsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("limit"));
      Assert.True(ReferenceEquals(call.PageSize(PageSize.Five), call));
      Assert.Equal(5, call.Parameters["limit"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionsLawApiCall.From(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void From_Method()
    {
      var call = new QuestionsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("dateFrom"));
      var date = DateTime.UtcNow;
      Assert.True(ReferenceEquals(call.From(date), call));
      Assert.Equal(date.RuLawDate(), call.Parameters["dateFrom"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionsLawApiCall.Name(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Name_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new QuestionsLawApiCall().Name(null));
      Assert.Throws<ArgumentException>(() => new QuestionsLawApiCall().Name(string.Empty));

      var call = new QuestionsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("name"));
      Assert.True(ReferenceEquals(call.Name("name"), call));
      Assert.Equal("name", call.Parameters["name"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionsLawApiCall.To(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void To_Method()
    {
      var call = new QuestionsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("dateTo"));
      var date = DateTime.UtcNow;
      Assert.True(ReferenceEquals(call.To(date), call));
      Assert.Equal(date.RuLawDate(), call.Parameters["dateTo"]);
    }
  }
}