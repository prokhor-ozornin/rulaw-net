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
      var call = (Action<IDeputyTranscriptLawApiCall>) (x => x.Deputy(99100142).From(new DateTime(2014, 1, 1)).To(new DateTime(2014, 12, 31)).Page(1).PageSize(PageSize.Ten));

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
      Assert.Equal((int)PageSize.Ten, result.PageSize);
      Assert.Equal(1, result.Page);
      Assert.True(result.Count > 0);

      var meetings = result.Meetings;
      Assert.NotEmpty(meetings);

      var meeting = meetings.Single(x => x.Number == 202);
      Assert.Equal(new DateTime(2014, 12, 9), meeting.Date);
      Assert.Equal(202, meeting.Number);
      Assert.Equal(7627, meeting.LinesCount);

      var question = meeting.Questions.Single();
      Assert.Equal("О проекте порядка работы Государственной Думы на 9 декабря 2014 года.", question.Name);
      Assert.Null(question.Stage);

      Assert.Equal(5, question.Parts.Count());
      var part = question.Parts.First();
      Assert.Equal(1106, part.StartLine);
      Assert.Equal(1117, part.EndLine);
      Assert.Contains("ЖИРИНОВСКИЙ В. В., руководитель фракции ЛДПР.", part.Text());
      Assert.Empty(part.Votes);
    }
  }
}