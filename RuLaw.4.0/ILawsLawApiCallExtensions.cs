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
    ///   <para>Отрасль законодательства</para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="branch"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="branch"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Branch(this ILawsLawApiCall call, LawBranch branch)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(branch);

      return call.Branch(branch.Id);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="deputy"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="deputy"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Deputy(this ILawsLawApiCall call, Deputy deputy)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(deputy);

      return call.Deputy(deputy.Id);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="authority"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="authority"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall FederalAuthority(this ILawsLawApiCall call, FederalAuthority authority)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(authority);

      return call.FederalAuthority(authority.Id);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="call"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Type(this ILawsLawApiCall call, LawTypes type)
    {
      Assertion.NotNull(call);

      return call.Type((int) type);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="sort"></param>
    /// <returns></returns>
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
    ///   <para></para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="call"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Status(this ILawsLawApiCall call, LawStatus status)
    {
      Assertion.NotNull(call);

      return call.Status((int) status);
    }

    /// <summary>
    ///   <para>Профильный комитет</para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="committee"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="committee"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall ProfileCommittee(this ILawsLawApiCall call, Committee committee)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(committee);

      return call.ProfileCommittee(committee.Id);
    }

    /// <summary>
    ///   <para>Региональный орган власти</para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="authority"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="authority"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall RegionalAuthority(this ILawsLawApiCall call, RegionalAuthority authority)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(authority);

      return call.RegionalAuthority(authority.Id);
    }

    /// <summary>
    ///   <para>Ответственный комитет</para>
    /// </summary>
    /// <param name="committee"></param>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="committee"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall ResponsibleCommittee(this ILawsLawApiCall call, Committee committee)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(committee);

      return call.ResponsibleCommittee(committee.Id);
    }

    /// <summary>
    ///   <para>Комитет соисполнитель</para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="committee"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="committee"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall SoExecutorCommittee(this ILawsLawApiCall call, Committee committee)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(committee);

      return call.SoExecutorCommittee(committee.Id);
    }

    /// <summary>
    ///   <para>Тематический блок</para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="topic"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="call"/> or <paramref name="topic"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall Topic(this ILawsLawApiCall call, Topic topic)
    {
      Assertion.NotNull(call);
      Assertion.NotNull(topic);

      return call.Topic(topic.Id);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="call"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="call"/> is a <c>null</c> reference.</exception>
    public static ILawsLawApiCall EventsSearchMode(this ILawsLawApiCall call, LawsEventsSearchMode mode)
    {
      Assertion.NotNull(call);

      return call.EventsSearchMode((int)mode);
    }
  }
}