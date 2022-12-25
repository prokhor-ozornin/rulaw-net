namespace RuLaw;

/// <summary>
///   <para>Entry point for RuLaw API.</para>
/// </summary>
public interface IApi : IDisposable
{
  /// <summary>
  ///   <para>Returns API caller object to work with law branches.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  IBranchesApi Branches { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with law branches.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  ICommitteesApi Committees { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with deputies.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  IDeputiesApi Deputies { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with authorities.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  IAuthoritiesApi Authorities { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with instances.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  IInstancesApi Instances { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with laws.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  ILawsApi Laws { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with convocations.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  IConvocationsApi Convocations { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with questions.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  IQuestionsApi Questions { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with deputies requests.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  IRequestsApi Requests { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with laws review stages.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  IStagesApi Stages { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with topics.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  ITopicsApi Topics { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with transcripts.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  ITranscriptsApi Transcripts { get; }

  /// <summary>
  ///   <para>Returns API caller object to work with votes/votings.</para>
  /// </summary>
  /// <returns>API caller.</returns>
  IVotesApi Votes { get; }
}