using System.Configuration;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="ILawsApiExtensions"/>.</para>
/// </summary>
public sealed class ILawsApiExtensionsTest : IDisposable
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  private CancellationToken Cancellation { get; } = new(true);

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ILawsApiExtensions.Search(ILawsApi, Action{ILawsApiRequest}, CancellationToken)"/></description></item>
  ///     <item><description><see cref="ILawsApiExtensions.Search(ILawsApi, out ILawsSearchResult?, Action{ILawsApiRequest}, CancellationToken)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Search_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiExtensions.Search(null!, _ => {})).ThrowExactlyAsync<ArgumentNullException>().Await();
      AssertionExtensions.Should(() => ILawsApiExtensions.Search(Api.Laws, null!)).ThrowExactlyAsync<ArgumentNullException>().Await();
      AssertionExtensions.Should(() => Api.Laws.Search(_ => { }, Cancellation)).ThrowExactlyAsync<TaskCanceledException>().Await();
      AssertionExtensions.Should(() => ILawsApiExtensions.Search(Api.Laws, null!, Cancellation)).ThrowExactlyAsync<TaskCanceledException>().Await();


    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ILawsApiExtensions.Search(null!, out _, _ => { })).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => ILawsApiExtensions.Search(null!, out _, _ => { }, Cancellation)).ThrowExactly<TaskCanceledException>();

      AssertionExtensions.Should(() => Api.Laws.Search(out _, null!)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Laws.Search(out _, null!, Cancellation)).ThrowExactly<TaskCanceledException>();

      Api.Laws.Search(out var result, request => request.Name("курение").Sorting(LawsSorting.DateDescending)).Should().BeTrue();

      result.Should().NotBeNull().And.BeOfType<LawsSearchResult>();

      result!.Count.Should().BePositive();
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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public void Dispose()
  {
    Api.Dispose();
  }
}