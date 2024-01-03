using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ILawsApiRequestExtensions"/>.</para>
/// </summary>
public sealed class ILawsApiRequestExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Type(ILawsApiRequest, LawTypes?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Method()
  {
    using (new AssertionScope())
    {
      Validate(null);
      Enum.GetValues<LawTypes>().ForEach(type => Validate(type));
    }

    return;

    static void Validate(LawTypes? type)
    {
      var request = new LawsApiRequest();

      request.Parameters.Should().BeEmpty();

      request.Type(type).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["law_type"].Should().Be((int?) type);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Topic(ILawsApiRequest, ITopic)"/> method.</para>
  /// </summary>
  [Fact]
  public void Topic_Method()
  {
    AssertionExtensions.Should(() => ILawsApiRequestExtensions.Topic(null, new Topic())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

    var request = new LawsApiRequest();
    
    request.Parameters.Should().BeEmpty();

    request.Topic((ITopic) null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["topic"].Should().BeNull();

    request.Topic(new Topic(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["topic"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Status(ILawsApiRequest, LawStatus?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    using (new AssertionScope())
    {
      Validate(null);
      Enum.GetValues<LawStatus>().ForEach(type => Validate(type));
    }

    return;

    static void Validate(LawStatus? status)
    {
      var request = new LawsApiRequest();

      request.Parameters.Should().BeEmpty();

      request.Status(status).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["status"].Should().Be((int?) status);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Branch(ILawsApiRequest, ILawBranch)"/> method.</para>
  /// </summary>
  [Fact]
  public void Branch_Method()
  {
    AssertionExtensions.Should(() => ILawsApiRequestExtensions.Branch(null, new LawBranch())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Branch((ILawBranch) null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["class"].Should().BeNull();

    request.Branch(new LawBranch(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["class"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Deputy(ILawsApiRequest, IDeputy)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    AssertionExtensions.Should(() => ILawsApiRequestExtensions.Deputy(null, new Deputy())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Deputy((IDeputy) null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().BeNull();

    request.Deputy(new Deputy(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.FederalAuthority(ILawsApiRequest, IAuthority)"/> method.</para>
  /// </summary>
  [Fact]
  public void FederalAuthority_Method()
  {
    AssertionExtensions.Should(() => ILawsApiRequestExtensions.FederalAuthority(null, new FederalAuthority())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.FederalAuthority((IAuthority) null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["federal_subject"].Should().BeNull();

    request.FederalAuthority(new FederalAuthority(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["federal_subject"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.RegionalAuthority(ILawsApiRequest, IAuthority)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegionalAuthority_Method()
  {
    AssertionExtensions.Should(() => ILawsApiRequestExtensions.RegionalAuthority(null, new RegionalAuthority(new {}))).ThrowExactly<ArgumentNullException>().WithParameterName("request");

    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.RegionalAuthority((IAuthority) null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["regional_subject"].Should().BeNull();

    request.RegionalAuthority(new RegionalAuthority(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["regional_subject"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.ProfileCommittee(ILawsApiRequest, ICommittee)"/> method.</para>
  /// </summary>
  [Fact]
  public void ProfileCommittee_Method()
  {
    AssertionExtensions.Should(() => ILawsApiRequestExtensions.ProfileCommittee(null, new Committee(new {}))).ThrowExactly<ArgumentNullException>().WithParameterName("request");

    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.ProfileCommittee((ICommittee) null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["profile_committee"].Should().BeNull();

    request.ProfileCommittee(new Committee(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["profile_committee"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.ResponsibleCommittee(ILawsApiRequest, ICommittee)"/> method.</para>
  /// </summary>
  [Fact]
  public void ResponsibleCommittee_Method()
  {
    AssertionExtensions.Should(() => ILawsApiRequestExtensions.ResponsibleCommittee(null, new Committee(new {}))).ThrowExactly<ArgumentNullException>().WithParameterName("request");

    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.ResponsibleCommittee((ICommittee) null).Should().NotBeNull().And.NotBeNull().And.BeSameAs(request);
    request.Parameters["responsible_committee"].Should().BeNull();

    request.ResponsibleCommittee(new Committee(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["responsible_committee"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.SoExecutorCommittee(ILawsApiRequest, ICommittee)"/> method.</para>
  /// </summary>
  [Fact]
  public void SoExecutorCommittee_Method()
  {
    AssertionExtensions.Should(() => ILawsApiRequestExtensions.SoExecutorCommittee(null, new Committee(new {}))).ThrowExactly<ArgumentNullException>().WithParameterName("request");

    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.SoExecutorCommittee((ICommittee) null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["soexecutor_committee"].Should().BeNull();

    request.SoExecutorCommittee(new Committee(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["soexecutor_committee"].Should().Be(1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Sorting(ILawsApiRequest, LawsSorting?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Sorting_Method()
  {
    var request = new LawsApiRequest();

    request.Sorting(LawsSorting.DateAscending).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("date_asc");

    request.Sorting(LawsSorting.DateDescending).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("date");

    request.Sorting(LawsSorting.LastEventDateAscending).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("last_event_date_asc");

    request.Sorting(LawsSorting.LastEventDateDescending).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("last_event_date");

    request.Sorting(LawsSorting.Name).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("name");

    request.Sorting(LawsSorting.Number).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("number");

    request.Sorting(LawsSorting.ResponsibleCommittee).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("responsible_committee");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.EventsSearchMode(ILawsApiRequest, LawsEventsSearchMode?)"/> method.</para>
  /// </summary>
  [Fact]
  public void EventsSearchMode_Method()
  {
    using (new AssertionScope())
    {
      Validate(null);
      Enum.GetValues<LawsEventsSearchMode>().ForEach(mode => Validate(mode));
    }

    return;

    static void Validate(LawsEventsSearchMode? mode)
    {
      var request = new LawsApiRequest();

      request.Parameters.Should().BeEmpty();

      request.EventsSearchMode(LawsEventsSearchMode.All).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["search_mode"].Should().Be((int?) mode);
    }
  }
}