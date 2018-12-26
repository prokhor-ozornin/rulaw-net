namespace RuLaw
{
  using System;

  /// <summary>
  ///   <para>Deputy's request.</para>
  /// </summary>
  public interface IDeputyRequest : IEntity, IDateable, INameable
  {
    /// <summary>
    ///   <para>Addressee of deputy's request.</para>
    /// </summary>
    IDeputyRequestAddressee Addressee { get; }

    /// <summary>
    ///   <para>Text of answer for deputy's request.</para>
    /// </summary>
    string Answer { get; }

    /// <summary>
    ///   <para>Date when deputy's request was in control stage.</para>
    /// </summary>
    DateTime ControlDate { get; }

    /// <summary>
    ///   <para>Number of associated document.</para>
    /// </summary>
    string DocumentNumber { get; }

    /// <summary>
    ///   <para>Number of associated resolution.</para>
    /// </summary>
    string ResolutionNumber { get; }

    /// <summary>
    ///   <para>Initiator person of deputy request.</para>
    /// </summary>
    string Initiator { get; }

    /// <summary>
    ///   <para>Date when deputy's request was signed.</para>
    /// </summary>
    DateTime SignDate { get; }

    /// <summary>
    ///   <para>Person who signed deputy's request.</para>
    /// </summary>
    IDeputyRequestSigner Signer { get; }
  }
}