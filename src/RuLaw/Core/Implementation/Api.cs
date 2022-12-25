using System.Net;
using System.Runtime.CompilerServices;
using Catharsis.Commons;
using RestSharp;

namespace RuLaw;

internal sealed class Api : IApi
{
  private bool disposed;

  private Uri EndpointUrl { get; } = "http://api.duma.gov.ru/api".ToUri();
  private RestClient RestClient { get; }

  public string ApiToken { get; }
  public string? AppToken { get; }

  public IBranchesApi Branches { get; }
  public ICommitteesApi Committees { get; }
  public IDeputiesApi Deputies { get; }
  public IAuthoritiesApi Authorities { get; }
  public IInstancesApi Instances { get; }
  public ILawsApi Laws { get; }
  public IConvocationsApi Convocations { get; }
  public IQuestionsApi Questions { get; }
  public IRequestsApi Requests { get; }
  public IStagesApi Stages { get; }
  public ITopicsApi Topics { get; }
  public ITranscriptsApi Transcripts { get; }
  public IVotesApi Votes { get; }

  public Api(string apiToken, string? appToken = null)
  {
    ApiToken = apiToken;
    AppToken = appToken;

    RestClient = new RestClient(EndpointUrl);
    RestClient.Options.BaseUrl = EndpointUrl;
    RestClient.UseSerializer<JsonRestSerializer>();
    if (appToken != null)
    {
      RestClient.AddDefaultParameter("app_token", appToken);
    }

    Branches = new BranchesApi(this);
    Committees = new CommitteesApi(this);
    Deputies = new DeputiesApi(this);
    Authorities = new AuthoritiesApi(this);
    Instances = new InstancesApi(this);
    Laws = new LawsApi(this);
    Convocations = new ConvocationsApi(this);
    Questions = new QuestionsApi(this);
    Requests = new RequestsApi(this);
    Stages = new StagesApi(this);
    Topics = new TopicsApi(this);
    Transcripts = new TranscriptsApi(this);
    Votes = new VotesApi(this);
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  private void Dispose(bool disposing)
  {
    if (!disposing || disposed)
    {
      return;
    }

    RestClient.Dispose();

    disposed = true;
  }

  private async Task<T> Request<T>(string resource, IDictionary<string, object?>? parameters = null, CancellationToken cancellation = default) where T : new()
  {
    var request = new RestRequest($"{resource}.json")
    {
      RequestFormat = DataFormat.Json,
    };

    if (parameters != null)
    {
      foreach (var parameter in parameters)
      {
        request.AddParameter(parameter.Key, parameter.Value?.ToStringInvariant());
      }
    }

    var response = await RestClient.ExecuteGetAsync<T>(request, cancellation);

    if (response.ErrorException != null || response.StatusCode != HttpStatusCode.OK)
    {
      var responseError = new Error((int) response.StatusCode, response.ErrorMessage ?? (response.StatusDescription ?? response.StatusCode.ToStringInvariant()));
      throw new RuLawException(responseError, response.ErrorException);
    }

    Error? error = null;

    try
    {
      error = response.Content.AsJson<Error>();
    }
    catch
    {
    }

    if (error != null && !error.Text.IsEmpty())
    {
      throw new RuLawException(error);
    }

    return response.Data;
  }

  private sealed class BranchesApi : IBranchesApi
  {
    private Api Api { get; }

    public BranchesApi(Api api) => Api = api;

    public async IAsyncEnumerable<ILawBranch> All([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var branch in await Api.Request<List<LawBranch.Info>>($"/{Api.ApiToken}/classes", null, cancellation))
      {
        yield return branch.Result();
      }
    }
  }

  private sealed class CommitteesApi : ICommitteesApi
  {
    private Api Api { get; }

    public CommitteesApi(Api api) => Api = api;

    public async IAsyncEnumerable<ICommittee> All([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var committee in await Api.Request<List<Committee.Info>>($"/{Api.ApiToken}/committees", null, cancellation))
      {
        yield return committee.Result();
      }
    }
  }

  private sealed class DeputiesApi : IDeputiesApi
  {
    private Api Api { get; }

    public DeputiesApi(Api api) => Api = api;

    public async Task<IDeputyInfo> Find(long id, CancellationToken cancellation = default) => (await Api.Request<DeputyInfo.Info>($"/{Api.ApiToken}/deputy", new Dictionary<string, object?> {{"id", id}}, cancellation)).Result();

    public async IAsyncEnumerable<IDeputy> Search(IDeputiesApiRequest? request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var deputy in await Api.Request<List<Deputy.Info>>($"/{Api.ApiToken}/deputies", request?.Parameters, cancellation))
      {
        yield return deputy.Result();
      }
    }
  }

  private sealed class AuthoritiesApi : IAuthoritiesApi
  {
    private Api Api { get; }

    public AuthoritiesApi(Api api) => Api = api;

    public async IAsyncEnumerable<IAuthority> Federal(IAuthoritiesApiRequest? request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var authority in await Api.Request<List<FederalAuthority.Info>>($"/{Api.ApiToken}/federal-organs", request?.Parameters, cancellation))
      {
        yield return authority.Result();
      }
    }

