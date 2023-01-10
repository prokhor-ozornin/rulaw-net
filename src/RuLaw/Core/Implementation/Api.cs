using System.Net;
using System.Runtime.CompilerServices;
using Catharsis.Extensions;
using RestSharp;

namespace RuLaw;

internal sealed class Api : IApi
{
  private bool disposed;

  private readonly Uri endpointUrl = "http://api.duma.gov.ru/api".ToUri();
  private readonly RestClient restClient;
  private readonly string apiToken;

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
    this.apiToken = apiToken;

    restClient = new RestClient(endpointUrl);
    restClient.Options.BaseUrl = endpointUrl;
    restClient.UseSerializer<JsonRestSerializer>();
    if (appToken != null)
    {
      restClient.AddDefaultParameter("app_token", appToken);
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

    restClient.Dispose();

    disposed = true;
  }

  private async Task<T> Request<T>(string resource, IReadOnlyDictionary<string, object> parameters = null, CancellationToken cancellation = default) where T : new()
  {
    if (resource is null) throw new ArgumentNullException(nameof(resource));
    if (resource.IsEmpty()) throw new ArgumentException(nameof(resource));

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

    var response = await restClient.ExecuteGetAsync<T>(request, cancellation).ConfigureAwait(false);

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
    private readonly Api api;

    public BranchesApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<ILawBranch> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<LawBranch.Info>>($"/{api.apiToken}/classes", null, cancellation).ConfigureAwait(false);

      foreach (var branch in result.WithCancellation(cancellation))
      {
        yield return branch.ToResult();
      }
    }
  }

  private sealed class CommitteesApi : ICommitteesApi
  {
    private readonly Api api;

    public CommitteesApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<ICommittee> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<Committee.Info>>($"/{api.apiToken}/committees", null, cancellation).ConfigureAwait(false);

      foreach (var committee in result.WithCancellation(cancellation))
      {
        yield return committee.ToResult();
      }
    }
  }

  private sealed class DeputiesApi : IDeputiesApi
  {
    private readonly Api api;

    public DeputiesApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<IDeputyInfo> FindAsync(long id, CancellationToken cancellation = default) => (await api.Request<DeputyInfo.Info>($"/{api.apiToken}/deputy", new Dictionary<string, object> {{"id", id}}, cancellation).ConfigureAwait(false)).ToResult();

    public async IAsyncEnumerable<IDeputy> SearchAsync(IDeputiesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<Deputy.Info>>($"/{api.apiToken}/deputies", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var deputy in result.WithCancellation(cancellation))
      {
        yield return deputy.ToResult();
      }
    }
  }

  private sealed class AuthoritiesApi : IAuthoritiesApi
  {
    private readonly Api api;

    public AuthoritiesApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IAuthority> FederalAsync(IAuthoritiesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<FederalAuthority.Info>>($"/{api.apiToken}/federal-organs", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var authority in result.WithCancellation(cancellation))
      {
        yield return authority.ToResult();
      }
    }

    public async IAsyncEnumerable<IAuthority> RegionalAsync(IAuthoritiesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<RegionalAuthority.Info>>($"/{api.apiToken}/regional-organs", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var authority in result.WithCancellation(cancellation))
      {
        yield return authority.ToResult();
      }
    }
  }

  private sealed class InstancesApi : IInstancesApi
  {
    private readonly Api api;

    public InstancesApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IInstance> SearchAsync(IInstancesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<Instance.Info>>($"/{api.apiToken}/instances", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var instance in result.WithCancellation(cancellation))
      {
        yield return instance.ToResult();
      }
    }
  }

  private sealed class LawsApi : ILawsApi
  {
    private readonly Api api;

    public LawsApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<ILawsSearchResult> SearchAsync(ILawsApiRequest request, CancellationToken cancellation = default)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));
      
      return (await api.Request<LawsSearchResult.Info>($"/{api.apiToken}/search", request.Parameters, cancellation).ConfigureAwait(false)).ToResult();
    }
  }

  private sealed class ConvocationsApi : IConvocationsApi
  {
    private readonly Api api;

    public ConvocationsApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IConvocation> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<Convocation.Info>>($"/{api.apiToken}/periods", null, cancellation).ConfigureAwait(false);

      foreach (var convocation in result.WithCancellation(cancellation))
      {
        yield return convocation.ToResult();
      }
    }
  }

  private sealed class QuestionsApi : IQuestionsApi
  {
    private readonly Api api;

    public QuestionsApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<IQuestionsSearchResult> SearchAsync(IQuestionsApiRequest request = null, CancellationToken cancellation = default) => (await api.Request<QuestionsSearchResult.Info>($"/{api.apiToken}/questions", request?.Parameters, cancellation).ConfigureAwait(false)).ToResult();
  }

  private sealed class RequestsApi : IRequestsApi
  {
    private readonly Api api;

    public RequestsApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IDeputyRequest> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<DeputyRequest.Info>>($"/{api.apiToken}/requests", null, cancellation).ConfigureAwait(false);

      foreach (var request in result.WithCancellation(cancellation))
      {
        yield return request.ToResult();
      }
    }
  }

  private sealed class StagesApi : IStagesApi
  {
    private readonly Api api;

    public StagesApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IPhaseStage> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<PhaseStage.Info>>($"/{api.apiToken}/stages", null, cancellation).ConfigureAwait(false);

      foreach (var stage in result.WithCancellation(cancellation))
      {
        yield return stage.ToResult();
      }
    }
  }

  private sealed class TopicsApi : ITopicsApi
  {
    private Api api;

    public TopicsApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<ITopic> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await api.Request<List<Topic.Info>>($"/{api.apiToken}/topics", null, cancellation).ConfigureAwait(false);

      foreach (var topic in result.WithCancellation(cancellation))
      {
        yield return topic.ToResult();
      }
    }
  }

  private sealed class TranscriptsApi : ITranscriptsApi
  {
    private readonly Api api;

    public TranscriptsApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<IDateTranscriptsResult> DateAsync(DateTimeOffset date, CancellationToken cancellation = default) => (await api.Request<DateTranscriptsResult.Info>($"/{api.apiToken}/transcriptFull/{date.AsString()}", null, cancellation).ConfigureAwait(false)).ToResult();

    public async Task<IDeputyTranscriptsResult> DeputyAsync(IDeputyTranscriptApiRequest request, CancellationToken cancellation = default) => (await api.Request<DeputyTranscriptsResult.Info>($"/{api.apiToken}/transcriptDeputy/{request.Parameters["deputy"]}", request.Parameters, cancellation).ConfigureAwait(false)).ToResult();

    public async Task<ILawTranscriptsResult> LawAsync(string number, CancellationToken cancellation = default) => (await api.Request<LawTranscriptsResult.Info>($"/{api.apiToken}/transcript/{number}", null, cancellation).ConfigureAwait(false)).ToResult();

    public async Task<IQuestionTranscriptsResult> QuestionAsync(long meeting, long question, CancellationToken cancellation = default) => (await api.Request<QuestionTranscriptsResult.Info>($"/{api.apiToken}/transcriptQuestion/{meeting}/{question}", null, cancellation).ConfigureAwait(false)).ToResult();

    public async Task<IResolutionTranscriptsResult> ResolutionAsync(string number, CancellationToken cancellation = default) => (await api.Request<ResolutionTranscriptsResult.Info>($"/{api.apiToken}/transcriptResolution/{number}", null, cancellation).ConfigureAwait(false)).ToResult();
  }

  private sealed class VotesApi : IVotesApi
  {
    private readonly Api api;

    public VotesApi(Api api) => this.api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<IVotesSearchResult> SearchAsync(IVotesSearchApiRequest request, CancellationToken cancellation = default) => (await api.Request<VotesSearchResult.Info>($"/{api.apiToken}/voteSearch", request.Parameters, cancellation).ConfigureAwait(false)).ToResult();
  }
}