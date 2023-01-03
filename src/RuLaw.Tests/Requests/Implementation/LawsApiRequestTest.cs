using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawsApiRequest"/>.</para>
/// </summary>
public sealed class LawsApiRequestTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawsApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    var request = new LawsApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Page(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Page_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Page(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["page"].Should().BeNull();

    request.Page(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["page"].Should().Be(1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.PageSize(PageSize?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PageSize_Method()
  {
    static void Validate(PageSize? size)
    {
      var request = new LawsApiRequest();

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
  ///   <para>Performs testing of <see cref="LawsApiRequest.Name(string?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Name(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["name"].Should().BeNull();

    request.Name("name").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["name"].Should().Be("name");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Type(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Type(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["law_type"].Should().BeNull();

    request.Type(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["law_type"].Should().Be(1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Topic(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Topic_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Topic(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["topic"].Should().BeNull();

    request.Topic(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["topic"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Number(string?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Number_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Number(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["number"].Should().BeNull();

    request.Number("number").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["number"].Should().Be("number");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.DocumentNumber(string?)"/> method.</para>
  /// </summary>
  [Fact]
  public void DocumentNumber_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.DocumentNumber(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["document_number"].Should().BeNull();

    request.DocumentNumber("documentNumber").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["document_number"].Should().Be("documentNumber");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Status(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Status(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["status"].Should().BeNull();

    request.Status(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["status"].Should().Be(1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Branch(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Branch_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Branch(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["class"].Should().BeNull();

    request.Branch(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["class"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.RegistrationStart(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegistrationStart_Method()
  {
    static void Validate(DateTimeOffset? date)
    {
      var request = new LawsApiRequest();

      request.Parameters.Should().BeEmpty();

      request.RegistrationStart(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["registration_start"].Should().Be(date?.AsString());
    }

    using (new AssertionScope())
    {
      Validate(null);
      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow}.ForEach(date => Validate(date));
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.RegistrationEnd(DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegistrationEnd_Method()
  {
    static void Validate(DateTimeOffset? date)
    {
      var request = new LawsApiRequest();

      request.Parameters.Should().BeEmpty();

      request.RegistrationStart(date).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["registration_end"].Should().Be(date?.AsString());
    }

    using (new AssertionScope())
    {
      Validate(null);
      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(date => Validate(date));
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Deputy(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Deputy(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().BeNull();

    request.Deputy(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.FederalAuthority(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void FederalAuthority_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.FederalAuthority(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["federal_subject"].Should().BeNull();

    request.FederalAuthority(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["federal_subject"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.RegionalAuthority(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegionalAuthority_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.RegionalAuthority(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["regional_subject"].Should().BeNull();

    request.RegionalAuthority(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["regional_subject"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.ProfileCommittee(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ProfileCommittee_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.ProfileCommittee(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["profile_committee"].Should().BeNull();

    request.ProfileCommittee(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["profile_committee"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.ResponsibleCommittee(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ResponsibleCommittee_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.ResponsibleCommittee(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["responsible_committee"].Should().BeNull();

    request.ResponsibleCommittee(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["responsible_committee"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.SoExecutorCommittee(long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void SoExecutorCommittee_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.SoExecutorCommittee(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["soexecutor_committee"].Should().BeNull();

    request.SoExecutorCommittee(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["soexecutor_committee"].Should().Be(1L);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.Sorting(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Sorting_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Sorting(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().BeNull();

    request.Sorting("sorting").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["sort"].Should().Be("sorting");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawsApiRequest.EventsSearchMode(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void EventsSearchMode_Method()
  {
    var request = new LawsApiRequest();

    request.Parameters.Should().BeEmpty();

    request.EventsSearchMode(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["search_mode"].Should().BeNull();

    request.EventsSearchMode(1).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["search_mode"].Should().Be(1);
  }
}