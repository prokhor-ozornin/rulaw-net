using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IActiveExtensions"/>.</para>
/// </summary>
public sealed class IActiveExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IActiveExtensions.Active{TEntity}(IEnumerable{TEntity})"/> method.</para>
  /// </summary>
  [Fact]
  public void Active_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IActiveExtensions.Active<IActive>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("entities");

      Validate([], 0);
      Validate(new ActiveEntity[] { new() { Active = true }, new() { Active = false }, null }, 1);
    }

    return;

    static void Validate(IEnumerable<IActive> sequence, int count) => sequence.Active().Should().NotBeNull().And.NotBeSameAs(sequence).And.HaveCount(count);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IActiveExtensions.Inactive{TEntity}(IEnumerable{TEntity})"/> method.</para>
  /// </summary>
  [Fact]
  public void Inactive_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IActiveExtensions.Inactive<IActive>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("entities");

      Validate([], 0);
      Validate(new ActiveEntity[] { new() { Active = true }, new() { Active = false }, null }, 1);
    }

    return;

    static void Validate(IEnumerable<IActive> sequence, int count) => sequence.Inactive().Should().NotBeNull().And.NotBeSameAs(sequence).And.HaveCount(count);
  }

  private sealed class ActiveEntity : IActive
  {
    public bool? Active { get; init; }
  }
}