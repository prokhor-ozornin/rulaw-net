using System.Net;
using System.Runtime.CompilerServices;
using Catharsis.Extensions;
using RestSharp;

namespace RuLaw;

internal sealed class Api : IApi
{
  private RestClient RestClient { get; } = new("http://api.duma.gov.ru/api".ToUri(), configureSerialization: config => config.UseSerializer<JsonRestSerializer>());
  private string ApiToken { get; }

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

  private bool disposed;

  public Api(string apiToken, string appToken = null)
  {
    if (appToken is not null)
    {
      RestClient.AddDefaultParameter("app_token", appToken);
    }

    ApiToken = apiToken;

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
    if (resource is null) throw new ArgumentNullException(nameof(resource));
    if (resource.IsEmpty()) throw new ArgumentException(nameof(resource));

    var request = new RestRequest($"{resource}.json")
    {
      RequestFormat = DataFormat.Json,
    };

    if (parameters is not null)
    {
      foreach (var parameter in parameters)
      {
        request.AddParameter(parameter.Key, parameter.Value?.ToInvariantString());
      }
    }

    var response = await RestClient.ExecuteGetAsync<T>(request, cancellation).ConfigureAwait(false);

    if (response.ErrorException is not null || response.StatusCode != HttpStatusCode.OK)
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

    if (error is not null && !error.Text.IsUnset())
    {
      throw new RuLawException(error);
    }

    return response.Data;
  }

  private sealed class BranchesApi : IBranchesApi
  {
    private Api Api { get; }

    public BranchesApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<ILawBranch> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<LawBranch>>($"/{Api.ApiToken}/classes", null, cancellation).ConfigureAwait(false);

