using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Transcript of Duma's meeting.</para>
/// </summary>
public interface IDateTranscriptMeeting : IDateable, IComparable<IDateTranscriptMeeting>, IEquatable<IDateTranscriptMeeting>
{
  /// <summary>
  ///   <para>Number of meeting.</para>
  /// </summary>
  int? Number { get; }

  /// <summary>
  ///   <para>Transcript's text lines.</para>
  /// </summary>
  IEnumerable<string> Lines { get; }

  /// <summary>
  ///   <para>Meeting's votes.</para>
  /// </summary>
  IEnumerable<ITranscriptVote> Votes { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public string Text => Lines.Join(Environment.NewLine);
}