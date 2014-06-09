using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface ILawsLawApiCall : ILawApiCall, IPagedLawApiCall<ILawsLawApiCall>
  {
    /// <summary>
    ///   <para>Отрасль законодательства</para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ILawsLawApiCall Branch(long id);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ILawsLawApiCall Deputy(long id);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    ILawsLawApiCall DocumentNumber(string number);

    /// <summary>
    ///   <para>Федеральный орган власти</para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ILawsLawApiCall FederalAuthority(long id);

    /// <summary>
    ///   <para>Тип законопроекта</para>
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    ILawsLawApiCall Type(int type);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="sort"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="sort"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="sort"/> is <see cref="string.Empty"/> string.</exception>
    ILawsLawApiCall Sorting(string sort);

    /// <summary>
    ///   <para>Статус законопроекта</para>
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    ILawsLawApiCall Status(int status);
    
    /// <summary>
    ///   <para>Название законопроекта</para>
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Если <paramref name="name"/> является <c>null</c> ссылкой</exception>
    /// <exception cref="ArgumentException">Если <paramref name="name"/> является <seealso cref="string.Empty"/> строкой.</exception>
    ILawsLawApiCall Name(string name);

    /// <summary>
    ///   <para>Номер законопроекта</para>
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Если <paramref name="number"/> является <c>null</c> ссылкой</exception>
    /// <exception cref="ArgumentException">Если <paramref name="number"/> является <see cref="string.Empty"/> строкой.</exception>
    ILawsLawApiCall Number(string number);

    /// <summary>
    ///   <para>Профильный комитет</para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ILawsLawApiCall ProfileCommittee(long id);

    /// <summary>
    ///   <para>Региональный орган власти</para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ILawsLawApiCall RegionalAuthority(long id);

    /// <summary>
    ///   <para>Максимальная дата регистрации законопроекта</para>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    ILawsLawApiCall RegistrationEnd(DateTime date);

    /// <summary>
    ///   <para>Минимальная дата регистрации законопроекта</para>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    ILawsLawApiCall RegistrationStart(DateTime date);

    /// <summary>
    ///   <para>Ответственный комитет</para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ILawsLawApiCall ResponsibleCommittee(long id);

    /// <summary>
    ///   <para>Комитет соисполнитель</para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ILawsLawApiCall SoExecutorCommittee(long id);

    /// <summary>
    ///   <para>Режим поиска по событиям законопроекта</para>
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    ILawsLawApiCall EventsSearchMode(int mode);

    /// <summary>
    ///   <para>Тематический блок</para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ILawsLawApiCall Topic(long id);
  }
}