      foreach (var branch in result.WithCancellation(cancellation))
      {
        yield return branch;
      }
    }
  }

  private sealed class CommitteesApi : ICommitteesApi
  {
    private Api Api { get; }

    public CommitteesApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<ICommittee> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Committee>>($"/{Api.ApiToken}/committees", null, cancellation).ConfigureAwait(false);

      foreach (var committee in result.WithCancellation(cancellation))
      {
        yield return committee;
      }
    }
  }

  private sealed class DeputiesApi : IDeputiesApi
  {
    private Api Api { get; }

    public DeputiesApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<IDeputyInfo> FindAsync(long id, CancellationToken cancellation = default) => (await Api.Request<DeputyInfo>($"/{Api.ApiToken}/deputy", new Dictionary<string, object> {{"id", id}}, cancellation).ConfigureAwait(false));

    public async IAsyncEnumerable<IDeputy> SearchAsync(IDeputiesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Deputy>>($"/{Api.ApiToken}/deputies", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var deputy in result.WithCancellation(cancellation))
      {
        yield return deputy;
      }
    }
  }

  private sealed class AuthoritiesApi : IAuthoritiesApi
  {
    private Api Api { get; }

    public AuthoritiesApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IAuthority> FederalAsync(IAuthoritiesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<FederalAuthority>>($"/{Api.ApiToken}/federal-organs", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var authority in result.WithCancellation(cancellation))
      {
        yield return authority;
      }
    }

    public async IAsyncEnumerable<IAuthority> RegionalAsync(IAuthoritiesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<RegionalAuthority>>($"/{Api.ApiToken}/regional-organs", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var authority in result.WithCancellation(cancellation))
      {
        yield return authority;
      }
    }
  }

  private sealed class InstancesApi : IInstancesApi
  {
    private Api Api { get; }

    public InstancesApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IInstance> SearchAsync(IInstancesApiRequest request = null, [EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Instance>>($"/{Api.ApiToken}/instances", request?.Parameters, cancellation).ConfigureAwait(false);

      foreach (var instance in result.WithCancellation(cancellation))
      {
        yield return instance;
      }
    }
  }

  private sealed class LawsApi : ILawsApi
  {
    private Api Api { get; }

    public LawsApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<ILawsSearchResult> SearchAsync(ILawsApiRequest request, CancellationToken cancellation = default)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));
      
      return (await Api.Request<LawsSearchResult>($"/{Api.ApiToken}/search", request.Parameters, cancellation).ConfigureAwait(false));
    }
  }

  private sealed class ConvocationsApi : IConvocationsApi
  {
    private Api Api { get; }

    public ConvocationsApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IConvocation> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Convocation>>($"/{Api.ApiToken}/periods", null, cancellation).ConfigureAwait(false);

      foreach (var convocation in result.WithCancellation(cancellation))
      {
        yield return convocation;
      }
    }
  }

  private sealed class QuestionsApi : IQuestionsApi
  {
    private Api Api { get; }

    public QuestionsApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<IQuestionsSearchResult> SearchAsync(IQuestionsApiRequest request = null, CancellationToken cancellation = default) => (await Api.Request<QuestionsSearchResult>($"/{Api.ApiToken}/questions", request?.Parameters, cancellation).ConfigureAwait(false));
  }

  private sealed class RequestsApi : IRequestsApi
  {
    private Api Api { get; }

    public RequestsApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IDeputyRequest> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<DeputyRequest>>($"/{Api.ApiToken}/requests", null, cancellation).ConfigureAwait(false);

      foreach (var request in result.WithCancellation(cancellation))
      {
        yield return request;
      }
    }
  }

  private sealed class StagesApi : IStagesApi
  {
    private Api Api { get; }

    public StagesApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<IPhaseStage> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<PhaseStage>>($"/{Api.ApiToken}/stages", null, cancellation).ConfigureAwait(false);

      foreach (var stage in result.WithCancellation(cancellation))
      {
        yield return stage;
      }
    }
  }

  private sealed class TopicsApi : ITopicsApi
  {
    private Api Api { get; }

    public TopicsApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async IAsyncEnumerable<ITopic> AllAsync([EnumeratorCancellation] CancellationToken cancellation = default)
    {
      var result = await Api.Request<List<Topic>>($"/{Api.ApiToken}/topics", null, cancellation).ConfigureAwait(false);

      foreach (var topic in result.WithCancellation(cancellation))
      {
        yield return topic;
      }
    }
  }

  private sealed class TranscriptsApi : ITranscriptsApi
  {
    private Api Api { get; }

    public TranscriptsApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<IDateTranscriptsResult> DateAsync(DateTimeOffset date, CancellationToken cancellation = default) => (await Api.Request<DateTranscriptsResult>($"/{Api.ApiToken}/transcriptFull/{date.AsString()}", null, cancellation).ConfigureAwait(false));

    public async Task<IDeputyTranscriptsResult> DeputyAsync(IDeputyTranscriptApiRequest request, CancellationToken cancellation = default) => (await Api.Request<DeputyTranscriptsResult>($"/{Api.ApiToken}/transcriptDeputy/{request.Parameters["deputy"]}", request.Parameters, cancellation).ConfigureAwait(false));

    public async Task<ILawTranscriptsResult> LawAsync(string number, CancellationToken cancellation = default) => (await Api.Request<LawTranscriptsResult>($"/{Api.ApiToken}/transcript/{number}", null, cancellation).ConfigureAwait(false));

    public async Task<IQuestionTranscriptsResult> QuestionAsync(long meeting, long question, CancellationToken cancellation = default) => (await Api.Request<QuestionTranscriptsResult>($"/{Api.ApiToken}/transcriptQuestion/{meeting}/{question}", null, cancellation).ConfigureAwait(false));

    public async Task<IResolutionTranscriptsResult> ResolutionAsync(string number, CancellationToken cancellation = default) => (await Api.Request<ResolutionTranscriptsResult>($"/{Api.ApiToken}/transcriptResolution/{number}", null, cancellation).ConfigureAwait(false));
  }

  private sealed class VotesApi : IVotesApi
  {
    private Api Api { get; }

    public VotesApi(Api api) => Api = api ?? throw new ArgumentNullException(nameof(api));

    public async Task<IVotesSearchResult> SearchAsync(IVotesSearchApiRequest request, CancellationToken cancellation = default) => (await Api.Request<VotesSearchResult>($"/{Api.ApiToken}/voteSearch", request.Parameters, cancellation).ConfigureAwait(false));
  }
}