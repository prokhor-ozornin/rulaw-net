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
      Validate(null, new LawsApiRequest());
      Enum.GetValues<LawTypes>().ForEach(type => Validate(type, new LawsApiRequest()));
    }

    return;

    static void Validate(LawTypes? type, ILawsApiRequest request) => request.Type(type).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["law_type"].Should().Be((int?) type);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Topic(ILawsApiRequest, ITopic)"/> method.</para>
  /// </summary>
  [Fact]
  public void Topic_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiRequestExtensions.Topic(null, new Topic())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new LawsApiRequest());
      Validate(new Topic { Id = long.MinValue }, new LawsApiRequest());
      Validate(new Topic { Id = long.MaxValue }, new LawsApiRequest());
    }

    return;

    static void Validate(ITopic topic, ILawsApiRequest request) => request.Topic(topic).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["topic"].Should().Be(topic?.Id);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Status(ILawsApiRequest, LawStatus?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new LawsApiRequest());
      Enum.GetValues<LawStatus>().ForEach(status => Validate(status, new LawsApiRequest()));
    }

    return;

    static void Validate(LawStatus? status, ILawsApiRequest request) => request.Status(status).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["status"].Should().Be((int?) status);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Branch(ILawsApiRequest, ILawBranch)"/> method.</para>
  /// </summary>
  [Fact]
  public void Branch_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiRequestExtensions.Branch(null, new LawBranch())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new LawsApiRequest());
      Validate(new LawBranch { Id = long.MinValue }, new LawsApiRequest());
      Validate(new LawBranch { Id = long.MaxValue }, new LawsApiRequest());
    }

    return;

    static void Validate(ILawBranch branch, ILawsApiRequest request) => request.Branch(branch).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["class"].Should().Be(branch?.Id);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Deputy(ILawsApiRequest, IDeputy)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiRequestExtensions.Deputy(null, new Deputy())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new LawsApiRequest());
      Validate(new Deputy { Id = long.MinValue }, new LawsApiRequest());
      Validate(new Deputy { Id = long.MaxValue }, new LawsApiRequest());
    }

    return;

    static void Validate(IDeputy deputy, ILawsApiRequest request) => request.Deputy(deputy).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["deputy"].Should().Be(deputy?.Id);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.FederalAuthority(ILawsApiRequest, IAuthority)"/> method.</para>
  /// </summary>
  [Fact]
  public void FederalAuthority_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiRequestExtensions.FederalAuthority(null, new FederalAuthority())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new LawsApiRequest());
      Validate(new FederalAuthority { Id = long.MinValue }, new LawsApiRequest());
      Validate(new FederalAuthority { Id = long.MaxValue }, new LawsApiRequest());
    }

    return;

    static void Validate(IAuthority authority, ILawsApiRequest request) => request.FederalAuthority(authority).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["federal_subject"].Should().Be(authority?.Id);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.RegionalAuthority(ILawsApiRequest, IAuthority)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegionalAuthority_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiRequestExtensions.RegionalAuthority(null, new RegionalAuthority())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new LawsApiRequest());
      Validate(new RegionalAuthority { Id = long.MinValue }, new LawsApiRequest());
      Validate(new RegionalAuthority { Id = long.MaxValue }, new LawsApiRequest());
    }

    return;

    static void Validate(IAuthority authority, ILawsApiRequest request) => request.RegionalAuthority(authority).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["regional_subject"].Should().Be(authority?.Id);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.ProfileCommittee(ILawsApiRequest, ICommittee)"/> method.</para>
  /// </summary>
  [Fact]
  public void ProfileCommittee_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiRequestExtensions.ProfileCommittee(null, new Committee())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new LawsApiRequest());
      Validate(new Committee { Id = long.MinValue }, new LawsApiRequest());
      Validate(new Committee { Id = long.MaxValue }, new LawsApiRequest());
    }

    return;

    static void Validate(ICommittee committee, ILawsApiRequest request) => request.ProfileCommittee(committee).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["profile_committee"].Should().Be(committee?.Id);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.ResponsibleCommittee(ILawsApiRequest, ICommittee)"/> method.</para>
  /// </summary>
  [Fact]
  public void ResponsibleCommittee_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiRequestExtensions.ResponsibleCommittee(null, new Committee())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new LawsApiRequest());
      Validate(new Committee { Id = long.MinValue }, new LawsApiRequest());
      Validate(new Committee { Id = long.MaxValue }, new LawsApiRequest());
    }

    return;

    static void Validate(ICommittee committee, ILawsApiRequest request) => request.ResponsibleCommittee(committee).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["responsible_committee"].Should().Be(committee?.Id);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.SoExecutorCommittee(ILawsApiRequest, ICommittee)"/> method.</para>
  /// </summary>
  [Fact]
  public void SoExecutorCommittee_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiRequestExtensions.SoExecutorCommittee(null, new Committee())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new LawsApiRequest());
      Validate(new Committee { Id = long.MinValue }, new LawsApiRequest());
      Validate(new Committee { Id = long.MaxValue }, new LawsApiRequest());
    }

    return;

    static void Validate(ICommittee committee, ILawsApiRequest request) => request.SoExecutorCommittee(committee).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["soexecutor_committee"].Should().Be(committee?.Id);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.Sorting(ILawsApiRequest, LawsSorting?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Sorting_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, null, new LawsApiRequest());
      Validate("date_asc", LawsSorting.DateAscending, new LawsApiRequest());
      Validate("date", LawsSorting.DateDescending, new LawsApiRequest());
      Validate("last_event_date_asc", LawsSorting.LastEventDateAscending, new LawsApiRequest());
      Validate("last_event_date", LawsSorting.LastEventDateDescending, new LawsApiRequest());
      Validate("name", LawsSorting.Name, new LawsApiRequest());
      Validate("number", LawsSorting.Number, new LawsApiRequest());
      Validate("responsible_committee", LawsSorting.ResponsibleCommittee, new LawsApiRequest());
    }

    return;

    static void Validate(string result, LawsSorting? sorting, ILawsApiRequest request) => request.Sorting(sorting).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["sort"].Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiRequestExtensions.EventsSearchMode(ILawsApiRequest, LawsEventsSearchMode?)"/> method.</para>
  /// </summary>
  [Fact]
  public void EventsSearchMode_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new LawsApiRequest());
      Enum.GetValues<LawsEventsSearchMode>().ForEach(mode => Validate(mode, new LawsApiRequest()));
    }

    return;

    static void Validate(LawsEventsSearchMode? mode, ILawsApiRequest request) => request.EventsSearchMode(mode).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["search_mode"].Should().Be((int?) mode);
  }
}