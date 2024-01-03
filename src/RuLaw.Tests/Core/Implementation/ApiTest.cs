using Catharsis.Extensions;
using RestSharp;
using FluentAssertions;
using Xunit;
using System.Configuration;
using Catharsis.Commons;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Api"/>.</para>
/// </summary>
public sealed class ApiTest : UnitTest
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="RuLaw.Api()"/>
  [Fact]
  public void Constructors()
  {
    var api = new Api("{apiToken}", "{appToken}");

    using (api)
    {
      api.GetFieldValue<string>("apiToken").Should().Be("{apiToken}");
      api.GetFieldValue<string>("appToken").Should().Be("{appToken}");

      var client = api.GetFieldValue< RestClient>("restClient");
      //client.BaseUrl.ToString().Should().Be("http://api.duma.gov.ru/api");
      var token = client.DefaultParameters.FirstOrDefault(parameter => parameter.Name == "app_token");
      token.Should().NotBeNull();
      token.Value.Should().Be("appToken");

      api.Branches.Should().NotBeNull().And.BeSameAs(api.Branches);
      api.Committees.Should().NotBeNull().And.BeSameAs(api.Committees);
      api.Deputies.Should().NotBeNull().And.BeSameAs(api.Deputies);
      api.Authorities.Should().NotBeNull().And.BeSameAs(api.Authorities);
      api.Instances.Should().NotBeNull().And.BeSameAs(api.Instances);
      api.Laws.Should().NotBeNull().And.BeSameAs(api.Laws);
      api.Convocations.Should().NotBeNull().And.BeSameAs(api.Convocations);
      api.Questions.Should().NotBeNull().And.BeSameAs(api.Questions);
      api.Requests.Should().NotBeNull().And.BeSameAs(api.Requests);
      api.Stages.Should().NotBeNull().And.BeSameAs(api.Stages);
      api.Topics.Should().NotBeNull().And.BeSameAs(api.Topics);
      api.Transcripts.Should().NotBeNull().And.BeSameAs(api.Transcripts);
      api.Votes.Should().NotBeNull().And.BeSameAs(api.Votes);
    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IBranchesApi.AllAsync(CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void BranchesApi_AllAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Branches.AllAsync(Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>();

    var branches = Api.Branches.AllAsync().ToListAsync().Await();
    branches.Should().NotBeNullOrEmpty().And.BeOfType<List<LawBranch>>();
      
    var branch = branches.Single(branch => branch.Id == 68252);
    branch.Name.Should().Be("Безопасность и охрана правопорядка");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICommitteesApi.AllAsync(CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void CommitteesApi_AllAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Committees.AllAsync(Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>().Await();

    var committees = Api.Committees.AllAsync().ToListAsync().Await();
    
    committees.Should().NotBeNullOrEmpty().And.BeOfType<List<Committee>>();
    
    var committee = committees.Single(committee => committee.Id == 6274200);
    committee.Name.Should().Be("Комитет ГД по аграрным вопросам");
    committee.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputiesApi.FindAsync(long, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void DeputiesApi_FindAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Deputies.FindAsync(0, Cancellation)).ThrowExactlyAsync<OperationCanceledException>().Await();

    var deputy = Api.Deputies.FindAsync(99100142).Await();
    
    deputy.Should().NotBeNull().And.BeOfType<Deputy>();

    deputy.LastName.Should().Be("Жириновский");
    deputy.FirstName.Should().Be("Владимир");
    deputy.MiddleName.Should().Be("Вольфович");
    deputy.BirthDate.Should().HaveYear(1946).And.HaveMonth(4).And.HaveDay(25).And.HaveOffset(TimeSpan.Zero);
    deputy.WorkStartDate.Should().HaveYear(2016).And.HaveMonth(9).And.HaveDay(18).And.HaveOffset(TimeSpan.Zero);
    deputy.FactionId.Should().Be(72100005);
    deputy.FactionName.Should().Be("Фракция Политической партии ЛДПР - Либерально-демократической партии России");
    deputy.FactionRole.Trim().Should().Be("00020 Руководитель фракции");
    deputy.Active.Should().BeFalse();
    deputy.FactionRegion.Should().Be("(Общефедеральная часть федерального списка кандидатов).");
    deputy.LawsCount.Should().BePositive();
    deputy.Regions.Should().NotBeNullOrEmpty().And.Contain("все субъекты Российской Федерации");
    deputy.SpeechesCount.Should().BePositive();
    deputy.VoteLink.Should().Be("http://vote.duma.gov.ru/?convocation=AAAAAAA7&deputy=99100142&sort=date_desc");
    deputy.TranscriptLink.Should().Be("http://www.cir.ru/duma/servlet/is4.wwwmain?FormName=ProcessQuery&Action=RunQuery&PDCList=*&QueryString=%2FGD_%C4%C5%CF%D3%D2%C0%D2%3D%22%C6%C8%D0%C8%CD%CE%C2%D1%CA%C8%C9+%C2.%C2.%22");
    deputy.Educations.Should().NotBeNullOrEmpty().And.Contain(education => education.Institution == "Московский государственный университет имени М.В.Ломоносова (институт восточных языков)" && education.Year == 1970);
    deputy.Degrees.Should().NotBeNullOrEmpty().And.Contain("Доктор философских наук");
    deputy.Ranks.Should().NotBeNullOrEmpty().And.Contain(["Профессор", "Действительный член (академик) Международной Академии экологии и природопользования (МАЭП)", "Почетный академик Академии естествознания", "Действительный член Международной Академии информатизации", "Действительный член (академик) Академии социальных наук"]);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputiesApi.SearchAsync(IDeputiesApiRequest, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void DeputiesApi_SearchAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Deputies.SearchAsync(null, Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>().Await();

    var deputies = Api.Deputies.SearchAsync(request => request.Position(DeputyPosition.DumaDeputy).Current(false).Name("А")).ToListAsync().Await();

    deputies.Should().NotBeNullOrEmpty().And.BeOfType<List<Deputy>>();

    var deputy = deputies.Single(deputy => deputy.Id == 99100491);
    deputy.Name.Should().Be("Абдулатипов Рамазан Гаджимурадович");
    deputy.Position.Should().Be("Депутат ГД");
    deputy.Active.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAuthoritiesApi.FederalAsync(IAuthoritiesApiRequest, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void AuthoritiesApi_FederalAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Authorities.FederalAsync(null, Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>().Await();

    var authorities = Api.Authorities.FederalAsync(request => request.Current()).ToListAsync().Await();

    authorities.Should().NotBeNullOrEmpty().And.BeOfType<List<FederalAuthority>>();

    var authority = authorities.Single(authority => authority.Id == 6231000);
    authority.Name.Should().Be("Верховный Суд РФ");
    authority.Active.Should().BeTrue();
    authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
    authority.ToDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAuthoritiesApi.RegionalAsync(IAuthoritiesApiRequest, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void AuthoritiesApi_RegionalAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Authorities.RegionalAsync(null, Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>().Await();

    var authorities = Api.Authorities.RegionalAsync(request => request.Current(false)).ToListAsync().Await();

    authorities.Should().NotBeNullOrEmpty().And.BeOfType<List<RegionalAuthority>>();

    var authority = authorities.Single(authority => authority.Id == 6217700);
    authority.Name.Should().Be("Агинская Бурятская окружная Дума");
    authority.Active.Should().BeFalse();
    authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
    authority.ToDate.Should().HaveYear(2008).And.HaveMonth(10).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IInstancesApi.SearchAsync(IInstancesApiRequest, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void InstancesApi_SearchAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Instances.SearchAsync(null, Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>().Await();

    var instances = Api.Instances.SearchAsync().ToListAsync().Await();
    instances.Should().NotBeNullOrEmpty().And.BeOfType<List<Instance>>();
    var instance = instances.Single(instance => instance.Id == 177);
    instance.Name.Should().Be("ГД (Пленарное заседание)");
    instance.Active.Should().BeTrue();

    instances = Api.Instances.SearchAsync(new InstancesApiRequest().Current()).ToListAsync().Await();
    instances.Should().NotBeNullOrEmpty().And.BeOfType<List<Instance>>();
    instance = instances.Single(instance => instance.Id == 177);
    instance.Name.Should().Be("ГД (Пленарное заседание)");
    instance.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ILawsApi.SearchAsync(ILawsApiRequest, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void LawsApi_SearchAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Laws.SearchAsync(null)).ThrowExactlyAsync<ArgumentNullException>().Await();
    AssertionExtensions.Should(() => Api.Laws.SearchAsync(new LawsApiRequest(), Cancellation)).ThrowExactlyAsync<OperationCanceledException>().Await();

    var result = Api.Laws.SearchAsync(new LawsApiRequest().Name("курение").Sorting(LawsSorting.DateDescending)).Await();

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

  /// <summary>
  ///   <para>Performs testing of <see cref="IConvocationsApi.AllAsync(CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void ConvocationsApi_AllAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Convocations.AllAsync(Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>().Await();
    
    var convocations = Api.Convocations.AllAsync().ToListAsync().Await();

    convocations.Should().NotBeNullOrEmpty().And.BeOfType<List<Convocation>>();
    
    var convocation = convocations.Single(convocation => convocation.Id == 82100004);
    convocation.Name.Should().Be("4-ый созыв");
    convocation.FromDate.Should().HaveYear(2003).And.HaveMonth(12).And.HaveDay(29).And.HaveOffset(TimeSpan.Zero);
    convocation.ToDate.Should().HaveYear(2007).And.HaveMonth(12).And.HaveDay(23).And.HaveOffset(TimeSpan.Zero);
    convocation.Sessions.Should().NotBeNullOrEmpty().And.HaveCount(8).And.BeOfType<List<Session>>();

    var session = convocation.Sessions.ElementAt(0);
    session.Id.Should().Be(82200021);
    session.Name.Should().Be("Весенняя сессия 2004 г.");
    session.FromDate.Should().HaveYear(2004).And.HaveMonth(1).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    session.ToDate.Should().HaveYear(2004).And.HaveMonth(7).And.HaveDay(10).And.HaveOffset(TimeSpan.Zero);

    session = convocation.Sessions.ElementAt(1);
    session.Id.Should().Be(82200022);
    session.Name.Should().Be("Осенняя сессия 2004 г.");
    session.FromDate.Should().HaveYear(2004).And.HaveMonth(9).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
    session.ToDate.Should().HaveYear(2004).And.HaveMonth(12).And.HaveDay(31).And.HaveOffset(TimeSpan.Zero);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IQuestionsApi.SearchAsync(IQuestionsApiRequest, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void QuestionsApi_SearchAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Questions.SearchAsync(null, Cancellation).Await()).ThrowExactly<OperationCanceledException>();

    var result = Api.Questions.SearchAsync(request => request.FromDate(new DateTimeOffset(year: 2013, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).ToDate(new DateTimeOffset(year: 2013, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Name("образование").PageSize(PageSize.Five).Page(2)).Await();

    result.Count.Should().Be(44);
    result.Page.Should().Be(2);
    result.PageSize.Should().Be((int) PageSize.Five);

    result.Questions.Should().NotBeNullOrEmpty().And.BeOfType<IList<Question>>().And.HaveCount(5);

    var question = result.Questions.ElementAt(0);
    question.Name.Should().Be(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"".");
    question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(19).And.HaveOffset(TimeSpan.Zero);
    question.SessionCode.Should().Be(1367);
    question.Code.Should().Be(8);
    question.StartLine.Should().Be(1379);
    question.EndLine.Should().Be(6569);

    question = result.Questions.ElementAt(1);
    question.Name.Should().Be(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"" (принят в первом чтении 11 октября 2013 года с наименованием ""Об образовании в некоторых районных судах Ростовской области постоянных судебных присутствий"").");
    question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(15).And.HaveOffset(TimeSpan.Zero);
    question.SessionCode.Should().Be(1366);
    question.Code.Should().Be(18);
    question.StartLine.Should().Be(2096);
    question.EndLine.Should().Be(5763);

    question = result.Questions.ElementAt(2);
    question.Name.Should().Be(@"О проекте федерального закона № 249992-6 ""О внесении изменений в Федеральный закон ""Об общих принципах организации местного самоуправления в Российской Федерации"" (в части установления порядка избрания главы муниципального образования в поселениях с численностью жителей, обладающих избирательным правом, более 30 тысяч человек).");
    question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(15).And.HaveOffset(TimeSpan.Zero);
    question.SessionCode.Should().Be(1366);
    question.Code.Should().Be(27);
    question.StartLine.Should().Be(1299);
    question.EndLine.Should().Be(1343);

    question = result.Questions.ElementAt(3);
    question.Name.Should().Be(@"О проекте федерального закона № 228222-6 ""О внесении изменений в статью 11 Федерального закона ""О трудовых пенсиях в Российской Федерации"" (по вопросу о включении в страховой стаж для назначения пенсии периода получения высшего образования по очной форме обучения в государственных или муниципальных организациях высшего образования).");
    question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(15).And.HaveOffset(TimeSpan.Zero);
    question.SessionCode.Should().Be(1366);
    question.Code.Should().Be(29);
    question.StartLine.Should().Be(3867);
    question.EndLine.Should().Be(5943);

    question = result.Questions.ElementAt(4);
    question.Name.Should().Be(@"О проекте федерального закона № 193817-6 ""О внесении изменения в статью 19-1 Федерального закона ""Об обороте земель сельскохозяйственного назначения"" (в части продления срока осуществления органами местного самоуправления мероприятий по образованию земельных участков сельскохозяйственного назначения из земельных участков, находящихся в общей собственности).");
    question.Date.Should().HaveYear(2013).And.HaveMonth(11).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    question.SessionCode.Should().Be(1364);
    question.Code.Should().Be(40);
    question.StartLine.Should().Be(6225);
    question.EndLine.Should().Be(6278);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IRequestsApi.AllAsync(CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void RequestsApi_AllAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Questions.SearchAsync(null, Cancellation).Await()).ThrowExactly<OperationCanceledException>();

    var requests = Api.Requests.AllAsync().ToListAsync().Await();

    requests.Should().NotBeNullOrEmpty().And.BeOfType<List<DeputyRequest>>();

    var request = requests.First(request => request.Id == 14);
    request.Initiator.Should().Be("Герасименко Н.Ф.");
    request.Date.Should().HaveYear(2004).And.HaveMonth(11).And.HaveDay(10).And.HaveOffset(TimeSpan.Zero);
    request.Name.Should().Be("О присоединении Российской Федерации к Рамочной конвенции Всемирной организации здравоохранения по борьбе против табака (N 1103-IV ГД от 10 ноября 2004 г.).");
    request.ControlDate.Should().HaveYear(2004).And.HaveMonth(11).And.HaveDay(30).And.HaveOffset(TimeSpan.Zero);
    request.SignDate.Should().HaveYear(2004).And.HaveMonth(11).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    request.DocumentNumber.Should().Be("2.1.2-10/14");
    request.ResolutionNumber.Should().Be("1103-IV ГД");
    request.Answer.Should().NotBeNull();

    request.Signer.Should().NotBeNull().And.BeOfType<DeputyRequestSigner>();
    request.Signer.Id.Should().Be(99100416);
    request.Signer.Name.Should().Be("Чилингаров Артур Николаевич");

    request.Addressee.Should().NotBeNull().And.BeOfType<DeputyRequestAddressee>();
    request.Addressee.Id.Should().Be(3);
    request.Addressee.Name.Should().Be(@"Председателю Правительства РФ\М.Е. Фрадкову");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IStagesApi.AllAsync(CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void StagesApi_AllAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Stages.AllAsync(Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>();

    var stages = Api.Stages.AllAsync().ToListAsync().Await();

    stages.Should().NotBeNullOrEmpty().And.BeOfType<List<PhaseStage>>();

    var stage = stages.Single(stage => stage.Id == 1);
    stage.Name.Should().Be("Внесение законопроекта в Государственную Думу");
    stage.Phases.Should().NotBeNullOrEmpty().And.HaveCount(3).And.BeOfType<List<StagePhase>>();

    var phase = stage.Phases.ElementAt(0);
    phase.Id.Should().Be(1);
    phase.Name.Should().Be("Регистрация законопроекта и материалов к нему в САДД Государственной Думы");

    phase.Instance.Should().NotBeNull().And.BeOfType<Instance>();
    phase.Instance.Id.Should().Be(173);
    phase.Instance.Name.Should().Be("УДИО ГД");
    phase.Instance.Active.Should().BeTrue();

    phase = stage.Phases.ElementAt(1);
    phase.Id.Should().Be(2);
    phase.Name.Should().Be("Прохождение законопроекта у Председателя Государственной Думы");
    phase.Instance.Should().NotBeNull().And.BeOfType<Instance>();
    phase.Instance.Id.Should().Be(174);
    phase.Instance.Name.Should().Be("Секретариат Председателя ГД");
    phase.Instance.Active.Should().BeTrue();

    phase = stage.Phases.ElementAt(2);
    phase.Id.Should().Be(3);
    phase.Name.Should().Be("Регистрация законопроекта в Секретариате Совета Государственной Думы");
    phase.Instance.Should().NotBeNull().And.BeOfType<Instance>();
    phase.Instance.Id.Should().Be(175);
    phase.Instance.Name.Should().Be("Секретариат Совета ГД");
    phase.Instance.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ITopicsApi.AllAsync(CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void TopicsApi_AllAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Topics.AllAsync(Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>();

    var topics = Api.Topics.AllAsync().ToListAsync().Await();

    topics.Should().NotBeNullOrEmpty().And.BeOfType<List<Topic>>();
    
    var topic = topics.Single(topic => topic.Id == 62701);
    topic.Id.Should().Be(62701);
    topic.Name.Should().Be("Бюджетное, налоговое, финансовое законодательство");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ITranscriptsApi.DateAsync(DateTimeOffset, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void TranscriptsApi_DateAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Topics.AllAsync(Cancellation).ToListAsync()).ThrowExactlyAsync<OperationCanceledException>();

    var result = Api.Transcripts.DateAsync(new DateTimeOffset(year: 2013, month: 5, day: 14, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Await();

    result.Should().NotBeNull().And.BeOfType<DateTranscriptsResult>();

    result.Date.Should().HaveYear(2013).And.HaveMonth(5).And.HaveDay(5).And.HaveOffset(TimeSpan.Zero);

    var meetings = result.Meetings;
    meetings.Should().NotBeNullOrEmpty().And.BeOfType<List<DateTranscriptMeeting>>();

    var meeting = meetings.Single(meeting => meeting.Number == 97);
    meeting.Date.Should().HaveYear(2013).And.HaveMonth(5).And.HaveDay(14).And.HaveOffset(TimeSpan.Zero);
    meeting.Text.Should().Contain("ХРОНИКА", "заседания Государственной Думы", "14 мая 2013 года");

    meeting.Votes.Should().NotBeNullOrEmpty().And.HaveCount(29).And.BeOfType<List<Vote>>();

    var vote = meeting.Votes.First();
    vote.Line.Should().Be(6366);
    vote.Date.Should().HaveYear(2013).And.HaveMonth(5).And.HaveDay(14).And.HaveHour(18).And.HaveMinute(16).And.HaveOffset(TimeSpan.Zero);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ITranscriptsApi.DeputyAsync(IDeputyTranscriptApiRequest, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void TranscriptsApi_DeputyAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Transcripts.DeputyAsync(null)).ThrowExactlyAsync<ArgumentNullException>().Await();
    AssertionExtensions.Should(() => Api.Transcripts.DeputyAsync(new DeputyTranscriptApiRequest(), Cancellation)).ThrowExactlyAsync<OperationCanceledException>().Await();

    var result = Api.Transcripts.DeputyAsync(new DeputyTranscriptApiRequest().Deputy(99100142).FromDate(new DateTimeOffset(year: 2014, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).ToDate(new DateTimeOffset(year: 2014, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Page(1).PageSize(PageSize.Ten)).Await();

    result.Should().NotBeNull().And.BeOfType<DeputyTranscriptsResult>();

    result.Name.Should().Be("Жириновский Владимир Вольфович");
    result.PageSize.Should().Be((int) PageSize.Twenty);
    result.Page.Should().Be(1);
    result.Count.Should().BePositive();

    var meetings = result.Meetings;
    meetings.Should().NotBeNullOrEmpty().And.BeOfType<List<TranscriptMeeting>>();

    var meeting = meetings.First();
    meeting.Date.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    meeting.LinesCount.Should().BePositive();
    meeting.Number.Should().BePositive();
    meeting.Questions.Should().NotBeNullOrEmpty().And.BeOfType<Question>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ITranscriptsApi.LawAsync(string, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void TranscriptsApi_LawAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Transcripts.LawAsync(null)).ThrowExactlyAsync<ArgumentNullException>().Await();
    AssertionExtensions.Should(() => Api.Transcripts.LawAsync(string.Empty)).ThrowExactlyAsync<ArgumentException>().Await();
    AssertionExtensions.Should(() => Api.Transcripts.LawAsync(Randomizer.Letters(25), Cancellation)).ThrowExactlyAsync<OperationCanceledException>().Await();

    var result = Api.Transcripts.LawAsync("140513-6").Await();

    result.Should().NotBeNull().And.BeOfType<LawTranscriptsResult>();

    result.Number.Should().Be("140513-6");
    result.Name.Should().Be("О внесении изменений в главы 23 и 26 части второй Налогового кодекса Российской Федерации");
    result.Comments.Should().Be("в части уточнения видов доходов, полученных от использования в Российской Федерации авторских или  смежных прав");

    var meetings = result.Meetings;
    meetings.Should().NotBeNullOrEmpty().And.HaveCount(2).And.BeOfType<TranscriptMeeting>();

    var meeting = meetings.First();
    meeting.Date.Should().HaveYear(2013).And.HaveMonth(6).And.HaveDay(21).And.HaveOffset(TimeSpan.Zero);
    meeting.Number.Should().Be(107);
    meeting.LinesCount.Should().Be(8221);

    meeting.Questions.Should().NotBeNullOrEmpty().And.BeOfType<List<TranscriptMeetingQuestion>>();

    var question = meeting.Questions.Single();
    question.Name.Should().Be(@"О проекте федерального закона № 140513-6 ""О внесении изменений в главы 23 и 26 части второй Налогового кодекса Российской Федерации"" (в части уточнения видов доходов от использования авторских или смежных прав; принят в первом чтении 15 мая 2013 года с наименованием ""О внесении изменений в статью 208 Налогового кодекса Российской Федерации"").");
    question.Stage.Should().Be("Рассмотрение законопроекта во втором чтении");

    question.Parts.Should().NotBeNullOrEmpty().And.HaveCount(2).And.BeOfType<TranscriptMeetingQuestionPart>();

    var part = question.Parts.ElementAt(0);
    part.StartLine.Should().Be(3501);
    part.EndLine.Should().Be(3544);
    part.Text.Should().Contain("Продолжаем работу. 29-й пункт порядка работы");

    var vote = part.Votes.Single();
    vote.Line.Should().Be(3525);
    vote.Date.Should().HaveYear(2013).And.HaveMonth(6).And.HaveDay(21).And.HaveHour(12).And.HaveMinute(34).And.HaveSecond(14).And.HaveOffset(TimeSpan.Zero);

    part = question.Parts.ElementAt(1);
    part.StartLine.Should().Be(7210);
    part.EndLine.Should().Be(7246);
    part.Text.Should().Contain("29-й пункт порядка работы, проект федерального закона");

    part.Votes.Should().NotBeNullOrEmpty().And.HaveCount(2).And.BeOfType<TranscriptVote>();

    vote = part.Votes.ElementAt(0);
    vote.Line.Should().Be(7218);
    vote.Date.Should().HaveYear(2013).And.HaveMonth(6).And.HaveDay(21).And.HaveHour(16).And.HaveMinute(45).And.HaveSecond(15).And.HaveOffset(TimeSpan.Zero);

    vote = part.Votes.ElementAt(1);
    vote.Line.Should().Be(7237);
    vote.Date.Should().HaveYear(2013).And.HaveMonth(6).And.HaveDay(21).And.HaveHour(16).And.HaveMinute(45).And.HaveSecond(44).And.HaveOffset(TimeSpan.Zero);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ITranscriptsApi.QuestionAsync(long, long, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void TranscriptsApi_QuestionAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Transcripts.QuestionAsync(0, 0, Cancellation)).ThrowExactlyAsync<OperationCanceledException>().Await();

    var result = Api.Transcripts.QuestionAsync(80, 13).Await();

    result.Should().NotBeNull().And.BeOfType<QuestionTranscriptsResult>();

    result.Meetings.Should().NotBeNullOrEmpty().And.BeOfType<TranscriptMeeting>();

    var meeting = result.Meetings.Single();
    meeting.Date.Should().HaveYear(1995).And.HaveMonth(1).And.HaveDay(18).And.HaveOffset(TimeSpan.Zero);
    meeting.Number.Should().Be(80);
    meeting.LinesCount.Should().Be(6711);

    meeting.Questions.Should().NotBeNullOrEmpty().And.BeOfType<TranscriptMeetingQuestion>();
    var question = meeting.Questions.Single();
    question.Name.Should().Be("О проекте постановления Государственной Думы о первоочередных мерах по образованию Счетной палаты Российской Федерации.");
    question.Stage.Should().BeNull();

    var part = question.Parts.Single();
    part.StartLine.Should().Be(4372);
    part.EndLine.Should().Be(4424);
    part.Text.Should().Contain("ЗАДОРНОВ М.М. О Счетной палате?");

    var vote = part.Votes.Single();
    vote.Line.Should().Be(4404);
    vote.Date.Should().HaveYear(1995).And.HaveMonth(1).And.HaveDay(18).And.HaveHour(16).And.HaveMinute(18).And.HaveSecond(52).And.HaveOffset(TimeSpan.Zero);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ITranscriptsApi.ResolutionAsync(string, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void TranscriptsApi_ResolutionAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Transcripts.ResolutionAsync(null)).ThrowExactlyAsync<ArgumentNullException>().Await();
    AssertionExtensions.Should(() => Api.Transcripts.ResolutionAsync(string.Empty)).ThrowExactlyAsync<ArgumentException>().Await();
    AssertionExtensions.Should(() => Api.Transcripts.ResolutionAsync(Randomizer.Letters(25), Cancellation)).ThrowExactlyAsync<OperationCanceledException>().Await();

    var result = Api.Transcripts.ResolutionAsync("276569-6").Await();

    result.Should().NotBeNull().And.BeOfType<ResolutionTranscriptsResult>();

    result.Number.Should().Be("276569-6");

    result.Meetings.Should().NotBeNullOrEmpty().And.BeOfType<List<TranscriptMeeting>>();

    var meeting = result.Meetings.Single();
    meeting.Date.Should().HaveYear(2013).And.HaveMonth(5).And.HaveDay(14).And.HaveOffset(TimeSpan.Zero);
    meeting.Number.Should().Be(97);
    meeting.LinesCount.Should().Be(6563);

    meeting.Questions.Should().NotBeNullOrEmpty().And.BeOfType<List<TranscriptMeetingQuestion>>();

    var question = meeting.Questions.Single();
    question.Name.Should().Be("О проекте постановления Государственной Думы \u2116 276569-6 \"О внесении изменений в план проведения \"правительственного часа\" на весеннюю сессию Государственной Думы 2013 года, утверждённый постановлением Государственной Думы Федерального Собрания Российской Федерации \"О плане проведения \"правительственного часа\" на весеннюю сессию Государственной Думы 2013 года\" (в части проведения \"правительственного часа\" 22 мая 2013 года).");
    question.Stage.Should().BeNull();

    question.Parts.Should().NotBeNullOrEmpty().And.HaveCount(2).And.BeOfType<List<TranscriptMeetingQuestionPart>>();

    var part = question.Parts.ElementAt(0);
    part.StartLine.Should().Be(1183);
    part.EndLine.Should().Be(1209);
    part.Text.Should().Contain("2-й вопрос, проект постановления Государственной Думы");
    part.Votes.Should().BeEmpty();

    part = question.Parts.ElementAt(1);
    part.StartLine.Should().Be(4948);
    part.EndLine.Should().Be(4965);
    part.Text.Should().Be("2-й пункт повестки, проект постановления Государственной Думы");

    var vote = part.Votes.Single();
    vote.Line.Should().Be(4956);
    vote.Date.Should().HaveYear(2013).And.HaveMonth(5).And.HaveDay(14).And.HaveHour(17).And.HaveMinute(4).And.HaveSecond(8).And.HaveOffset(TimeSpan.Zero);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IVotesApi.SearchAsync(IVotesSearchApiRequest, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void VotesApi_SearchAsync_Method()
  {
    AssertionExtensions.Should(() => Api.Votes.SearchAsync(null)).ThrowExactlyAsync<ArgumentNullException>().Await();
    AssertionExtensions.Should(() => Api.Votes.SearchAsync(_ => {}, Cancellation)).ThrowExactlyAsync<OperationCanceledException>().Await();

    var result = Api.Votes.SearchAsync(request => request.FromDate(DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(180))).ToDate(DateTimeOffset.UtcNow)).Await();

    result.Count.Should().BePositive();
    result.PageSize.Should().Be(20);
    result.Wording.Should().NotBeNullOrEmpty();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    Api.Dispose();
  }
}