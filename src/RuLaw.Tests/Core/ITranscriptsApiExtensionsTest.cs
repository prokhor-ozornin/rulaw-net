using System.Configuration;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ITranscriptsApiExtensions"/>.</para>
/// </summary>
public sealed class ITranscriptsApiExtensionsTest : IDisposable
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  private CancellationToken Cancellation { get; } = new(true);

  /// <summary>
  ///   <para>Performs testing of <see cref="ITranscriptsApiExtensions.Date(ITranscriptsApi, out IDateTranscriptsResult?, DateTimeOffset, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void Date_Method()
  {
    AssertionExtensions.Should(() => ITranscriptsApiExtensions.Date(null!, out _, DateTimeOffset.UtcNow)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Api.Transcripts.Date(out _, DateTimeOffset.UtcNow, Cancellation)).ThrowExactly<TaskCanceledException>();

    Api.Transcripts.Date(out var result, new DateTimeOffset(year: 2013, month: 5, day: 14, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeTrue();

    result.Should().NotBeNull().And.BeOfType<DateTranscriptsResult>();

    result!.Date.Should().HaveYear(2013).And.HaveMonth(5).And.HaveDay(5).And.HaveOffset(TimeSpan.Zero);

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
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ITranscriptsApiExtensions.Deputy(ITranscriptsApi, Action{IDeputyTranscriptApiRequest}, CancellationToken)"/></description></item>
  ///     <item><description><see cref="ITranscriptsApiExtensions.Deputy(ITranscriptsApi, out IDeputyTranscriptsResult?, Action{IDeputyTranscriptApiRequest}, CancellationToken)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Deputy_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ITranscriptsApiExtensions.Deputy(null!, _ => { })).ThrowExactlyAsync<ArgumentNullException>().Await();
      AssertionExtensions.Should(() => Api.Transcripts.Deputy(null!)).ThrowExactlyAsync<ArgumentNullException>().Await();
      AssertionExtensions.Should(() => Api.Transcripts.Deputy(_ => { }, Cancellation)).ThrowExactlyAsync<TaskCanceledException>().Await();

      var result = Api.Transcripts.Deputy(request => request.Deputy(99100142).FromDate(new DateTimeOffset(year: 2014, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).ToDate(new DateTimeOffset(year: 2014, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Page(1).PageSize(PageSize.Ten)).Await();
      
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

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ITranscriptsApiExtensions.Deputy(null!, out _, _ => { })).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Transcripts.Deputy(out _, null!)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Transcripts.Deputy(out _, _ => {}, Cancellation)).ThrowExactly<TaskCanceledException>();

      Api.Transcripts.Deputy(out var result, request => request.Deputy(99100142).FromDate(new DateTimeOffset(year: 2014, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).ToDate(new DateTimeOffset(year: 2014, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Page(1).PageSize(PageSize.Ten)).Should().BeTrue();

      result.Should().NotBeNull().And.BeOfType<DeputyTranscriptsResult>();

      result!.Name.Should().Be("Жириновский Владимир Вольфович");
      result.PageSize.Should().Be((int) PageSize.Twenty);
      result.Page.Should().Be(1);
      result.Count.Should().BePositive();
      
      var meetings = result.Meetings;
      meetings.Should().NotBeNullOrEmpty().And.BeOfType<TranscriptMeeting>();

      var meeting = meetings.First();
      meeting.Date.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
      meeting.LinesCount.Should().BePositive();
      meeting.Number.Should().BePositive();
      meeting.Questions.Should().NotBeNullOrEmpty().And.BeOfType<List<Question>>();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ITranscriptsApiExtensions.Law(ITranscriptsApi, out ILawTranscriptsResult?, string, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void Law_Method()
  {
    AssertionExtensions.Should(() => ITranscriptsApiExtensions.Law(null!, out _, "number")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Api.Transcripts.Law(out _,  null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Api.Transcripts.Law(out _, string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => Api.Transcripts.Law(out _, "number", Cancellation)).ThrowExactly<TaskCanceledException>();

    Api.Transcripts.Law(out var result, "140513-6").Should().BeTrue();

    result.Should().NotBeNull().And.BeOfType<LawTranscriptsResult>();

    result!.Number.Should().Be("140513-6");
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
  ///   <para>Performs testing of <see cref="ITranscriptsApiExtensions.Question(ITranscriptsApi, out IQuestionTranscriptsResult?, long, long, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void Question_Method()
  {
    AssertionExtensions.Should(() => ITranscriptsApiExtensions.Question(null!, out _, long.MinValue, long.MaxValue)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => ITranscriptsApiExtensions.Question(null!, out _, long.MinValue, long.MaxValue, Cancellation)).ThrowExactly<TaskCanceledException>();

    Api.Transcripts.Question(out var result, 80, 13).Should().BeTrue();

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
  ///   <para>Performs testing of <see cref="ITranscriptsApiExtensions.Resolution(ITranscriptsApi, out IResolutionTranscriptsResult?, string, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void Resolution_Method()
  {
    AssertionExtensions.Should(() => ITranscriptsApiExtensions.Resolution(null!, out _, Guid.Empty.ToString())).ThrowExactly<ArgumentNullException>();

    Api.Transcripts.Resolution(out var result, "276569-6").Should().BeTrue();

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
  ///   <para></para>
  /// </summary>
  public void Dispose()
  {
    Api.Dispose();
  }
}