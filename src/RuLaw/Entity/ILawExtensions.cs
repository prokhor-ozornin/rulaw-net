namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ILaw"/>.</para>
/// </summary>
/// <seealso cref="ILaw"/>
public static class ILawExtensions
{
  /// <summary>
  ///   <para>Searches for a law with specified number and returns it.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="laws">Source sequence of laws for searching.</param>
  /// <param name="number">Unique number of law to search for.</param>
  /// <returns>Law with a specified number, or a <c>null</c> reference if it could not be found.</returns>
  public static TEntity Number<TEntity>(this IEnumerable<TEntity> laws, string number) where TEntity : ILaw => laws.FirstOrDefault(law => law != null && string.Equals(law.Number, number, StringComparison.InvariantCultureIgnoreCase));
}