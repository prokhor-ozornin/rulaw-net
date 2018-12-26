namespace RuLaw
{
  using System.Collections.Generic;

  /// <summary>
  ///   <para>Transcript of Duma's law.</para>
  /// </summary>
  public interface ILawTranscriptsResult : INameable
  {
    /// <summary>
    ///   <para>Law's comments.</para>
    /// </summary>
    string Comments { get; }

    /// <summary>
    ///   <para>List of law's associated meetings.</para>
    /// </summary>
    IEnumerable<ITranscriptMeeting> Meetings { get; }

    /// <summary>
    ///   <para>Number of law.</para>
    /// </summary>
    string Number { get; }
  }
}