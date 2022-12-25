namespace RuLaw;

/// <summary>
///   <para>Duma's law.</para>
/// </summary>
public interface ILaw : IEntity, IDateable, INameable, IComparable<ILaw>, IEquatable<ILaw>
{
  /// <summary>
  ///   <para>Number of law.</para>
  /// </summary>
  string? Number { get; }

  /// <summary>
  ///   <para>Subject of law.</para>
  /// </summary>
  ILawSubject? Subject { get; }

  /// <summary>
  ///   <para>Type of law.</para>
  /// </summary>
  ILawType? Type { get; }

  /// <summary>
  ///   <para>URL address of law in ASOZD system.</para>
  /// </summary>
  string? Url { get; }

  /// <summary>
  ///   <para>URL address of law's transcript.</para>
  /// </summary>
  string? TranscriptUrl { get; }

  /// <summary>
  ///   <para>Law comments.</para>
  /// </summary>
  string? Comments { get; }

  /// <summary>
  ///   <para>Last event, associated with a law.</para>
  /// </summary>
  ILawEvent? LastEvent { get; }

  /// <summary>
  ///   <para>Committees, associated with a law.</para>
  /// </summary>
  ILawCommittees? Committees { get; }
}