namespace RuLaw;

/// <summary>
///   <para>Deputy's request.</para>
/// </summary>
public interface IDeputyRequest : IEntity, IDateable, INameable, IComparable<IDeputyRequest>, IEquatable<IDeputyRequest>
{
  /// <summary>
  ///   <para>Number of associated document.</para>
  /// </summary>
  string DocumentNumber { get; }

  /// <summary>
  ///   <para>Initiator person of deputy request.</para>
  /// </summary>
  string Initiator { get; }

  /// <summary>
  ///   <para>Addressee of deputy's request.</para>
  /// </summary>
  IDeputyRequestAddressee Addressee { get; }

  /// <summary>
  ///   <para>Text of answer for deputy's request.</para>
  /// </summary>
  string Answer { get; }

  /// <summary>
  ///   <para>Person who signed deputy's request.</para>
  /// </summary>
  IDeputyRequestSigner Signer { get; }

  /// <summary>
  ///   <para>Date when deputy's request was signed.</para>
  /// </summary>
  DateTimeOffset? SignDate { get; }

  /// <summary>
  ///   <para>Date when deputy's request was in control stage.</para>
  /// </summary>
  DateTimeOffset? ControlDate { get; }

  /// <summary>
  ///   <para>Number of associated resolution.</para>
  /// </summary>
  string ResolutionNumber { get; }
}