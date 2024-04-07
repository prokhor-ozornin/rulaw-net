using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Deputy's request.</para>
/// </summary>
public sealed class DeputyRequest : IDeputyRequest
{
  /// <summary>
  ///   <para>Unique identifier of deputy's request.</para>
  /// </summary>
  public long? Id { get; }

  /// <summary>
  ///   <para>Name of deputy request.</para>
  /// </summary>
  public string Name { get; }

  /// <summary>
  ///   <para>Date when deputy's request was initiated.</para>
  /// </summary>
  public DateTimeOffset? Date { get; }

  /// <summary>
  ///   <para>Number of associated document.</para>
  /// </summary>
  public string DocumentNumber { get; }

  /// <summary>
  ///   <para>Initiator person of deputy request.</para>
  /// </summary>
  public string Initiator { get; }

  /// <summary>
  ///   <para>Addressee of deputy's request.</para>
  /// </summary>
  public IDeputyRequestAddressee Addressee { get; }

  /// <summary>
  ///   <para>Text of answer for deputy's request.</para>
  /// </summary>
  public string Answer { get; }

  /// <summary>
  ///   <para>Person who signed deputy's request.</para>
  /// </summary>
  public IDeputyRequestSigner Signer { get; }

  /// <summary>
  ///   <para>Date when deputy's request was signed.</para>
  /// </summary>
  public DateTimeOffset? SignDate { get; }

  /// <summary>
  ///   <para>Date when deputy's request was in control stage.</para>
  /// </summary>
  public DateTimeOffset? ControlDate { get; }

  /// <summary>
  ///   <para>Number of associated resolution.</para>
  /// </summary>
  public string ResolutionNumber { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="date"></param>
  /// <param name="documentNumber"></param>
  /// <param name="initiator"></param>
  /// <param name="addressee"></param>
  /// <param name="answer"></param>
  /// <param name="signer"></param>
  /// <param name="signDate"></param>
  /// <param name="controlDate"></param>
  /// <param name="resolutionNumber"></param>
  public DeputyRequest(long? id = null,
                       string name = null,
                       DateTimeOffset? date = null,
                       string documentNumber = null,
                       string initiator = null,
                       IDeputyRequestAddressee addressee = null,
                       string answer = null,
                       IDeputyRequestSigner signer = null,
                       DateTimeOffset? signDate = null,
                       DateTimeOffset? controlDate = null,
                       string resolutionNumber = null)
  {
    Id = id;
    Name = name;
    Date = date;
    DocumentNumber = documentNumber;
    Initiator = initiator;
    Addressee = addressee;
    Answer = answer;
    Signer = signer;
    SignDate = signDate;
    ControlDate = controlDate;
    ResolutionNumber = resolutionNumber;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyRequest(Info info)
  {
    Id = info.Id;
    Name = info.Name;
    Date = info.Date;
    DocumentNumber = info.DocumentNumber;
    Initiator = info.Initiator;
    Addressee = info.Addressee;
    Answer = info.Answer;
    Signer = info.Signer;
    SignDate = info.SignDate is not null ? DateTimeOffset.Parse(info.SignDate) : null;
    ControlDate = info.ControlDate is not null ? DateTimeOffset.Parse(info.ControlDate) : null;
    ResolutionNumber = info.ResolutionNumber;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public DeputyRequest(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="IDeputyRequest"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IDeputyRequest"/> to compare with this instance.</param>
  public int CompareTo(IDeputyRequest other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="IDeputyRequest"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(IDeputyRequest other) => this.Equality(other, nameof(Id));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as IDeputyRequest);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Id));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyRequest"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="DeputyRequest"/>.</returns>
  public override string ToString() => Name ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "request")]
  public sealed record Info : IResultable<IDeputyRequest>
  {
    /// <summary>
    ///   <para>Unique identifier of deputy's request.</para>
    /// </summary>
    [DataMember(Name = "requestId", IsRequired = true)]
    public long? Id { get; init; }

    /// <summary>
    ///   <para>Name of deputy request.</para>
    /// </summary>
    [DataMember(Name = "name", IsRequired = true)]
    public string Name { get; init; }

    /// <summary>
    ///   <para>Date when deputy's request was initiated.</para>
    /// </summary>
    [DataMember(Name = "date", IsRequired = true)]
    public DateTimeOffset? Date { get; init; }

    /// <summary>
    ///   <para>Number of associated document.</para>
    /// </summary>
    [DataMember(Name = "documentNumber", IsRequired = true)]
    public string DocumentNumber { get; init; }

    /// <summary>
    ///   <para>Initiator person of deputy request.</para>
    /// </summary>
    [DataMember(Name = "initiator", IsRequired = true)]
    public string Initiator { get; init; }

    /// <summary>
    ///   <para>Addressee of deputy's request.</para>
    /// </summary>
    [DataMember(Name = "addressee", IsRequired = true)]
    public DeputyRequestAddressee Addressee { get; init; }

    /// <summary>
    ///   <para>Text of answer for deputy's request.</para>
    /// </summary>
    [DataMember(Name = "answer", IsRequired = true)]
    public string Answer { get; init; }

    /// <summary>
    ///   <para>Person who signed deputy's request.</para>
    /// </summary>
    [DataMember(Name = "signedBy", IsRequired = true)]
    public DeputyRequestSigner Signer { get; init; }

    /// <summary>
    ///   <para>Date when deputy's request was signed.</para>
    /// </summary>
    [DataMember(Name = "signedDate", IsRequired = true)]
    public string SignDate { get; init; }

    /// <summary>
    ///   <para>Date when deputy's request was in control stage.</para>
    /// </summary>
    [DataMember(Name = "controlDate", IsRequired = true)]
    public string ControlDate { get; init; }

    /// <summary>
    ///   <para>Number of associated resolution.</para>
    /// </summary>
    [DataMember(Name = "resolution", IsRequired = true)]
    public string ResolutionNumber { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IDeputyRequest ToResult() => new DeputyRequest(this);
  }
}