using System.Configuration;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="ILawsApiExtensions"/>.</para>
/// </summary>
public sealed class ILawsApiExtensionsTest : UnitTest
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ILawsApiExtensions.Search(ILawsApi, ILawsApiRequest)"/></description></item>
  ///     <item><description><see cref="ILawsApiExtensions.Search(ILawsApi, Action{ILawsApiRequest})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Search_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiExtensions.Search(null, new LawsApiRequest())).ThrowExactly<ArgumentNullException>().WithParameterName("api");
      AssertionExtensions.Should(() => Api.Laws.Search((ILawsApiRequest) null)).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      var result = Api.Laws.Search(new LawsApiRequest().Name("курение").Sorting(LawsSorting.DateDescending));
      Validate(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiExtensions.Search(null, _ => {})).ThrowExactly<ArgumentNullException>().WithParameterName("api");
      AssertionExtensions.Should(() => Api.Laws.Search((Action<ILawsApiRequest>) null)).ThrowExactly<ArgumentNullException>().WithParameterName("action");

      var result = Api.Laws.Search(request => request.Name("курение").Sorting(LawsSorting.DateDescending));
      Validate(result);
    }

    return;

    static void Validate(ILawsSearchResult result)
    {
      result.Should().NotBeNull().And.BeOfType<LawsSearchResult>();

      result.Count.Should().BePositive();
      result.Page.Should().Be(1);
      result.Wording.Should().Contain("Законопроекты, где наименование или комментарий содержит \"курение\", отсортированные по дате внесения в ГД (по убыванию)");

      var laws = result.Laws;
      laws.Should().NotBeNullOrEmpty().And.BeOfType<List<Law>>();

      var law = laws.Number("170826-6");

      law.Comments.Should().BeNull();

      law.Committees.Should().NotBeNull().And.BeOfType<LawCommittees>();
      law.Committees.Profile.Should().NotBeNullOrEmpty().And.BeOfType<List<Committee>>();

      var committee = law.Committees.Profile.Single();
      committee.Active.Should().BeTrue();
      committee.FromDate.Should().HaveYear(2003).And.HaveMonth(12).And.HaveDay(29).And.HaveOffset(TimeSpan.Zero);
      committee.ToDate.Should().BeNull();
      law.Committees.Responsible.Should().BeNull().And.BeOfType<Committee>();
      law.Committees.SoExecutor.Should().NotBeNull().And.BeEmpty();

      law.Date.Should().HaveYear(2012).And.HaveMonth(11).And.HaveDay(13).And.HaveOffset(TimeSpan.Zero);

      law.Id.Should().Be(19135);

      law.LastEvent.Should().NotBeNull().And.BeOfType<LawEvent>();

      law.LastEvent.Date.Should().HaveYear(2012).And.HaveMonth(12).And.HaveDay(20).And.HaveOffset(TimeSpan.Zero);

      law.LastEvent.Document.Name.Should().Be("68");
      law.LastEvent.Document.Type.Should().Be("Протокол заседания Совета ГД");
      law.LastEvent.Document.Should().NotBeNull().And.BeOfType<LawEventDocument>();

      law.LastEvent.Phase.Id.Should().Be(5);
      law.LastEvent.Phase.Name.Should().Be("Рассмотрение Советом Государственной Думы законопроекта, внесенного в Государственную Думу");
      law.LastEvent.Phase.Should().NotBeNull().And.BeOfType<LawEventPhase>();

      law.LastEvent.Solution.Should().Be("снять законопроект с рассмотрения Государственной Думы в связи с отзывом субъектом права законодательной инициативы");

      law.LastEvent.Stage.Should().NotBeNull().And.BeOfType<LawEventStage>();
      law.LastEvent.Stage.Id.Should().Be(2);
      law.LastEvent.Stage.Name.Should().Be("Предварительное рассмотрение законопроекта, внесенного в Государственную Думу");

      law.Name.Should().Be("Об ограничении курения табака в целях охраны здоровья населения");

      law.Number.Should().Be("170826-6");

      law.Subject.Should().NotBeNull().And.BeOfType<LawSubject>();
      law.Subject.Departments.Should().NotBeNull().And.BeEmpty();

      law.Subject.Deputies.Should().NotBeNullOrEmpty().And.BeOfType<List<Deputy>>();
      var deputy = law.Subject.Deputies.Single();
      deputy.Id.Should().Be(99100270);
      deputy.Position().Should().Be(DeputyPosition.DumaDeputy);
      deputy.Name.Should().Be("Митрофанов Алексей Валентинович");

      law.TranscriptUrl.Should().BeNull();

      law.Type.Should().NotBeNull().And.BeOfType<LawType>();
      law.Type.Id.Should().Be((int) LawTypes.Federal);
      law.Type.Name.Should().Be("Федеральный закон");

      law.Url.Should().Be("http://sozd.parlament.gov.ru/bill/170826-6");
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApiExtensions.SearchAsync(ILawsApi, Action{ILawsApiRequest}, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void SearchAsync_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiExtensions.SearchAsync(null, _ => { })).ThrowExactlyAsync<ArgumentNullException>().WithParameterName("api").Await();
      AssertionExtensions.Should(() => ILawsApiExtensions.SearchAsync(Api.Laws, null)).ThrowExactlyAsync<ArgumentNullException>().WithParameterName("action").Await();
      AssertionExtensions.Should(() => Api.Laws.SearchAsync(_ => { }, Cancellation)).ThrowExactlyAsync<OperationCanceledException>().Await();

      var result = Api.Laws.SearchAsync(request => request.Name("курение").Sorting(LawsSorting.DateDescending)).Await();
      Validate(result);
    }

    return;

    static void Validate(ILawsSearchResult result)
    {
      result.Should().NotBeNull().And.BeOfType<LawsSearchResult>();

      result.Count.Should().BePositive();
      result.Page.Should().Be(1);
      result.Wording.Should().Contain("Законопроекты, где наименование или комментарий содержит \"курение\", отсортированные по дате внесения в ГД (по убыванию)");

      var laws = result.Laws;
      laws.Should().NotBeNullOrEmpty().And.BeOfType<List<Law>>();

      var law = laws.Number("170826-6");

      law.Comments.Should().BeNull();

      law.Committees.Should().NotBeNull().And.BeOfType<LawCommittees>();
      law.Committees.Profile.Should().NotBeNullOrEmpty().And.BeOfType<List<Committee>>();

      var committee = law.Committees.Profile.Single();
      committee.Active.Should().BeTrue();
      committee.FromDate.Should().HaveYear(2003).And.HaveMonth(12).And.HaveDay(29).And.HaveOffset(TimeSpan.Zero);
      committee.ToDate.Should().BeNull();
      law.Committees.Responsible.Should().BeNull().And.BeOfType<Committee>();
      law.Committees.SoExecutor.Should().NotBeNull().And.BeEmpty();

      law.Date.Should().HaveYear(2012).And.HaveMonth(11).And.HaveDay(13).And.HaveOffset(TimeSpan.Zero);

      law.Id.Should().Be(19135);

      law.LastEvent.Should().NotBeNull().And.BeOfType<LawEvent>();

      law.LastEvent.Date.Should().HaveYear(2012).And.HaveMonth(12).And.HaveDay(20).And.HaveOffset(TimeSpan.Zero);

      law.LastEvent.Document.Name.Should().Be("68");
      law.LastEvent.Document.Type.Should().Be("Протокол заседания Совета ГД");
      law.LastEvent.Document.Should().NotBeNull().And.BeOfType<LawEventDocument>();

      law.LastEvent.Phase.Id.Should().Be(5);
      law.LastEvent.Phase.Name.Should().Be("Рассмотрение Советом Государственной Думы законопроекта, внесенного в Государственную Думу");
      law.LastEvent.Phase.Should().NotBeNull().And.BeOfType<LawEventPhase>();

      law.LastEvent.Solution.Should().Be("снять законопроект с рассмотрения Государственной Думы в связи с отзывом субъектом права законодательной инициативы");

      law.LastEvent.Stage.Should().NotBeNull().And.BeOfType<LawEventStage>();
      law.LastEvent.Stage.Id.Should().Be(2);
      law.LastEvent.Stage.Name.Should().Be("Предварительное рассмотрение законопроекта, внесенного в Государственную Думу");

      law.Name.Should().Be("Об ограничении курения табака в целях охраны здоровья населения");

      law.Number.Should().Be("170826-6");

      law.Subject.Should().NotBeNull().And.BeOfType<LawSubject>();
      law.Subject.Departments.Should().NotBeNull().And.BeEmpty();

      law.Subject.Deputies.Should().NotBeNullOrEmpty().And.BeOfType<List<Deputy>>();
      var deputy = law.Subject.Deputies.Single();
      deputy.Id.Should().Be(99100270);
      deputy.Position().Should().Be(DeputyPosition.DumaDeputy);
      deputy.Name.Should().Be("Митрофанов Алексей Валентинович");

      law.TranscriptUrl.Should().BeNull();

      law.Type.Should().NotBeNull().And.BeOfType<LawType>();
      law.Type.Id.Should().Be((int) LawTypes.Federal);
      law.Type.Name.Should().Be("Федеральный закон");

      law.Url.Should().Be("http://sozd.parlament.gov.ru/bill/170826-6");
    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    Api.Dispose();
  }
}