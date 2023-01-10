using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Question of Duma's session.</para>
/// </summary>
public sealed class Question : IQuestion
{
  /// <summary>
  ///   <para>Title of question.</para>
  /// </summary>
  public string Name { get; }

  /// <summary>
  ///   <para>Date of session.</para>
  /// </summary>
  public DateTimeOffset? Date { get; }

  /// <summary>
  ///   <para>Code of question.</para>
  /// </summary>
  public int? Code { get; }

  /// <summary>
  ///   <para>Code of session.</para>
  /// </summary>
  public int? SessionCode { get; }

  /// <summary>
  ///   <para>First line in question's transcript.</para>
  /// </summary>
  public int? StartLine { get; }

  /// <summary>
  ///   <para>Last line in question's transcript.</para>
  /// </summary>
  public int? EndLine { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="name"></param>
  /// <param name="date"></param>
  /// <param name="code"></param>
  /// <param name="sessionCode"></param>
  /// <param name="startLine"></param>
  /// <param name="endLine"></param>
  public Question(string name = null,
                  DateTimeOffset? date = null,
                  int? code = null,
                  int? sessionCode = null,
                  int? startLine = null,
                  int? endLine = null)
  {
    Name = name;
    Date = date;
    Code = code;
    SessionCode = sessionCode;
    StartLine = startLine;
    EndLine = endLine;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Question(Info info)
  {
    Name = info.Name;
    Date = info.Date != null ? DateTimeOffset.Parse(info.Date) : null;
    Code = info.Code;
    SessionCode = info.SessionCode;
    StartLine = info.StartLine;
    EndLine = info.EndLine;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Question(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="IQuestion"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IQuestion"/> to compare with this instance.</param>
  public int CompareTo(IQuestion other) => Name.Compare(other?.Name);

  /// <summary>
  ///   <para>Determines whether two <see cref="IQuestion"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IQuestion other) => this.Equality(other, nameof(Code), nameof(SessionCode));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IQuestion);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Code), nameof(SessionCode));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Question"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Question"/>.</returns>
  public override string ToString() => Name ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "question")]
  public sealed record Info : IResultable<IQuestion>
  {
    /// <summary>
    ///   <para>Title of question.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string Name { get; init; }

    /// <summary>
    ///   <para>Date of session.</para>
    /// </summary>
    [DataMember(Name = "datez", IsRequired = true)]
    public string Date { get; init; }

    /// <summary>
    ///   <para>Code of question.</para>
    /// </summary>
    [DataMember(Name = "kodvopr", IsRequired = true)]
    public int? Code { get; init; }

    /// <summary>
    ///   <para>Code of session.</para>
    /// </summary>
    [DataMember(Name = "kodz", IsRequired = true)]
    public int? SessionCode { get; init; }

    /// <summary>
    ///   <para>First line in question's transcript.</para>
    /// </summary>
    [DataMember(Name = "nbegin", IsRequired = true)]
    public int? StartLine { get; init; }

    /// <summary>
    ///   <para>Last line in question's transcript.</para>
    /// </summary>
    [DataMember(Name = "nend", IsRequired = true)]
    public int? EndLine { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IQuestion ToResult() => new Question(this);
  }
}