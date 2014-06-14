using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="LawTranscriptsResult"/>.</para>
  /// </summary>
  /// <seealso cref="LawTranscriptsResult"/>
  public static class LawTranscriptExtensions
  {
    /// <summary>
    ///   <para>Searches for a transcript of law with a specified number and returns it.</para>
    /// </summary>
    /// <param name="transcripts">Source sequence of laws transcripts for searching.</param>
    /// <param name="number">Unique number of law to search for (case-insensitive).</param>
    /// <returns>Transcript of law with a specified number, or a <c>null</c> reference if it could not be found.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="transcripts"/> or <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    public static LawTranscriptsResult Number(this IEnumerable<LawTranscriptsResult> transcripts, string number)
    {
      Assertion.NotNull(transcripts);
      Assertion.NotEmpty(number);

      return transcripts.FirstOrDefault(transcript => transcript != null && string.Equals(transcript.Number, number, StringComparison.InvariantCultureIgnoreCase));
    }
  }
}