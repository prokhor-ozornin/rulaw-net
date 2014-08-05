using System;
using System.Collections.Generic;
using Catharsis.Commons;

namespace RuLaw
{
  internal sealed class TranscriptsApiCaller : ITranscriptsApiCaller
  {
    private readonly IApiCaller caller;

    public IApiCaller Api
    {
      get { return this.caller; }
    }

    public TranscriptsApiCaller(IApiCaller caller)
    {
      Assertion.NotNull(caller);

      this.caller = caller;
    }

    public IDateTranscriptsResult Date(DateTime date)
    {
      return this.caller.Call<DateTranscriptsResult>("/{0}/transcriptFull/{1}".FormatSelf(this.caller.ApiToken, date.RuLawDate())).Data;
    }

    public IDeputyTranscriptsResult Deputy(long id, DateTime? from = null, DateTime? to = null, string name = null, int? page = null, PageSize? limit = null)
    {
      return this.caller.Call<DeputyTranscriptsResult>("/{0}/transcriptDeputy/{1}".FormatSelf(this.caller.ApiToken, id), new Dictionary<string, object> { { "dateFrom", from != null ? from.Value.RuLawDate() : null}, { "dateTo", to != null ? to.Value.RuLawDate() : null }, { "name", name }, { "page", page }, { "limit", (int?) limit } }).Data;
    }

    public ILawTranscriptsResult Law(string number)
    {
      Assertion.NotEmpty(number);

      return this.caller.Call<LawTranscriptsResult>("/{0}/transcript/{1}".FormatSelf(this.caller.ApiToken, number)).Data;
    }

    public IQuestionTranscriptsResult Question(int meeting, int question)
    {
      return this.caller.Call<QuestionTranscriptsResult>("/{0}/transcriptQuestion/{1}/{2}".FormatSelf(this.caller.ApiToken, meeting, question)).Data;
    }

    public IResolutionTranscriptsResult Resolution(string number)
    {
      Assertion.NotEmpty(number);

      return this.caller.Call<ResolutionTranscriptsResult>("/{0}/transcriptResolution/{1}".FormatSelf(this.caller.ApiToken, number)).Data;
    }
  }
}