using System;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawsLawApiCall"/>.</para>
  /// </summary>
  public sealed class LawsLawApiCallTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawsLawApiCall()"/>
    [Fact]
    public void Constructors()
    {
      var call = new LawsLawApiCall();
      Assert.Empty(call.Parameters);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.Branch(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void Branch_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("class"));
      Assert.True(ReferenceEquals(call.Branch(1), call));
      Assert.Equal((long) 1, call.Parameters["class"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.Deputy(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deputy_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("deputy"));
      Assert.True(ReferenceEquals(call.Deputy(1), call));
      Assert.Equal((long) 1, call.Parameters["deputy"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.DocumentNumber(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void DocumentNumber_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().DocumentNumber(null));
      Assert.Throws<ArgumentException>(() => new LawsLawApiCall().DocumentNumber(string.Empty));

      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("document_number"));
      Assert.True(ReferenceEquals(call.DocumentNumber("documentNumber"), call));
      Assert.Equal("documentNumber", call.Parameters["document_number"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.FederalAuthority(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void FederalAuthority_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("federal_subject"));
      Assert.True(ReferenceEquals(call.FederalAuthority(1), call));
      Assert.Equal((long) 1, call.Parameters["federal_subject"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.Type(int)"/> method.</para>
    /// </summary>
    [Fact]
    public void Type_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("law_type"));
      Assert.True(ReferenceEquals(call.Type(1), call));
      Assert.Equal(1, call.Parameters["law_type"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.Sorting(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Sorting_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().Sorting(null));
      Assert.Throws<ArgumentException>(() => new LawsLawApiCall().Sorting(string.Empty));

      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("sort"));
      Assert.True(ReferenceEquals(call.Sorting("sorting"), call));
      Assert.Equal("sorting", call.Parameters["sort"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.Status(int)"/> method.</para>
    /// </summary>
    [Fact]
    public void Status_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("status"));
      Assert.True(ReferenceEquals(call.Status(1), call));
      Assert.Equal(1, call.Parameters["status"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.Name(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Name_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().Name(null));
      Assert.Throws<ArgumentException>(() => new LawsLawApiCall().Name(string.Empty));

      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("name"));
      Assert.True(ReferenceEquals(call.Name("name"), call));
      Assert.Equal("name", call.Parameters["name"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.Number(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Number_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().Number(null));
      Assert.Throws<ArgumentException>(() => new LawsLawApiCall().Number(string.Empty));

      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("number"));
      Assert.True(ReferenceEquals(call.Number("number"), call));
      Assert.Equal("number", call.Parameters["number"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.Page(int)"/> method.</para>
    /// </summary>
    [Fact]
    public void Page_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("page"));
      Assert.True(ReferenceEquals(call.Page(1), call));
      Assert.Equal(1, call.Parameters["page"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.PageSize(PageSize)"/> method.</para>
    /// </summary>
    [Fact]
    public void PageSize_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("limit"));
      Assert.True(ReferenceEquals(call.PageSize(PageSize.Five), call));
      Assert.Equal(5, call.Parameters["limit"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.ProfileCommittee(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void ProfileCommittee_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("profile_committee"));
      Assert.True(ReferenceEquals(call.ProfileCommittee(1), call));
      Assert.Equal((long) 1, call.Parameters["profile_committee"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.RegionalAuthority(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void RegionalAuthority_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("regional_subject"));
      Assert.True(ReferenceEquals(call.RegionalAuthority(1), call));
      Assert.Equal((long)1, call.Parameters["regional_subject"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.RegistrationEnd(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void RegistrationEnd_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("registration_end"));
      var date = DateTime.UtcNow;
      Assert.True(ReferenceEquals(call.RegistrationEnd(date), call));
      Assert.Equal(date.RuLawDate(), call.Parameters["registration_end"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.RegistrationStart(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void RegistrationStart_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("registration_start"));
      var date = DateTime.UtcNow;
      Assert.True(ReferenceEquals(call.RegistrationStart(date), call));
      Assert.Equal(date.RuLawDate(), call.Parameters["registration_start"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.ResponsibleCommittee(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void ResponsibleCommittee_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("responsible_committee"));
      Assert.True(ReferenceEquals(call.ResponsibleCommittee(1), call));
      Assert.Equal((long) 1, call.Parameters["responsible_committee"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.SoExecutorCommittee(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void SoExecutorCommittee_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("soexecutor_committee"));
      Assert.True(ReferenceEquals(call.SoExecutorCommittee(1), call));
      Assert.Equal((long) 1, call.Parameters["soexecutor_committee"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.EventsSearchMode(int)"/> method.</para>
    /// </summary>
    [Fact]
    public void EventsSearchMode_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("search_mode"));
      Assert.True(ReferenceEquals(call.EventsSearchMode(1), call));
      Assert.Equal(1, call.Parameters["search_mode"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsLawApiCall.Topic(long)"/> method.</para>
    /// </summary>
    [Fact]
    public void Topic_Method()
    {
      var call = new LawsLawApiCall();
      Assert.False(call.Parameters.ContainsKey("topic"));
      Assert.True(ReferenceEquals(call.Topic(1), call));
      Assert.Equal((long) 1, call.Parameters["topic"]);
    }
  }
}