namespace RuLaw
{
  using System;
  using System.Globalization;
  using System.Collections.Generic;
  using Catharsis.Commons;

  internal sealed class TranscriptsApiCaller : ITranscriptsApiCaller
  {
    private readonly IApiCaller caller;

    public IApiCaller Api
    {
      get { return caller; }
    }

    public TranscriptsApiCaller(IApiCaller caller)
    {
      Assertion.NotNull(caller);

      this.caller = caller;
    }

    public IDateTranscriptsResult Date(DateTime date)
    {
      return caller.Call<DateTranscriptsResult>(string.Format(CultureInfo.InvariantCulture, "/{0}/transcriptFull/{1}", caller.ApiToken, date.RuLawDate())).Data;
    }

    public IDeputyTranscriptsResult Deputy(long id, DateTime? from = null, DateTime? to = null, string name = null, int? page = null, PageSize? limit = null)
    {
      return caller.Call<DeputyTranscriptsResult>(string.Format(CultureInfo.InvariantCulture, "/{0}/transcriptDeputy/{1}", caller.ApiToken, id), new Dictionary<string, object> { { "dateFrom", from != null ? from.Value.RuLawDate() : null}, { "dateTo", to != null ? to.Value.RuLawDate() : null }, { "name", name }, { "page", page }, { "limit", (int?) limit } }).Data;
    }

    public ILawTranscriptsResult Law(string number)
    {
      Assertion.NotEmpty(number);

      return caller.Call<LawTranscriptsResult>(string.Format(CultureInfo.InvariantCulture, "/{0}/transcript/{1}", caller.ApiToken, number)).Data;
    }

    public IQuestionTranscriptsResult Question(int meeting, int question)
    {
      return caller.Call<QuestionTranscriptsResult>(string.Format(CultureInfo.InvariantCulture, "/{0}/transcriptQuestion/{1}/{2}", caller.ApiToken, meeting, question)).Data;
    }

    public IResolutionTranscriptsResult Resolution(string number)
    {
      Assertion.NotEmpty(number);

      return caller.Call<ResolutionTranscriptsResult>(string.Format(CultureInfo.InvariantCulture, "/{0}/transcriptResolution/{1}", caller.ApiToken, number)).Data;
    }
  }
}