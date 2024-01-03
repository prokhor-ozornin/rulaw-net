using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RuLaw"/>.</para>
/// </summary>
public sealed class RuLawTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RuLaw.Api"/> property.</para>
  /// </summary>
  [Fact]
  public void Api_Property()
  {
    RuLaw.Api.Should().NotBeNull().And.BeSameAs(RuLaw.Api).And.BeOfType<Api>();
  }
}