    public async IAsyncEnumerable<IAuthority> Regional(IAuthoritiesApiRequest? request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var authority in await Api.Request<List<RegionalAuthority.Info>>($"/{Api.ApiToken}/regional-organs", request?.Parameters, cancellation))
      {
        yield return authority.Result();
      }
    }
  }

  private sealed class InstancesApi : IInstancesApi
  {
    private Api Api { get; }

    public InstancesApi(Api api) => Api = api;

    public async IAsyncEnumerable<IInstance> Search(IInstancesApiRequest? request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var instance in await Api.Request<List<Instance.Info>>($"/{Api.ApiToken}/instances", request?.Parameters, cancellation))
      {
        yield return instance.Result();
      }
    }
  }

  private sealed class LawsApi : ILawsApi
  {
    private Api Api { get; }

    public LawsApi(Api api) => Api = api;

    public async Task<ILawsSearchResult> Search(ILawsApiRequest request, CancellationToken cancellation = default) => (await Api.Request<LawsSearchResult.Info>($"/{Api.ApiToken}/search", request.Parameters, cancellation)).Result();
  }

  private sealed class ConvocationsApi : IConvocationsApi
  {
    private Api Api { get; }

    public ConvocationsApi(Api api) => Api = api;

    public async IAsyncEnumerable<IConvocation> All([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var convocation in await Api.Request<List<Convocation.Info>>($"/{Api.ApiToken}/periods", null, cancellation))
      {
        yield return convocation.Result();
      }
    }
  }

  private sealed class QuestionsApi : IQuestionsApi
  {
    private Api Api { get; }

    public QuestionsApi(Api api) => Api = api;

    public async Task<IQuestionsSearchResult> Search(IQuestionsApiRequest? request = null, CancellationToken cancellation = default) => (await Api.Request<QuestionsSearchResult.Info>($"/{Api.ApiToken}/questions", request?.Parameters, cancellation)).Result();
  }

  private sealed class RequestsApi : IRequestsApi
  {
    private Api Api { get; }

    public RequestsApi(Api api) => Api = api;

    public async IAsyncEnumerable<IDeputyRequest> All([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var request in await Api.Request<List<DeputyRequest.Info>>($"/{Api.ApiToken}/requests", null, cancellation))
      {
        yield return request.Result();
      }
    }
  }

  private sealed class StagesApi : IStagesApi
  {
    private Api Api { get; }

    public StagesApi(Api api) => Api = api;

    public async IAsyncEnumerable<IPhaseStage> All([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var stage in await Api.Request<List<PhaseStage.Info>>($"/{Api.ApiToken}/stages", null, cancellation))
      {
        yield return stage.Result();
      }
    }
  }

  private sealed class TopicsApi : ITopicsApi
  {
    private Api Api { get; }

    public TopicsApi(Api api) => Api = api;

    public async IAsyncEnumerable<ITopic> All([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      foreach (var topic in await Api.Request<List<Topic.Info>>($"/{Api.ApiToken}/topics", null, cancellation))
      {
        yield return topic.Result();
      }
    }
  }

  private sealed class TranscriptsApi : ITranscriptsApi
  {
    private Api Api { get; }

    public TranscriptsApi(Api api) => Api = api;

    public async Task<IDateTranscriptsResult> Date(DateTimeOffset date, CancellationToken cancellation = default) => (await Api.Request<DateTranscriptsResult.Info>($"/{Api.ApiToken}/transcriptFull/{date.AsString()}", null, cancellation)).Result();

    public async Task<IDeputyTranscriptsResult> Deputy(IDeputyTranscriptApiRequest request, CancellationToken cancellation = default) => (await Api.Request<DeputyTranscriptsResult.Info>($"/{Api.ApiToken}/transcriptDeputy/{request.Parameters["deputy"]}", request.Parameters, cancellation)).Result();

    public async Task<ILawTranscriptsResult> Law(string number, CancellationToken cancellation = default) => (await Api.Request<LawTranscriptsResult.Info>($"/{Api.ApiToken}/transcript/{number}", null, cancellation)).Result();

    public async Task<IQuestionTranscriptsResult> Question(long meeting, long question, CancellationToken cancellation = default) => (await Api.Request<QuestionTranscriptsResult.Info>($"/{Api.ApiToken}/transcriptQuestion/{meeting}/{question}", null, cancellation)).Result();

    public async Task<IResolutionTranscriptsResult> Resolution(string number, CancellationToken cancellation = default) => (await Api.Request<ResolutionTranscriptsResult.Info>($"/{Api.ApiToken}/transcriptResolution/{number}", null, cancellation)).Result();
  }

  private sealed class VotesApi : IVotesApi
  {
    private Api Api { get; }

    public VotesApi(Api api) => Api = api;

    public async Task<IVotesSearchResult> Search(IVotesSearchApiRequest request, CancellationToken cancellation = default) => (await Api.Request<VotesSearchResult.Info>($"/{Api.ApiToken}/voteSearch", request.Parameters, cancellation)).Result();
  }
}