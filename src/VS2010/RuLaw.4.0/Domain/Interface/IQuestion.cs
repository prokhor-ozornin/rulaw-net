namespace RuLaw
{
  /// <summary>
  ///   <para>Question of Duma's session.</para>
  /// </summary>
  public interface IQuestion : INameable, IDateable
  {
    /// <summary>
    ///   <para>Code of question.</para>
    /// </summary>
    int Code { get; }

    /// <summary>
    ///   <para>Last line in question's transcript.</para>
    /// </summary>
    int EndLine { get; }

    /// <summary>
    ///   <para>Code of session.</para>
    /// </summary>
    int SessionCode { get; }

    /// <summary>
    ///   <para>First line in question's transcript.</para>
    /// </summary>
    int StartLine { get; }
  }
}