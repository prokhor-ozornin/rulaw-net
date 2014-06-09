using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IApiCallerExtensions"/>.</para>
  /// </summary>
  public sealed class IApiCallerExtensionsTests
  {
    private readonly IApiCaller xmlApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Xml));
    private readonly IApiCaller jsonApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Json));

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Branches(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Branches_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Branches(null));

      this.TestBranches(this.xmlApiCaller.Branches());
      this.TestBranches(this.jsonApiCaller.Branches());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Committees(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Committees_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Committees(null));

      this.TestCommittees(this.xmlApiCaller.Committees());
      this.TestCommittees(this.jsonApiCaller.Committees());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Convocations(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Convocations_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Convocations(null));

      this.TestConvocations(this.xmlApiCaller.Convocations());
      this.TestConvocations(this.jsonApiCaller.Convocations());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Deputy(IApiCaller, long)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deputy_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Deputy(null, 0));

      const long id = 99100142;
      this.TestDeputyInfo(this.xmlApiCaller.Deputy(id));
      this.TestDeputyInfo(this.jsonApiCaller.Deputy(id));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Deputies(IApiCaller, Action{IDeputiesLawApiCall})"/> method.</para>
    /// </summary>
    [Fact]
    public void Deputies_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Deputies(null));

      this.TestDeputies(this.xmlApiCaller.Deputies());
      this.TestDeputies(this.jsonApiCaller.Deputies());

      var call = (Action<IDeputiesLawApiCall>)(x => x.Position(DeputyPosition.DumaDeputy).Current(false).Name("А"));
      this.TestDeputies(this.xmlApiCaller.Deputies(call));
      this.TestDeputies(this.jsonApiCaller.Deputies(call));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.FederalAuthorities(IApiCaller, Action{IAuthoritiesLawApiCall})"/> method.</para>
    /// </summary>
    [Fact]
    public void FederalAuthorities_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.FederalAuthorities(null));

      this.TestFederalAuthorities(this.xmlApiCaller.FederalAuthorities());
      this.TestFederalAuthorities(this.jsonApiCaller.FederalAuthorities());

      var call = (Action<IAuthoritiesLawApiCall>) (x => x.Current());
      this.TestFederalAuthorities(this.xmlApiCaller.FederalAuthorities(call));
      this.TestFederalAuthorities(this.jsonApiCaller.FederalAuthorities(call));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Instances(IApiCaller, Action{IInstancesLawApiCall})"/> method.</para>
    /// </summary>
    [Fact]
    public void Instances_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Instances(null));

      this.TestInstances(this.xmlApiCaller.Instances());
      this.TestInstances(this.jsonApiCaller.Instances());

      var call = (Action<IInstancesLawApiCall>)(x => x.Current());
      this.TestInstances(this.xmlApiCaller.Instances(call));
      this.TestInstances(this.jsonApiCaller.Instances(call));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Laws(IApiCaller, Action{ILawsLawApiCall})"/> method.</para>
    /// </summary>
    [Fact]
    public void Laws_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Laws(null, request => { }));
      Assert.Throws<ArgumentNullException>(() => this.xmlApiCaller.Laws(null));

      this.TestLawsSearchResult(this.xmlApiCaller.Laws(call => call.Name("курение").Sorting(LawsSorting.DateDescending)));
      this.TestLawsSearchResult(this.jsonApiCaller.Laws(call => call.Name("курение").Sorting(LawsSorting.DateDescending)));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Questions(IApiCaller, Action{IQuestionsLawApiCall})"/> method.</para>
    /// </summary>
    [Fact]
    public void Questions_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Questions(null));

      var call = (Action<IQuestionsLawApiCall>)(x => x.From(new DateTime(2013, 1, 1)).To(new DateTime(2013, 12, 31)).Name("образование").PageSize(PageSize.Five).Page(2));
      this.TestQuestionsSearchResult(this.xmlApiCaller.Questions(call));
      this.TestQuestionsSearchResult(this.jsonApiCaller.Questions(call));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.RegionalAuthorities(IApiCaller, Action{IAuthoritiesLawApiCall})"/> method.</para>
    /// </summary>
    [Fact]
    public void RegionalAuthorities_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.RegionalAuthorities(null));

      this.TestRegionalAuthorities(this.xmlApiCaller.RegionalAuthorities());
      this.TestRegionalAuthorities(this.jsonApiCaller.RegionalAuthorities());

      var call = (Action<IAuthoritiesLawApiCall>)(x => x.Current(false));
      this.TestRegionalAuthorities(this.xmlApiCaller.RegionalAuthorities(call));
      this.TestRegionalAuthorities(this.jsonApiCaller.RegionalAuthorities(call));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Requests(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Requests_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Requests(null));

      this.TestRequests(this.xmlApiCaller.Requests());
      this.TestRequests(this.jsonApiCaller.Requests());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Stages(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Stages_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Stages(null));

      this.TestStages(this.xmlApiCaller.Stages());
      this.TestStages(this.jsonApiCaller.Stages());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Topics(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Topics_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Topics(null));

      this.TestTopics(this.xmlApiCaller.Topics());
      this.TestTopics(this.jsonApiCaller.Topics());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Transcripts(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Transcripts_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Transcripts(null));

      Assert.True(this.xmlApiCaller.Transcripts() is TranscriptsApiCaller);
      Assert.False(ReferenceEquals(this.xmlApiCaller.Transcripts(), this.xmlApiCaller.Transcripts()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Votes(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Votes_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Votes(null));

      Assert.True(this.xmlApiCaller.Votes() is VotesApiCaller);
      Assert.False(ReferenceEquals(this.xmlApiCaller.Votes(), this.xmlApiCaller.Votes()));
    }

    private void TestBranches(IEnumerable<LawBranch> branches)
    {
      Assertion.NotNull(branches);

      Assert.True(branches is IList<LawBranch>);
      Assert.True(branches.Any());
      var branch = branches.Single(x => x.Id == 68252);
      Assert.Equal("Безопасность и охрана правопорядка", branch.Name);
    }

    private void TestCommittees(IEnumerable<Committee> committees)
    {
      Assertion.NotNull(committees);

      Assert.True(committees is IList<Committee>);
      Assert.True(committees.Any());
      var commmittee = committees.Single(x => x.Id == 6274200);
      Assert.Equal("Комитет ГД по аграрным вопросам", commmittee.Name);
      Assert.Equal(new DateTime(1994, 1, 20), commmittee.FromDate);
    }

    private void TestConvocations(IEnumerable<Convocation> convocations)
    {
      Assertion.NotNull(convocations);

      Assert.True(convocations is IList<Convocation>);
      Assert.True(convocations.Any());
      var convocation = convocations.Single(x => x.Id == 82100004);
      Assert.Equal("4-ый созыв", convocation.Name);
      Assert.Equal(new DateTime(2003, 12, 29), convocation.FromDate);
      Assert.Equal(new DateTime(2007, 12, 23), convocation.ToDate);
      Assert.Equal(8, convocation.Sessions.Count);
      
      var session = convocation.Sessions[0];
      Assert.Equal(82200021, session.Id);
      Assert.Equal("Весенняя сессия 2004 г.", session.Name);
      Assert.Equal(new DateTime(2004, 1, 12), session.FromDate);
      Assert.Equal(new DateTime(2004, 7, 10), session.ToDate);

      session = convocation.Sessions[1];
      Assert.Equal(82200022, session.Id);
      Assert.Equal("Осенняя сессия 2004 г.", session.Name);
      Assert.Equal(new DateTime(2004, 9, 1), session.FromDate);
      Assert.Equal(new DateTime(2004, 12, 31), session.ToDate);
    }

    private void TestDeputies(IEnumerable<Deputy> deputies)
    {
      Assertion.NotNull(deputies);

      Assert.True(deputies is IList<Deputy>);
      Assert.True(deputies.Any());
      var deputy = deputies.Single(x => x.Id == 99100491);
      Assert.Equal("Абдулатипов Рамазан Гаджимурадович", deputy.Name);
      Assert.Equal("Депутат ГД", deputy.Position);
      Assert.False(deputy.Active);
    }

    private void TestDeputyInfo(DeputyInfo deputy)
    {
      Assertion.NotNull(deputy);

      Assert.Equal("Жириновский", deputy.LastName);
      Assert.Equal("Владимир", deputy.FirstName);
      Assert.Equal("Вольфович", deputy.MiddleName);
      Assert.Equal(new DateTime(1946, 4, 25), deputy.BirthDate);
      Assert.Equal(new DateTime(2011, 12, 4), deputy.WorkStartDate);
      Assert.Equal(72100005, deputy.FactionId);
      Assert.Equal(@"Фракция Политической партии ""Либерально-демократическая партия России""", deputy.FactionName);
      Assert.Equal("00020 Руководитель фракции", deputy.FactionRole.Trim());
      Assert.True(deputy.Active);
      Assert.Equal("(Общефедеральная часть федерального списка)", deputy.FactionRegion);
      Assert.True(deputy.LawsCount > 0);
      Assert.True(deputy.Regions.Contains("все субъекты Российской Федерации"));
      Assert.True(deputy.SpeachesCount > 0);
      Assert.Equal("http://vote.duma.gov.ru/?convocation=AAAAAAA6&deputy=99100142&sort=date_desc", deputy.VoteLink);
      Assert.Equal("http://www.cir.ru/duma/servlet/is4.wwwmain?FormName=ProcessQuery&Action=RunQuery&PDCList=*&QueryString=%2FGD_%C4%C5%CF%D3%D2%C0%D2%3D%22%C6%C8%D0%C8%CD%CE%C2%D1%CA%C8%C9+%C2.%C2.%22", deputy.TranscriptLink);

      Assert.True(deputy.Educations.Any(education => education.Institution == "Московский государственный университет им. М.В. Ломоносова (институт восточных языков)" && education.Year == 1970));

      Assert.True(deputy.Degrees.Contains("Доктор философских наук"));

      Assert.True(deputy.Ranks.Contains("Профессор"));
      Assert.True(deputy.Ranks.Contains("Действительный член (академик) Международной Академии экологии и природопользования (МАЭП)"));
      Assert.True(deputy.Ranks.Contains("Почетный академик Академии естествознания"));
      Assert.True(deputy.Ranks.Contains("Действительный член Международной Академии информатизации"));
      Assert.True(deputy.Ranks.Contains("Действительный член (академик) Академии социальных наук"));

      Assert.True(deputy.Activities.Any(activity => activity.Name == "Член комитета" && activity.CommitteeId == 6274500 && activity.CommitteeNameGenitive == "Комитета ГД по обороне"));
    }

    private void TestFederalAuthorities(IEnumerable<Authority> authorities)
    {
      Assertion.NotNull(authorities);

      Assert.True(authorities is IList<FederalAuthority>);
      Assert.True(authorities.Any());
      var authority = authorities.Single(x => x.Id == 6231000);
      Assert.Equal("Верховный Суд РФ", authority.Name);
      Assert.True(authority.Active);
      Assert.Equal(new DateTime(1994, 1, 1), authority.FromDate);
      Assert.Null(authority.ToDate);
    }

    private void TestLawsSearchResult(LawsSearchResult result)
    {
      Assertion.NotNull(result);

      Assert.True(result.Count > 0);
      Assert.Equal(1, result.Page);
      Assert.Equal("Законопроекты, где наименование или комментарий содержит \"курение\", отсортированные по дате внесения в ГД (по убыванию)", result.Wording);

      var laws = result.Laws;
      Assert.True(laws.Any());
      
      var law = laws.Number("170826-6");
      
      Assert.Null(law.Comments);

      var committee = law.Committees.Profile.Single();
      Assert.True(committee.Active);
      Assert.Equal(new DateTime(2003, 12, 29), committee.FromDate);
      Assert.Null(committee.ToDate);
      Assert.Null(law.Committees.Responsible);
      Assert.False(law.Committees.SoExecutor.Any());

      Assert.Equal(new DateTime(2012, 11, 13), law.Date);
      
      Assert.Equal(19135, law.Id);
      
      Assert.Equal(new DateTime(2012, 12, 20), law.LastEvent.Date);
      Assert.Equal("68", law.LastEvent.Document.Name);
      Assert.Equal("Протокол заседания Совета ГД", law.LastEvent.Document.Type);
      Assert.Equal(5, law.LastEvent.Phase.Id);
      Assert.Equal("Рассмотрение Советом Государственной Думы законопроекта, внесенного в Государственную Думу", law.LastEvent.Phase.Name);
      Assert.Equal("снять законопроект с рассмотрения Государственной Думы в связи с отзывом субъектом права законодательной инициативы", law.LastEvent.Solution);
      Assert.Equal(2, law.LastEvent.Stage.Id);
      Assert.Equal("Предварительное рассмотрение законопроекта, внесенного в Государственную Думу", law.LastEvent.Stage.Name);

      Assert.Equal("Об ограничении курения табака в целях охраны здоровья населения", law.Name);

      Assert.Equal("170826-6", law.Number);

      Assert.False(law.Subject.Departments.Any());

      var deputy = law.Subject.Deputies.Single();
      Assert.Equal(99100270, deputy.Id);
      Assert.True(deputy.Active);
      Assert.Equal(DeputyPosition.DumaDeputy, deputy.GetPosition());
      Assert.Equal("Митрофанов Алексей Валентинович", deputy.Name);

      Assert.Null(law.TranscriptUrl);

      Assert.Equal((int) LawTypes.Federal, law.Type.Id);
      Assert.Equal("Федеральный закон", law.Type.Name);

      Assert.Equal("http://asozd2.duma.gov.ru/main.nsf/%28SpravkaNew%29?OpenAgent&RN=170826-6&02", law.Url);
    }

    private void TestInstances(IEnumerable<Instance> instances)
    {
      Assertion.NotNull(instances);

      Assert.True(instances is IList<Instance>);
      Assert.True(instances.Any());
      var instance = instances.Single(x => x.Id == 177);
      Assert.Equal("ГД (Пленарное заседание)", instance.Name);
      Assert.True(instance.Active);
    }

    private void TestQuestionsSearchResult(QuestionsSearchResult result)
    {
      Assertion.NotNull(result);

      Assert.Equal(44, result.Count);
      Assert.Equal(2, result.Page);
      Assert.Equal((int) PageSize.Five, result.PageSize);

      var questions = result.Questions;
      Assert.True(questions is IList<Question>);
      Assert.True(questions.Any());
      Assert.Equal(5, questions.Count());

      var question = questions.ElementAt(0);
      Assert.Equal(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"".", question.Name);
      Assert.Equal(new DateTime(2013, 11, 19), question.Date);
      Assert.Equal(1367, question.SessionCode);
      Assert.Equal(8, question.Code);
      Assert.Equal(1379, question.StartLine);
      Assert.Equal(6569, question.EndLine);

      question = questions.ElementAt(1);
      Assert.Equal(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"" (принят в первом чтении 11 октября 2013 года с наименованием ""Об образовании в некоторых районных судах Ростовской области постоянных судебных присутствий"").", question.Name);
      Assert.Equal(new DateTime(2013, 11, 15), question.Date);
      Assert.Equal(1366, question.SessionCode);
      Assert.Equal(18, question.Code);
      Assert.Equal(2096, question.StartLine);
      Assert.Equal(5763, question.EndLine);

      question = questions.ElementAt(2);
      Assert.Equal(@"О проекте федерального закона № 249992-6 ""О внесении изменений в Федеральный закон ""Об общих принципах организации местного самоуправления в Российской Федерации"" (в части установления порядка избрания главы муниципального образования в поселениях с численностью жителей, обладающих избирательным правом, более 30 тысяч человек).", question.Name);
      Assert.Equal(new DateTime(2013, 11, 15), question.Date);
      Assert.Equal(1366, question.SessionCode);
      Assert.Equal(27, question.Code);
      Assert.Equal(1299, question.StartLine);
      Assert.Equal(1343, question.EndLine);

      question = questions.ElementAt(3);
      Assert.Equal(@"О проекте федерального закона № 228222-6 ""О внесении изменений в статью 11 Федерального закона ""О трудовых пенсиях в Российской Федерации"" (по вопросу о включении в страховой стаж для назначения пенсии периода получения высшего образования по очной форме обучения в государственных или муниципальных организациях высшего образования).", question.Name);
      Assert.Equal(new DateTime(2013, 11, 15), question.Date);
      Assert.Equal(1366, question.SessionCode);
      Assert.Equal(29, question.Code);
      Assert.Equal(3867, question.StartLine);
      Assert.Equal(5943, question.EndLine);

      question = questions.ElementAt(4);
      Assert.Equal(@"О проекте федерального закона № 193817-6 ""О внесении изменения в статью 19-1 Федерального закона ""Об обороте земель сельскохозяйственного назначения"" (в части продления срока осуществления органами местного самоуправления мероприятий по образованию земельных участков сельскохозяйственного назначения из земельных участков, находящихся в общей собственности).", question.Name);
      Assert.Equal(new DateTime(2013, 11, 12), question.Date);
      Assert.Equal(1364, question.SessionCode);
      Assert.Equal(40, question.Code);
      Assert.Equal(6225, question.StartLine);
      Assert.Equal(6278, question.EndLine);
    }

    private void TestRegionalAuthorities(IEnumerable<Authority> authorities)
    {
      Assertion.NotNull(authorities);

      Assert.True(authorities is IList<RegionalAuthority>);
      Assert.True(authorities.Any());
      var authority = authorities.Single(x => x.Id == 6217700);
      Assert.Equal("Агинская Бурятская окружная Дума", authority.Name);
      Assert.False(authority.Active);
      Assert.Equal(new DateTime(1994, 1, 1), authority.FromDate);
      Assert.Equal(new DateTime(2008, 10, 12), authority.ToDate);
    }

    private void TestRequests(IEnumerable<DeputyRequest> requests)
    {
      Assertion.NotNull(requests);

      Assert.True(requests is IList<DeputyRequest>);
      Assert.True(requests.Any());
      var request = requests.First(x => x.Id == 14);
      Assert.Equal("Герасименко Н.Ф.", request.Initiator);
      Assert.Equal(new DateTime(2004, 11, 10), request.Date);
      Assert.Equal("О присоединении Российской Федерации к Рамочной конвенции Всемирной организации здравоохранения по борьбе против табака (N 1103-IV ГД от 10 ноября 2004 г.).", request.Name);
      Assert.Equal(new DateTime(2004, 11, 30), request.ControlDate);
      Assert.Equal(new DateTime(2004, 11, 12), request.SignDate);
      Assert.Equal("2.1.2-10/14", request.DocumentNumber);
      Assert.Equal("1103-IV ГД", request.ResolutionNumber);
      Assert.NotNull(request.Answer);
      Assert.Equal(99100416, request.Signer.Id);
      Assert.Equal("Чилингаров Артур Николаевич", request.Signer.Name);
      Assert.Equal(3, request.Addressee.Id);
      Assert.Equal(@"Председателю Правительства РФ\М.Е. Фрадкову", request.Addressee.Name);
    }

    private void TestStages(IEnumerable<PhaseStage> stages)
    {
      Assertion.NotNull(stages);

      Assert.True(stages is IList<PhaseStage>);
      Assert.True(stages.Any());
      var stage = stages.Single(x => x.Id == 1);
      Assert.Equal("Внесение законопроекта в Государственную Думу", stage.Name);
      Assert.Equal(3, stage.Phases.Count);

      var phase = stage.Phases[0];
      Assert.Equal(1, phase.Id);
      Assert.Equal("Регистрация законопроекта и материалов к нему в САДД Государственной Думы", phase.Name);
      Assert.Equal(173, phase.Instance.Id);
      Assert.Equal("УДИО ГД", phase.Instance.Name);
      Assert.True(phase.Instance.Active);

      phase = stage.Phases[1];
      Assert.Equal(2, phase.Id);
      Assert.Equal("Прохождение законопроекта у Председателя Государственной Думы", phase.Name);
      Assert.Equal(174, phase.Instance.Id);
      Assert.Equal("Секретариат Председателя ГД", phase.Instance.Name);
      Assert.True(phase.Instance.Active);

      phase = stage.Phases[2];
      Assert.Equal(3, phase.Id);
      Assert.Equal("Регистрация законопроекта в Секретариате Совета Государственной Думы", phase.Name);
      Assert.Equal(175, phase.Instance.Id);
      Assert.Equal("Секретариат Совета ГД", phase.Instance.Name);
      Assert.True(phase.Instance.Active);
    }

    private void TestTopics(IEnumerable<Topic> topics)
    {
      Assert.NotNull(topics);

      Assert.True(topics is IList<Topic>);
      Assert.True(topics.Any());
      var topic = topics.Single(x => x.Id == 62701);
      Assert.Equal("Бюджетное, налоговое, финансовое законодательство", topic.Name);
    }
  }
}