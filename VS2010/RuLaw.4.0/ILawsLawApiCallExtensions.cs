using System;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ILawsLawApiCall"/>.</para>
  /// </summary>
  /// <seealso cref="ILawsLawApiCall"/>
  public static class ILawsLawApiCallExtensions
  {
    /// <summary>
    ///   <para>Specifies law branch.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="branch">Instance of law branch.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="branch"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Branch(this ILawsLawApiCall call, LawBranch branch)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(branch);

      return call.Branch(branch.Id);
    }

    /// <summary>
    ///   <para>Specifies deputy.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="deputy">Instance of deputy.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="deputy"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Deputy(this ILawsLawApiCall call, Deputy deputy)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(deputy);

      return call.Deputy(deputy.Id);
    }

    /// <summary>
    ///   <para>Specifies federal authority.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="authority">Instance of authority.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="authority"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall FederalAuthority(this ILawsLawApiCall call, FederalAuthority authority)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(authority);

      return call.FederalAuthority(authority.Id);
    }

    /// <summary>
    ///   <para>Specifies type of laws.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="type">Type of laws.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="call"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Type(this ILawsLawApiCall call, LawTypes type)
    {
      Assertion.NotNull(call);

      return call.Type((int) type);
    }

    /// <summary>
    ///   <para>Specifies type of laws sorting.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="sort">Laws sorting type.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="call"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Sorting(this ILawsLawApiCall call, LawsSorting sort)
    {
      Assertion.NotNull(call);

      switch (sort)
      {
        case LawsSorting.DateAscending:
          return call.Sorting("date_asc");

        case LawsSorting.DateDescending:
          return call.Sorting("date");

        case LawsSorting.LastEventDateAscending:
          return call.Sorting("last_event_date_asc");

        case LawsSorting.Name:
          return call.Sorting("name");

        case LawsSorting.Number:
          return call.Sorting("number");

        case LawsSorting.ResponsibleCommittee:
          return call.Sorting("responsible_committee");

        default:
          return call.Sorting("last_event_date");
      }
    }

    /// <summary>
    ///   <para>Specifies law's status.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="status">Status of laws.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="call"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Status(this ILawsLawApiCall call, LawStatus status)
    {
      Assertion.NotNull(call);

      return call.Status((int) status);
    }

    /// <summary>
    ///   <para>Specifies profile committee.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="committee">Instance of committee.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="committee"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall ProfileCommittee(this ILawsLawApiCall call, Committee committee)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(committee);

      return call.ProfileCommittee(committee.Id);
    }

    /// <summary>
    ///   <para>Specifies regional authority.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="authority">Instance of authority.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="authority"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall RegionalAuthority(this ILawsLawApiCall call, RegionalAuthority authority)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(authority);

      return call.RegionalAuthority(authority.Id);
    }

    /// <summary>
    ///   <para>Specifies responsible committee.</para>
    /// </summary>
    /// <param name="committee">Instance of committee.</param>
    /// <param name="call">API call instance to use.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="committee"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall ResponsibleCommittee(this ILawsLawApiCall call, Committee committee)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(committee);

      return call.ResponsibleCommittee(committee.Id);
    }

    /// <summary>
    ///   <para>Specifies so-executor committee.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="committee">Instance of committee.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="committee"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall SoExecutorCommittee(this ILawsLawApiCall call, Committee committee)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(committee);

      return call.SoExecutorCommittee(committee.Id);
    }

    /// <summary>
    ///   <para>Specifies topic.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="topic">Instance of topic.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="topic"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Topic(this ILawsLawApiCall call, Topic topic)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(topic);

      return call.Topic(topic.Id);
    }

    /// <summary>
    ///   <para>Specifies events search mode.</para>
    /// </summary>
    /// <param name="call">API call instance to use.</param>
    /// <param name="mode">Events search mode.</param>
    /// <returns>Back reference to the provided <paramref name="call"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="call"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall EventsSearchMode(this ILawsLawApiCall call, LawsEventsSearchMode mode)
    {
      Assertion.NotNull(call);

      return call.EventsSearchMode((int)mode);
    }
  }
}