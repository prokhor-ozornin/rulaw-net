using System.Runtime.Serialization;
using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma law's resolution.</para>
/// </summary>
public sealed class ResolutionTranscriptsResult : IResolutionTranscriptsResult
{
  /// <summary>
  ///   <para>Number of resolution.</para>
  /// </summary>
  public string Number { get; }

  /// <summary>
  ///   <para>Collection of Duma's meetings.</para>
  /// </summary>
  public IEnumerable<ITranscriptMeeting> Meetings { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="number"></param>
  /// <param name="meetings"></param>
  public ResolutionTranscriptsResult(string number = null,
                                     IEnumerable<ITranscriptMeeting> meetings = null)
  {
    Number = number;
    Meetings = meetings ?? new List<ITranscriptMeeting>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public ResolutionTranscriptsResult(Info info)
  {
    Number = info.Number;
    Meetings = info.Meetings ?? new List<TranscriptMeeting>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public ResolutionTranscriptsResult(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Determines whether two <see cref="IResolutionTranscriptsResult"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IResolutionTranscriptsResult other) => this.Equality(other, nameof(Number));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IResolutionTranscriptsResult);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Number));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="ResolutionTranscriptsResult"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="ResolutionTranscriptsResult"/>.</returns>
  public override string ToString() => Number ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "result")]
  public sealed record Info : IResultable<IResolutionTranscriptsResult>
  {
    /// <summary>
    ///   <para>Number of resolution.</para>
    /// </summary>
    [DataMember(Name = "number", IsRequired = true)]
    public string Number { get; init; }

    /// <summary>
    ///   <para>Collection of Duma's meetings.</para>
    /// </summary>
    [DataMember(Name = "meetings", IsRequired = true)]
    public List<TranscriptMeeting> Meetings { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IResolutionTranscriptsResult ToResult() => new ResolutionTranscriptsResult(this);
  }
}