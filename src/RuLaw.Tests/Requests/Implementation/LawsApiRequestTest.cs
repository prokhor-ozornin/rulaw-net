using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawsApiRequest"/>.</para>
/// </summary>
/// <seealso cref="LawsApiRequest"/>
public sealed class LawsApiRequestTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawsApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawsApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<ILawsApiRequest>();

    using (new AssertionScope())
    {
      var request = new LawsApiRequest();

      request.Parameters.Should().BeEmpty();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(int.MinValue, new LawsApiRequest());
      Test(int.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(int? page, ILawsApiRequest request) => request.Page(page).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["page"].Should().Be(page);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.PageSize(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Enum.GetValues<PageSize>().ForEach(size => Test(size, new LawsApiRequest()));
    }

    return;

    static void Test(PageSize? size, ILawsApiRequest request) => request.PageSize(size).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["limit"].Should().Be((int?) size);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Name(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(string.Empty, new LawsApiRequest());
      Test("keywords", new LawsApiRequest());
    }

    return;

    static void Test(string name, ILawsApiRequest request) => request.Name(name).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["name"].Should().Be(name);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Type(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(int.MinValue, new LawsApiRequest());
      Test(int.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(int? type, ILawsApiRequest request) => request.Type(type).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["law_type"].Should().Be(type);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Topic(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Topic_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(long.MinValue, new LawsApiRequest());
      Test(long.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(long? topic, ILawsApiRequest request) => request.Topic(topic).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["topic"].Should().Be(topic);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Number(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Number_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(string.Empty, new LawsApiRequest());
      Test("number", new LawsApiRequest());
    }

    return;

    static void Test(string number, ILawsApiRequest request) => request.Number(number).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["number"].Should().Be(number);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.DocumentNumber(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DocumentNumber_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(string.Empty, new LawsApiRequest());
      Test("number", new LawsApiRequest());
    }

    return;

    static void Test(string number, ILawsApiRequest request) => request.DocumentNumber(number).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["document_number"].Should().Be(number);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Status(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(int.MinValue, new LawsApiRequest());
      Test(int.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(int? status, ILawsApiRequest request) => request.Status(status).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["status"].Should().Be(status);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Branch(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Branch_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(long.MinValue, new LawsApiRequest());
      Test(long.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(long? branch, ILawsApiRequest request) => request.Branch(branch).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["class"].Should().Be(branch);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.RegistrationStart(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegistrationStart_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(DateTimeOffset.MinValue, new LawsApiRequest());
      Test(DateTimeOffset.MaxValue, new LawsApiRequest());
      Test(DateTimeOffset.Now, new LawsApiRequest());
    }

    return;

    static void Test(DateTimeOffset? date, ILawsApiRequest request) => request.RegistrationStart(date).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["registration_start"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.RegistrationEnd(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegistrationEnd_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(DateTimeOffset.MinValue, new LawsApiRequest());
      Test(DateTimeOffset.MaxValue, new LawsApiRequest());
      Test(DateTimeOffset.Now, new LawsApiRequest());
    }

    return;

    static void Test(DateTimeOffset? date, ILawsApiRequest request) => request.RegistrationEnd(date).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["registration_end"].Should().Be(date?.ToString("yyyy-MM-dd"));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Deputy(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(long.MinValue, new LawsApiRequest());
      Test(long.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(long? deputy, ILawsApiRequest request) => request.Deputy(deputy).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["deputy"].Should().Be(deputy);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.FederalAuthority(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FederalAuthority_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(long.MinValue, new LawsApiRequest());
      Test(long.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(long? authority, ILawsApiRequest request) => request.FederalAuthority(authority).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["federal_subject"].Should().Be(authority);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.RegionalAuthority(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegionalAuthority_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(long.MinValue, new LawsApiRequest());
      Test(long.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(long? authority, ILawsApiRequest request) => request.RegionalAuthority(authority).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["regional_subject"].Should().Be(authority);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.ProfileCommittee(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ProfileCommittee_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(long.MinValue, new LawsApiRequest());
      Test(long.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(long? committee, ILawsApiRequest request) => request.ProfileCommittee(committee).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["profile_committee"].Should().Be(committee);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.ResponsibleCommittee(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ResponsibleCommittee_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(long.MinValue, new LawsApiRequest());
      Test(long.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(long? committee, ILawsApiRequest request) => request.ResponsibleCommittee(committee).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["responsible_committee"].Should().Be(committee);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.SoExecutorCommittee(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void SoExecutorCommittee_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(long.MinValue, new LawsApiRequest());
      Test(long.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(long? committee, ILawsApiRequest request) => request.SoExecutorCommittee(committee).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["soexecutor_committee"].Should().Be(committee);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Sorting(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Sorting_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(string.Empty, new LawsApiRequest());
      Test("sorting", new LawsApiRequest());
    }

    return;

    static void Test(string sorting, ILawsApiRequest request) => request.Sorting(sorting).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["sort"].Should().Be(sorting);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.EventsSearchMode(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void EventsSearchMode_Method()
  {
    using (new AssertionScope())
    {
      Test(null, new LawsApiRequest());
      Test(int.MinValue, new LawsApiRequest());
      Test(int.MaxValue, new LawsApiRequest());
    }

    return;

    static void Test(int? mode, ILawsApiRequest request) => request.EventsSearchMode(mode).Should().BeSameAs(request).And.BeOfType<LawsApiRequest>().Which.Parameters["search_mode"].Should().Be(mode);
  }
}