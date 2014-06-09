namespace RuLaw
{
  /// <summary>
  ///   <para>Способ сортировки результатов</para>
  /// </summary>
  public enum LawsSorting
  {
    /// <summary>
    ///   <para>По названию законопроекта</para>
    /// </summary>
    Name,
    
    /// <summary>
    ///   <para>По номеру законопроекта</para>
    /// </summary>
    Number,

    /// <summary>
    ///   <para>По дате внесения в ГД (по убыванию)</para>
    /// </summary>
    DateDescending,

    /// <summary>
    ///   <para>По дате внесения в ГД (по возрастанию)</para>
    /// </summary>
    DateAscending,

    /// <summary>
    ///   <para>По дате последнего события (по убыванию)</para>
    /// </summary>
    LastEventDateDescending,

    /// <summary>
    ///   <para>По дате последнего события (по возрастанию)</para>
    /// </summary>
    LastEventDateAscending,

    /// <summary>
    ///   <para>По ответственному комитету</para>
    /// </summary>
    ResponsibleCommittee
  }
}