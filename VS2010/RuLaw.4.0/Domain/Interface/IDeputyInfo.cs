using System;
using System.Collections.Generic;

namespace RuLaw
{
  /// <summary>
  ///   <para>Detailed deputy information.</para>
  /// </summary>
  public interface IDeputyInfo : IEntity, IActive
  {
    /// <summary>
    ///   <para>Collection of deputy's activities in committees.</para>
    /// </summary>
    IEnumerable<IDeputyActivity> Activities { get; }

    /// <summary>
    ///   <para>Birth date of deputy.</para>
    /// </summary>
    DateTime BirthDate { get; }

    /// <summary>
    ///   <para>Scientific degrees of deputy.</para>
    /// </summary>
    IEnumerable<string> Degrees { get; }

    /// <summary>
    ///   <para>Higher educations of deputy.</para>
    /// </summary>
    IEnumerable<IEducation> Educations { get; }

    /// <summary>
    ///   <para>Identifier of deputy's political faction.</para>
    /// </summary>
    long FactionId { get; }

    /// <summary>
    ///   <para>Name of deputy's political faction.</para>
    /// </summary>
    string FactionName { get; }

    /// <summary>
    ///   <para>Association of deputy's political faction with a region.</para>
    /// </summary>
    string FactionRegion { get; }

    /// <summary>
    ///   <para>Role of deputy's in his political faction.</para>
    /// </summary>
    string FactionRole { get; }

    /// <summary>
    ///   <para>First name of deputy.</para>
    /// </summary>
    string FirstName { get; }

    /// <summary>
    ///   <para>Last name of deputy.</para>
    /// </summary>
    string LastName { get; }

    /// <summary>
    ///   <para>Number of laws which have been initiated by the deputy.</para>
    /// </summary>
    int LawsCount { get; }

    /// <summary>
    ///   <para>Middle name of deputy.</para>
    /// </summary>
    string MiddleName { get; }

    /// <summary>
    ///   <para>Scientific ranks of deputy.</para>
    /// </summary>
    IEnumerable<string> Ranks { get; }

    /// <summary>
    ///   <para>Association of deputy's with regions.</para>
    /// </summary>
    IEnumerable<string> Regions { get; }

    /// <summary>
    ///   <para>Number of deputy's public speaches.</para>
    /// </summary>
    int SpeachesCount { get; }

    /// <summary>
    ///   <para>URL link for transcripts of deputy's speaches.</para>
    /// </summary>
    string TranscriptLink { get; }

    /// <summary>
    ///   <para>URL link for deputy's votes.</para>
    /// </summary>
    string VoteLink { get; }

    /// <summary>
    ///   <para>Start date of deputy's authorities in last convocation.</para>
    /// </summary>
    DateTime WorkStartDate { get; }

    /// <summary>
    ///   <para>End date of deputy's authorities in last convocation.</para>
    /// </summary>
    DateTime? WorkEndDate { get; }
  }
}