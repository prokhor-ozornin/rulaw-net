using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ITranscriptsApiCallerExtensions"/>.</para>
  /// </summary>
  public sealed class ITranscriptsApiCallerExtensionsTests
  {
    private readonly IApiCaller xmlApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Xml));
    private readonly IApiCaller jsonApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Json));

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ITranscriptsApiCallerExtensions.Deputy(ITranscriptsApiCaller, Action{IDeputyTranscriptLawApiCall})"/> method.</description></item>
    ///     <item><description><see cref="ITranscriptsApiCallerExtensions.Deputy(ITranscriptsApiCaller, Action{IDeputyTranscriptLawApiCall}, out IDeputyTranscriptsResult)"/> method.</description></item>
    ///   </list>
    /// </summary>
    [Fact(Skip = "")]
    public void Deputy_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ITranscriptsApiCallerExtensions.Deputy(null, x => { }));
      Assert.Throws<ArgumentNullException>(() => this.xmlApiCaller.Transcripts().Deputy(null));
      Assert.Throws<KeyNotFoundException>(() => this.xmlApiCaller.Transcripts().Deputy(x => { }));

      IDeputyTranscriptsResult result;
      var call = (Action<IDeputyTranscriptLawApiCall>) (x => x.Deputy(99100142).From(new DateTime(2013, 1, 1)).To(new DateTime(2013, 12, 31)).Page(2).PageSize(PageSize.Five));

      this.TestDeputyTranscriptsResult(this.xmlApiCaller.Transcripts().Deputy(call));
      Assert.True(this.xmlApiCaller.Transcripts().Deputy(call, out result));
      this.TestDeputyTranscriptsResult(result);

      this.TestDeputyTranscriptsResult(this.jsonApiCaller.Transcripts().Deputy(call));
      Assert.True(this.jsonApiCaller.Transcripts().Deputy(call, out result));
      this.TestDeputyTranscriptsResult(result);
    }

    private void TestDeputyTranscriptsResult(IDeputyTranscriptsResult result)
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

      Assert.Equal(3, question.Parts.Count());
      var part = question.Parts.First();
      Assert.Equal(4099, part.StartLine);
      Assert.Equal(4262, part.EndLine);
      Assert.True(part.Text().Contains("ЖИРИНОВСКИЙ В. В., руководитель фракции ЛДПР."));
      Assert.False(part.Votes.Any());
    }
  }
}