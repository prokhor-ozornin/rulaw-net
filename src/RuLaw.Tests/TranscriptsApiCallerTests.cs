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
      TestDateTranscriptsResult(xmlApiCaller.Transcripts().Date(new DateTime(2013, 5, 14)));
      TestDateTranscriptsResult(jsonApiCaller.Transcripts().Date(new DateTime(2013, 5, 14)));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptsApiCaller.Deputy(long, DateTime?, DateTime?, string, int?, PageSize?)"/> method.</para>
    /// </summary>
    [Fact(Skip = "")]
    public void Deputy_Method()
    {
      TestDeputyTranscriptsResult(xmlApiCaller.Transcripts().Deputy(id: 99100142));
      TestDeputyTranscriptsResult(jsonApiCaller.Transcripts().Deputy(id: 99100142));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptsApiCaller.Law(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Law_Method()
    {
      Assert.Throws<ArgumentNullException>(() => xmlApiCaller.Transcripts().Law(null));
      Assert.Throws<ArgumentException>(() => xmlApiCaller.Transcripts().Law(string.Empty));

      TestLawTranscriptsResult(xmlApiCaller.Transcripts().Law("140513-6"));
      TestLawTranscriptsResult(jsonApiCaller.Transcripts().Law("140513-6"));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptsApiCaller.Question(int, int)"/> method.</para>
    /// </summary>
    [Fact]
    public void Question_Method()
    {
      TestQuestionTranscriptsResult(xmlApiCaller.Transcripts().Question(80, 13));
      TestQuestionTranscriptsResult(jsonApiCaller.Transcripts().Question(80, 13));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptsApiCaller.Resolution(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Resolution_Method()
    {
      Assert.Throws<ArgumentNullException>(() => xmlApiCaller.Transcripts().Resolution(null));
      Assert.Throws<ArgumentException>(() => xmlApiCaller.Transcripts().Resolution(string.Empty));

      TestResolutionTranscriptsResult(xmlApiCaller.Transcripts().Resolution("276569-6"));
      TestResolutionTranscriptsResult(jsonApiCaller.Transcripts().Resolution("276569-6"));
    }

    private void TestDateTranscriptsResult(IDateTranscriptsResult result)
    {
      Assertion.NotNull(result);

      Assert.Equal(new DateTime(2013, 5, 14), result.Date);

      var meetings = result.Meetings;
      Assert.NotEmpty(meetings);
      var meeting = meetings.Single(x => x.Number == 97);
      Assert.Equal(new DateTime(2013, 5, 14), meeting.Date);
      Assert.Contains("ХРОНИКА", meeting.Text());
      Assert.Contains("заседания Государственной Думы", meeting.Text());
      Assert.Contains("14 мая 2013 года", meeting.Text());

      Assert.Equal(29, meeting.Votes.Count());

      var vote = meeting.Votes.First();
      Assert.Equal(6366, vote.Line);
      Assert.Equal(new DateTime(2013, 5, 14, 18, 16, 0), vote.Date);
    }

    private void TestDeputyTranscriptsResult(IDeputyTranscriptsResult result)
    {
      Assertion.NotNull(result);

      Assert.Equal("Жириновский Владимир Вольфович", result.Name);
      Assert.Equal((int)PageSize.Twenty, result.PageSize);
      Assert.Equal(1, result.Page);
      Assert.True(result.Count > 0);

      var meetings = result.Meetings;
      Assert.NotEmpty(meetings);

      var meeting = meetings.First();
      Assert.True(meeting.Date <= DateTime.UtcNow);
      Assert.True(meeting.LinesCount > 0);
      Assert.True(meeting.Number > 0);
      Assert.NotEmpty(meeting.Questions);
    }

    private void TestLawTranscriptsResult(ILawTranscriptsResult transcript)
    {
      Assertion.NotNull(transcript);

      Assert.Equal("140513-6", transcript.Number);
      Assert.Equal("О внесении изменений в главы 23 и 26 части второй Налогового кодекса Российской Федерации", transcript.Name);
      Assert.Equal("в части уточнения видов доходов, полученных от использования в Российской Федерации авторских или  смежных прав", transcript.Comments);

      var meetings = transcript.Meetings;
      Assert.NotEmpty(meetings);
      Assert.Equal(2, meetings.Count());

      var meeting = meetings.First();
      Assert.Equal(new DateTime(2013, 6, 21), meeting.Date);
      Assert.Equal(107, meeting.Number);
      Assert.Equal(8221, meeting.LinesCount);
      var question = meeting.Questions.Single();
      Assert.Equal(@"О проекте федерального закона № 140513-6 ""О внесении изменений в главы 23 и 26 части второй Налогового кодекса Российской Федерации"" (в части уточнения видов доходов от использования авторских или смежных прав; принят в первом чтении 15 мая 2013 года с наименованием ""О внесении изменений в статью 208 Налогового кодекса Российской Федерации"").", question.Name);
      Assert.Equal("Рассмотрение законопроекта во втором чтении", question.Stage);

      Assert.Equal(2, question.Parts.Count());

      var part = question.Parts.ElementAt(0);
      Assert.Equal(3501, part.StartLine);
      Assert.Equal(3544, part.EndLine);
      Assert.Contains("Продолжаем работу. 29-й пункт порядка работы", part.Text());

      var vote = part.Votes.Single();
      Assert.Equal(3525, vote.Line);
      Assert.Equal(new DateTime(2013, 6, 21, 12, 34, 14), vote.Date);

      part = question.Parts.ElementAt(1);
      Assert.Equal(7210, part.StartLine);
      Assert.Equal(7246, part.EndLine);
      Assert.Contains("29-й пункт порядка работы, проект федерального закона", part.Text());

      Assert.Equal(2, part.Votes.Count());
      
      vote = part.Votes.ElementAt(0);
      Assert.Equal(7218, vote.Line);
      Assert.Equal(new DateTime(2013, 6, 21, 16, 45, 15), vote.Date);

      vote = part.Votes.ElementAt(1);
      Assert.Equal(7237, vote.Line);
      Assert.Equal(new DateTime(2013, 6, 21, 16, 45, 44), vote.Date);
    }

    private void TestQuestionTranscriptsResult(IQuestionTranscriptsResult result)
    {
      Assertion.NotNull(result);

      var meetings = result.Meetings;
      Assert.NotEmpty(meetings);

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
      Assert.Contains("ЗАДОРНОВ М.М. О Счетной палате?", part.Text());

      var vote = part.Votes.Single();
      Assert.Equal(4404, vote.Line);
      Assert.Equal(new DateTime(1995, 1, 18, 16, 18, 52), vote.Date);
    }

    private void TestResolutionTranscriptsResult(IResolutionTranscriptsResult result)
    {
      Assertion.NotNull(result);

      Assert.Equal("276569-6", result.Number);

      var meetings = result.Meetings;
      Assert.NotEmpty(meetings);
      
      var meeting = meetings.Single();
      Assert.Equal(new DateTime(2013, 5, 14), meeting.Date);
      Assert.Equal(97, meeting.Number);
      Assert.Equal(6563, meeting.LinesCount);

      var question = meeting.Questions.Single();
      Assert.Equal("О проекте постановления Государственной Думы \u2116 276569-6 \"О внесении изменений в план проведения \"правительственного часа\" на весеннюю сессию Государственной Думы 2013 года, утверждённый постановлением Государственной Думы Федерального Собрания Российской Федерации \"О плане проведения \"правительственного часа\" на весеннюю сессию Государственной Думы 2013 года\" (в части проведения \"правительственного часа\" 22 мая 2013 года).", question.Name);
      Assert.Null(question.Stage);

      Assert.Equal(2, question.Parts.Count());
      
      var part = question.Parts.ElementAt(0);
      Assert.Equal(1183, part.StartLine);
      Assert.Equal(1209, part.EndLine);
      Assert.Contains("2-й вопрос, проект постановления Государственной Думы", part.Text());
      Assert.Empty(part.Votes);

      part = question.Parts.ElementAt(1);
      Assert.Equal(4948, part.StartLine);
      Assert.Equal(4965, part.EndLine);
      Assert.Contains("2-й пункт повестки, проект постановления Государственной Думы", part.Text());

      var vote = part.Votes.Single();
      Assert.Equal(4956, vote.Line);
      Assert.Equal(new DateTime(2013, 5, 14, 17, 4, 8), vote.Date);
    }
  }
}