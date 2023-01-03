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
  public string AppToken { get; }

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

  public Api(string apiToken, string appToken = null)
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

  private async Task<T> Request<T>(string resource, IReadOnlyDictionary<string, object> parameters = null, CancellationToken cancellation = default) where T : new()
  {
    var request = new RestRequest($"{resource}.json")
    {
      RequestFormat = DataFormat.Json,
    };

    if (parameters != null)
    {
      foreach (var parameter in parameters)
      {
        request.AddParameter(parameter.Key, parameter.Value?.ToInvariantString());
      }
    }

    var response = await RestClient.ExecuteGetAsync<T>(request, cancellation).ConfigureAwait(false);

    if (response.ErrorException != null || response.StatusCode != HttpStatusCode.OK)
    {
      var responseError = new Error((int) response.StatusCode, response.ErrorMessage ?? (response.StatusDescription ?? response.StatusCode.ToInvariantString()));
      throw new RuLawException(responseError, response.ErrorException);
    }

    Error error = null;

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

    public async IAsyncEnumerable<ILawBranch> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<LawBranch.Info>>($"/{Api.ApiToken}/classes", null, cancellation).ConfigureAwait(false);

      foreach (var branch in result.WithCancellation(cancellation))
      {
        yield return branch.ToResult();
      }
    }
  }

  private sealed class CommitteesApi : ICommitteesApi
  {
    private Api Api { get; }

    public CommitteesApi(Api api) => Api = api;

    public async IAsyncEnumerable<ICommittee> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Committee.Info>>($"/{Api.ApiToken}/committees", null, cancellation).ConfigureAwait(false);

      foreach (var committee in result.WithCancellation(cancellation))
      {
        yield return committee.ToResult();
      }
    }
  }

  private sealed class DeputiesApi : IDeputiesApi
  {
    private Api Api { get; }

    public DeputiesApi(Api api) => Api = api;

    public async Task<IDeputyInfo> FindAsync(long id, CancellationToken cancellation = default) => (await Api.Request<DeputyInfo.Info>($"/{Api.ApiToken}/deputy", new Dictionary<string, object> {{"id", id}}, cancellation).ConfigureAwait(false)).ToResult();

    public async IAsyncEnumerable<IDeputy> SearchAsync(IDeputiesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Deputy.Info>>($"/{Api.ApiToken}/deputies", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var deputy in result.WithCancellation(cancellation))
      {
        yield return deputy.ToResult();
      }
    }
  }

  private sealed class AuthoritiesApi : IAuthoritiesApi
  {
    private Api Api { get; }

    public AuthoritiesApi(Api api) => Api = api;

    public async IAsyncEnumerable<IAuthority> FederalAsync(IAuthoritiesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<FederalAuthority.Info>>($"/{Api.ApiToken}/federal-organs", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var authority in result.WithCancellation(cancellation))
      {
        yield return authority.ToResult();
      }
    }

    public async IAsyncEnumerable<IAuthority> RegionalAsync(IAuthoritiesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<RegionalAuthority.Info>>($"/{Api.ApiToken}/regional-organs", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var authority in result.WithCancellation(cancellation))
      {
        yield return authority.ToResult();
      }
    }
  }

  private sealed class InstancesApi : IInstancesApi
  {
    private Api Api { get; }

    public InstancesApi(Api api) => Api = api;

    public async IAsyncEnumerable<IInstance> SearchAsync(IInstancesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Instance.Info>>($"/{Api.ApiToken}/instances", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var instance in result.WithCancellation(cancellation))
      {
        yield return instance.ToResult();
      }
    }
  }

  private sealed class LawsApi : ILawsApi
  {
    private Api Api { get; }

    public LawsApi(Api api) => Api = api;

    public async Task<ILawsSearchResult> SearchAsync(ILawsApiRequest request, CancellationToken cancellation = default) => (await Api.Request<LawsSearchResult.Info>($"/{Api.ApiToken}/search", request.Parameters, cancellation).ConfigureAwait(false)).ToResult();
  }

  private sealed class ConvocationsApi : IConvocationsApi
  {
    private Api Api { get; }

    public ConvocationsApi(Api api) => Api = api;

    public async IAsyncEnumerable<IConvocation> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Convocation.Info>>($"/{Api.ApiToken}/periods", null, cancellation).ConfigureAwait(false);

      foreach (var convocation in result.WithCancellation(cancellation))
      {
        yield return convocation.ToResult();
      }
    }
  }

  private sealed class QuestionsApi : IQuestionsApi
  {
    private Api Api { get; }

    public QuestionsApi(Api api) => Api = api;

    public async Task<IQuestionsSearchResult> SearchAsync(IQuestionsApiRequest request = null, CancellationToken cancellation = default) => (await Api.Request<QuestionsSearchResult.Info>($"/{Api.ApiToken}/questions", request?.Parameters, cancellation).ConfigureAwait(false)).ToResult();
  }

  private sealed class RequestsApi : IRequestsApi
  {
    private Api Api { get; }

    public RequestsApi(Api api) => Api = api;

    public async IAsyncEnumerable<IDeputyRequest> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<DeputyRequest.Info>>($"/{Api.ApiToken}/requests", null, cancellation).ConfigureAwait(false);

      foreach (var request in result.WithCancellation(cancellation))
      {
        yield return request.ToResult();
      }
    }
  }

  private sealed class StagesApi : IStagesApi
  {
    private Api Api { get; }

    public StagesApi(Api api) => Api = api;

    public async IAsyncEnumerable<IPhaseStage> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<PhaseStage.Info>>($"/{Api.ApiToken}/stages", null, cancellation).ConfigureAwait(false);

      foreach (var stage in result.WithCancellation(cancellation))
      {
        yield return stage.ToResult();
      }
    }
  }

  private sealed class TopicsApi : ITopicsApi
  {
    private Api Api { get; }

    public TopicsApi(Api api) => Api = api;

    public async IAsyncEnumerable<ITopic> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Topic.Info>>($"/{Api.ApiToken}/topics", null, cancellation).ConfigureAwait(false);

      foreach (var topic in result.WithCancellation(cancellation))
      {
        yield return topic.ToResult();
      }
    }
  }

  private sealed class TranscriptsApi : ITranscriptsApi
  {
    private Api Api { get; }

    public TranscriptsApi(Api api) => Api = api;

    public async Task<IDateTranscriptsResult> DateAsync(DateTimeOffset date, CancellationToken cancellation = default) => (await Api.Request<DateTranscriptsResult.Info>($"/{Api.ApiToken}/transcriptFull/{date.AsString()}", null, cancellation).ConfigureAwait(false)).ToResult();

    public async Task<IDeputyTranscriptsResult> DeputyAsync(IDeputyTranscriptApiRequest request, CancellationToken cancellation = default) => (await Api.Request<DeputyTranscriptsResult.Info>($"/{Api.ApiToken}/transcriptDeputy/{request.Parameters["deputy"]}", request.Parameters, cancellation).ConfigureAwait(false)).ToResult();

    public async Task<ILawTranscriptsResult> LawAsync(string number, CancellationToken cancellation = default) => (await Api.Request<LawTranscriptsResult.Info>($"/{Api.ApiToken}/transcript/{number}", null, cancellation).ConfigureAwait(false)).ToResult();

    public async Task<IQuestionTranscriptsResult> QuestionAsync(long meeting, long question, CancellationToken cancellation = default) => (await Api.Request<QuestionTranscriptsResult.Info>($"/{Api.ApiToken}/transcriptQuestion/{meeting}/{question}", null, cancellation).ConfigureAwait(false)).ToResult();

    public async Task<IResolutionTranscriptsResult> ResolutionAsync(string number, CancellationToken cancellation = default) => (await Api.Request<ResolutionTranscriptsResult.Info>($"/{Api.ApiToken}/transcriptResolution/{number}", null, cancellation).ConfigureAwait(false)).ToResult();
  }

  private sealed class VotesApi : IVotesApi
  {
    private Api Api { get; }

    public VotesApi(Api api) => Api = api;

    public async Task<IVotesSearchResult> SearchAsync(IVotesSearchApiRequest request, CancellationToken cancellation = default) => (await Api.Request<VotesSearchResult.Info>($"/{Api.ApiToken}/voteSearch", request.Parameters, cancellation).ConfigureAwait(false)).ToResult();
  }
}