using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IActiveExtensions"/>.</para>
/// </summary>
public sealed class IActiveExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IActiveExtensions.Active{TEntity}(IEnumerable{TEntity})"/> method.</para>
  /// </summary>
  [Fact]
  public void Active_Method()
  {
    AssertionExtensions.Should(() => IActiveExtensions.Active<IActive>(null!)).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<IActive>().Active().Should().NotBeNull().And.BeEmpty();
    new[] {null, new ActiveEntity {Active = true}, null, new ActiveEntity {Active = false}}.Active().Should().NotBeNullOrEmpty().And.ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IActiveExtensions.Inactive{TEntity}(IEnumerable{TEntity})"/> method.</para>
  /// </summary>
  [Fact]
  public void Inactive_Method()
  {
    AssertionExtensions.Should(() => IActiveExtensions.Inactive<IActive>(null!)).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<IActive>().Inactive().Should().NotBeNull().And.BeEmpty();
    new[] {null, new ActiveEntity {Active = true}, null, new ActiveEntity {Active = false}}.Inactive().Should().NotBeNullOrEmpty().And.ContainSingle();
  }

  private sealed class ActiveEntity : IActive
  {
    public bool? Active { get; init; }
  }
}