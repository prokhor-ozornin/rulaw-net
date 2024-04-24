using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDeputyTranscriptApiRequestExtensions"/>.</para>
/// </summary>
public sealed class IDeputyTranscriptApiRequestExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyTranscriptApiRequestExtensions.Deputy(IDeputyTranscriptApiRequest, IDeputy)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyTranscriptApiRequestExtensions.Deputy(null, new Deputy())).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, new DeputyTranscriptApiRequest());
      Validate(new Deputy { Id = long.MinValue }, new DeputyTranscriptApiRequest());
      Validate(new Deputy { Id = long.MaxValue }, new DeputyTranscriptApiRequest());
    }

    return;

    static void Validate(IDeputy deputy, IDeputyTranscriptApiRequest request) => request.Deputy(deputy).Should().BeSameAs(request).And.BeOfType<DeputyTranscriptApiRequest>().Which.Parameters["deputy"].Should().Be(deputy?.Id);
  }
}