namespace RuLaw;

/// <summary>
///   <para>Deputy's higher education information record.</para>
/// </summary>
public interface IEducation : IComparable<IEducation>, IEquatable<IEducation>
{
  /// <summary>
  ///   <para>Name of education institution.</para>
  /// </summary>
  string Institution { get; }

  /// <summary>
  ///   <para>Year of graduation.</para>
  /// </summary>
  short? Year { get; }
}