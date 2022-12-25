namespace RuLaw;

/// <summary>
///   <para>Document, associated with a law's event.</para>
/// </summary>
public interface ILawEventDocument : INameable, IComparable<ILawEventDocument>, IEquatable<ILawEventDocument>
{
  /// <summary>
  ///   <para>Type of document.</para>
  /// </summary>
  string? Type { get; }
}