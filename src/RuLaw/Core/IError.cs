namespace RuLaw;

/// <summary>
///   <para>RuLaw API call error.</para>
/// </summary>
public interface IError : IComparable<IError>, IEquatable<IError>
{
  /// <summary>
  ///   <para>Numeric code of error.</para>
  /// </summary>
  public int Code { get; }

  /// <summary>
  ///   <para>Text description of error.</para>
  /// </summary>
  public string Text { get; }
}