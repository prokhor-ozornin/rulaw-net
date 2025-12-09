using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IActiveExtensions"/>.</para>
/// </summary>
/// <seealso cref="IActiveExtensions"/>
public sealed class IActiveExtensionsTest : Test
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

      Test([], 0);
      Test(new ActiveEntity[] { new() { Active = true }, new() { Active = false }, null }, 1);
    }

    return;

    static void Test(IEnumerable<IActive> sequence, int count) => sequence.Active().Should().NotBeNull().And.NotBeSameAs(sequence).And.HaveCount(count);
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

      Test([], 0);
      Test(new ActiveEntity[] { new() { Active = true }, new() { Active = false }, null }, 1);
    }

    return;

    static void Test(IEnumerable<IActive> sequence, int count) => sequence.Inactive().Should().NotBeNull().And.NotBeSameAs(sequence).And.HaveCount(count);
  }

  private sealed class ActiveEntity : IActive
  {
    public bool? Active { get; init; }
  }
}