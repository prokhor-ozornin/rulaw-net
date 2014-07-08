using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ILawsLawApiCallExtensions"/>.</para>
  /// </summary>
  public sealed class ILawsLawApiCallExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.Branch(ILawsLawApiCall, ILawBranch)"/> method.</para>
    /// </summary>
    [Fact]
    public void Branch_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ILawsLawApiCallExtensions.Branch(null, new LawBranch()));
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().Branch(null));

      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.Branch(new LawBranch { Id = 1 }), call));
      Assert.Equal((long) 1, call.Parameters["class"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.Deputy(ILawsLawApiCall, IDeputy)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deputy_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ILawsLawApiCallExtensions.Deputy(null, new Deputy()));
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().Deputy(null));

      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.Deputy(new Deputy { Id = 1 }), call));
      Assert.Equal((long) 1, call.Parameters["deputy"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.FederalAuthority(ILawsLawApiCall, IAuthority)"/> method.</para>
    /// </summary>
    [Fact]
    public void FederalAuthority_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ILawsLawApiCallExtensions.FederalAuthority(null, new FederalAuthority()));
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().FederalAuthority(null));

      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.FederalAuthority(new FederalAuthority { Id = 1 }), call));
      Assert.Equal((long) 1, call.Parameters["federal_subject"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.Type(ILawsLawApiCall, LawTypes)"/> method.</para>
    /// </summary>
    [Fact]
    public void Type_Method()
    {
      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.Type(LawTypes.ConstitutionAmendments), call));
      Assert.Equal(41, call.Parameters["law_type"]);
      Assert.Equal(38, call.Type(LawTypes.Federal).Parameters["law_type"]);
      Assert.Equal(39, call.Type(LawTypes.FederalConstitutional).Parameters["law_type"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.Sorting(ILawsLawApiCall, LawsSorting)"/> method.</para>
    /// </summary>
    [Fact]
    public void Sorting_Method()
    {
      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.Sorting(LawsSorting.DateAscending), call));
      Assert.Equal("date_asc", call.Parameters["sort"]);
      Assert.Equal("date", call.Sorting(LawsSorting.DateDescending).Parameters["sort"]);
      Assert.Equal("last_event_date_asc", call.Sorting(LawsSorting.LastEventDateAscending).Parameters["sort"]);
      Assert.Equal("last_event_date", call.Sorting(LawsSorting.LastEventDateDescending).Parameters["sort"]);
      Assert.Equal("name", call.Sorting(LawsSorting.Name).Parameters["sort"]);
      Assert.Equal("number", call.Sorting(LawsSorting.Number).Parameters["sort"]);
      Assert.Equal("responsible_committee", call.Sorting(LawsSorting.ResponsibleCommittee).Parameters["sort"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.Status(ILawsLawApiCall, LawStatus)"/> method.</para>
    /// </summary>
    [Fact]
    public void Status_Method()
    {
      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.Status(LawStatus.Cancelled), call));
      Assert.Equal(99, call.Parameters["status"]);
      Assert.Equal(3, call.Status(LawStatus.InApproximateProgram).Parameters["status"]);
      Assert.Equal(4, call.Status(LawStatus.InCommitteeProgram).Parameters["status"]);
      Assert.Equal(1, call.Status(LawStatus.Offered).Parameters["status"]);
      Assert.Equal(5, call.Status(LawStatus.OutOfProgram).Parameters["status"]);
      Assert.Equal(8, call.Status(LawStatus.Rejected).Parameters["status"]);
      Assert.Equal(9, call.Status(LawStatus.RejectedOrReturned).Parameters["status"]);
      Assert.Equal(6, call.Status(LawStatus.ReviewFinished).Parameters["status"]);
      Assert.Equal(2, call.Status(LawStatus.ReviewStarted).Parameters["status"]);
      Assert.Equal(7, call.Status(LawStatus.Signed).Parameters["status"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.ProfileCommittee(ILawsLawApiCall, ICommittee)"/> method.</para>
    /// </summary>
    [Fact]
    public void ProfileCommittee_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ILawsLawApiCallExtensions.ProfileCommittee(null, new Committee()));
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().ProfileCommittee(null));

      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.ProfileCommittee(new Committee { Id = 1 }), call));
      Assert.Equal((long) 1, call.Parameters["profile_committee"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.RegionalAuthority(ILawsLawApiCall, IAuthority)"/> method.</para>
    /// </summary>
    [Fact]
    public void RegionalAuthority_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ILawsLawApiCallExtensions.RegionalAuthority(null, new RegionalAuthority()));
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().RegionalAuthority(null));

      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.RegionalAuthority(new RegionalAuthority { Id = 1 }), call));
      Assert.Equal((long) 1, call.Parameters["regional_subject"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.ResponsibleCommittee(ILawsLawApiCall, ICommittee)"/> method.</para>
    /// </summary>
    [Fact]
    public void ResponsibleCommittee_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ILawsLawApiCallExtensions.ResponsibleCommittee(null, new Committee()));
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().ResponsibleCommittee(null));

      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.ResponsibleCommittee(new Committee { Id = 1 }), call));
      Assert.Equal((long) 1, call.Parameters["responsible_committee"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.SoExecutorCommittee(ILawsLawApiCall, ICommittee)"/> method.</para>
    /// </summary>
    [Fact]
    public void SoExecutorCommittee_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ILawsLawApiCallExtensions.SoExecutorCommittee(null, new Committee()));
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().SoExecutorCommittee(null));

      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.SoExecutorCommittee(new Committee { Id = 1 }), call));
      Assert.Equal((long) 1, call.Parameters["soexecutor_committee"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.Topic(ILawsLawApiCall, ITopic)"/> method.</para>
    /// </summary>
    [Fact]
    public void Topic_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ILawsLawApiCallExtensions.Topic(null, new Topic()));
      Assert.Throws<ArgumentNullException>(() => new LawsLawApiCall().Topic(null));

      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.Topic(new Topic { Id = 1 }), call));
      Assert.Equal((long) 1, call.Parameters["topic"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ILawsLawApiCallExtensions.EventsSearchMode(ILawsLawApiCall, LawsEventsSearchMode)"/> method.</para>
    /// </summary>
    [Fact]
    public void EventsSearchMode_Method()
    {
      var call = new LawsLawApiCall();
      Assert.True(ReferenceEquals(call.EventsSearchMode(LawsEventsSearchMode.All), call));
      Assert.Equal(1, call.Parameters["search_mode"]);
      Assert.Equal(3, call.EventsSearchMode(LawsEventsSearchMode.Expected).Parameters["search_mode"]);
      Assert.Equal(2, call.EventsSearchMode(LawsEventsSearchMode.Last).Parameters["search_mode"]);
    }
  }
}