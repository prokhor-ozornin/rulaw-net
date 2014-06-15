using System;
using System.Configuration;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TranscriptsApiCaller"/>.</para>
  /// </summary>
  public sealed class TranscriptsApiCallerTests
  {
    private readonly IApiCaller xmlApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Xml));
    private readonly IApiCaller jsonApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Json));

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="TranscriptsApiCaller(IApiCaller)"/>
    [Fact]
    public void Constructors()
    {
      Assert.Throws<ArgumentNullException>(() => new TranscriptsApiCaller(null));

      var apiCaller = RuLaw.API(api => api.ApiKey("apiKey").AppKey("appKey"));
      var caller = new TranscriptsApiCaller(apiCaller);
      Assert.True(ReferenceEquals(apiCaller, caller.Api));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptsApiCaller.Date(DateTime)"/> method.</para>
    /// </summary>
    [Fact]
    public void Date_Method()
    {
      this.TestDateTranscriptsResult(this.xmlApiCaller.Transcripts().Date(new DateTime(2013, 5, 14)));
      this.TestDateTranscriptsResult(this.jsonApiCaller.Transcripts().Date(new DateTime(2013, 5, 14)));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptsApiCaller.Deputy(long, DateTime?, DateTime?, string, int?, PageSize?)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deputy_Method()
    {
      this.TestDeputyTranscriptsResult(this.xmlApiCaller.Transcripts().Deputy(id: 99100142, from: new DateTime(2013, 1, 1), to: new DateTime(2013, 12, 31), page: 2, limit: PageSize.Five));
      this.TestDeputyTranscriptsResult(this.jsonApiCaller.Transcripts().Deputy(id: 99100142, from: new DateTime(2013, 1, 1), to: new DateTime(2013, 12, 31), page: 2, limit: PageSize.Five));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptsApiCaller.Law(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Law_Method()
    {
      Assert.Throws<ArgumentNullException>(() => this.xmlApiCaller.Transcripts().Law(null));
      Assert.Throws<ArgumentException>(() => this.xmlApiCaller.Transcripts().Law(string.Empty));

      this.TestLawTranscriptsResult(this.xmlApiCaller.Transcripts().Law("140513-6"));
      this.TestLawTranscriptsResult(this.jsonApiCaller.Transcripts().Law("140513-6"));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptsApiCaller.Question(int, int)"/> method.</para>
    /// </summary>
    [Fact]
    public void Question_Method()
    {
      this.TestQuestionTranscriptsResult(this.xmlApiCaller.Transcripts().Question(80, 13));
      this.TestQuestionTranscriptsResult(this.jsonApiCaller.Transcripts().Question(80, 13));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptsApiCaller.Resolution(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Resolution_Method()
    {
      Assert.Throws<ArgumentNullException>(() => this.xmlApiCaller.Transcripts().Resolution(null));
      Assert.Throws<ArgumentException>(() => this.xmlApiCaller.Transcripts().Resolution(string.Empty));

      this.TestResolutionTranscriptsResult(this.xmlApiCaller.Transcripts().Resolution("276569-6"));
      this.TestResolutionTranscriptsResult(this.jsonApiCaller.Transcripts().Resolution("276569-6"));
    }

    private void TestDateTranscriptsResult(DateTranscriptsResult result)
    {
      Assertion.NotNull(result);

      Assert.Equal(new DateTime(2013, 5, 14), result.Date);

      var meetings = result.Meetings;
      Assert.True(meetings.Any());
      var meeting = meetings.Single(x => x.Number == 97);
      Assert.Equal(new DateTime(2013, 5, 14), meeting.Date);
      Assert.True(meeting.Text.Contains("ХРОНИКА"));
      Assert.True(meeting.Text.Contains("заседания Государственной Думы"));
      Assert.True(meeting.Text.Contains("14 мая 2013 года"));

      Assert.Equal(29, meeting.Votes.Count);

      var vote = meeting.Votes.First();
      Assert.Equal(6366, vote.Line);
      Assert.Equal(new DateTime(2013, 5, 14, 18, 16, 0), vote.Date);
    }

    private void TestDeputyTranscriptsResult(DeputyTranscriptsResult result)
    {
      Assertion.NotNull(result);

      Assert.Equal("Жириновский Владимир Вольфович", result.Name);
      Assert.Equal((int)PageSize.Five, result.PageSize);
      Assert.Equal(2, result.Page);
      Assert.True(result.Count > 0);

      var meetings = result.Meetings;
      Assert.True(meetings.Any());

      var meeting = meetings.Single(x => x.Number == 164);
      Assert.Equal(new DateTime(2014, 4, 22), meeting.Date);
      Assert.Equal(164, meeting.Number);
      Assert.Equal(7350, meeting.LinesCount);

      var question = meeting.Questions.Single();
      Assert.Equal("Об отчёте Правительства Российской Федерации о результатах его деятельности за 2013 год.", question.Name);
      Assert.Null(question.Stage);

      Assert.Equal(3, question.Parts.Count);
      var part = question.Parts.First();
      Assert.Equal(4099, part.StartLine);
      Assert.Equal(4262, part.EndLine);
      Assert.True(part.Text.Contains("ЖИРИНОВСКИЙ В. В., руководитель фракции ЛДПР."));
      Assert.False(part.Votes.Any());
    }

    private void TestLawTranscriptsResult(LawTranscriptsResult transcript)
    {
      Assertion.NotNull(transcript);

      Assert.Equal("140513-6", transcript.Number);
      Assert.Equal("О внесении изменений в главы 23 и 26 части второй Налогового кодекса Российской Федерации", transcript.Name);
      Assert.Equal("в части уточнения видов доходов, полученных от использования в Российской Федерации авторских или  смежных прав", transcript.Comments);

      var meetings = transcript.Meetings;
      Assert.True(meetings.Any());
      Assert.Equal(2, meetings.Count);

      var meeting = meetings.First();
      Assert.Equal(new DateTime(2013, 6, 21), meeting.Date);
      Assert.Equal(107, meeting.Number);
      Assert.Equal(8221, meeting.LinesCount);
      var question = meeting.Questions.Single();
      Assert.Equal(@"О проекте федерального закона № 140513-6 ""О внесении изменений в главы 23 и 26 части второй Налогового кодекса Российской Федерации"" (в части уточнения видов доходов от использования авторских или смежных прав; принят в первом чтении 15 мая 2013 года с наименованием ""О внесении изменений в статью 208 Налогового кодекса Российской Федерации"").", question.Name);
      Assert.Equal("Рассмотрение законопроекта во втором чтении", question.Stage);

      Assert.Equal(2, question.Parts.Count);

      var part = question.Parts[0];
      Assert.Equal(3501, part.StartLine);
      Assert.Equal(3544, part.EndLine);
      Assert.True(part.Text.Contains("Продолжаем работу. 29-й пункт порядка работы"));

      var vote = part.Votes.Single();
      Assert.Equal(3525, vote.Line);
      Assert.Equal(new DateTime(2013, 6, 21, 12, 34, 14), vote.Date);

      part = question.Parts[1];
      Assert.Equal(7210, part.StartLine);
      Assert.Equal(7246, part.EndLine);
      Assert.True(part.Text.Contains("29-й пункт порядка работы, проект федерального закона"));

      Assert.Equal(2, part.Votes.Count);
      
      vote = part.Votes[0];
      Assert.Equal(7218, vote.Line);
      Assert.Equal(new DateTime(2013, 6, 21, 16, 45, 15), vote.Date);

      vote = part.Votes[1];
      Assert.Equal(7237, vote.Line);
      Assert.Equal(new DateTime(2013, 6, 21, 16, 45, 44), vote.Date);
    }

    private void TestQuestionTranscriptsResult(QuestionTranscriptsResult result)
    {
      Assertion.NotNull(result);

      var meetings = result.Meetings;
      Assert.True(meetings.Any());

      var meeting = meetings.Single();
      Assert.Equal(new DateTime(1995, 1, 18), meeting.Date);
      Assert.Equal(80, meeting.Number);
      Assert.Equal(6711, meeting.LinesCount);

      var question = meeting.Questions.Single();
      Assert.Equal("О проекте постановления Государственной Думы о первоочередных мерах по образованию Счетной палаты Российской Федерации.", question.Name);
      Assert.Null(question.Stage);

      var part = question.Parts.Single();
      Assert.Equal(4372, part.StartLine);
      Assert.Equal(4424, part.EndLine);
      Assert.True(part.Text.Contains("ЗАДОРНОВ М.М. О Счетной палате?"));

      var vote = part.Votes.Single();
      Assert.Equal(4404, vote.Line);
      Assert.Equal(new DateTime(1995, 1, 18, 16, 18, 52), vote.Date);
    }

    private void TestResolutionTranscriptsResult(ResolutionTranscriptsResult result)
    {
      Assertion.NotNull(result);

      Assert.Equal("276569-6", result.Number);

      var meetings = result.Meetings;
      Assert.True(meetings.Any());
      
      var meeting = meetings.Single();
      Assert.Equal(new DateTime(2013, 5, 14), meeting.Date);
      Assert.Equal(97, meeting.Number);
      Assert.Equal(6563, meeting.LinesCount);

      var question = meeting.Questions.Single();
      Assert.Equal("О проекте постановления Государственной Думы \u2116 276569-6 \"О внесении изменений в план проведения \"правительственного часа\" на весеннюю сессию Государственной Думы 2013 года, утверждённый постановлением Государственной Думы Федерального Собрания Российской Федерации \"О плане проведения \"правительственного часа\" на весеннюю сессию Государственной Думы 2013 года\" (в части проведения \"правительственного часа\" 22 мая 2013 года).", question.Name);
      Assert.Null(question.Stage);

      Assert.Equal(2, question.Parts.Count);
      
      var part = question.Parts[0];
      Assert.Equal(1183, part.StartLine);
      Assert.Equal(1209, part.EndLine);
      Assert.True(part.Text.Contains("2-й вопрос, проект постановления Государственной Думы"));
      Assert.False(part.Votes.Any());

      part = question.Parts[1];
      Assert.Equal(4948, part.StartLine);
      Assert.Equal(4965, part.EndLine);
      Assert.True(part.Text.Contains("2-й пункт повестки, проект постановления Государственной Думы"));

      var vote = part.Votes.Single();
      Assert.Equal(4956, vote.Line);
      Assert.Equal(new DateTime(2013, 5, 14, 17, 4, 8), vote.Date);
    }
  }
}