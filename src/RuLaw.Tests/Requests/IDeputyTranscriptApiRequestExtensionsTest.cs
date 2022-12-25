using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDeputyTranscriptApiRequestExtensions"/>.</para>
/// </summary>
public sealed class IDeputyTranscriptApiRequestExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyTranscriptApiRequestExtensions.Deputy(IDeputyTranscriptApiRequest, IDeputy?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Deputy_Method()
  {
    AssertionExtensions.Should(() => IDeputyTranscriptApiRequestExtensions.Deputy(null!, new Deputy(new Deputy.Info()))).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => new DeputyTranscriptApiRequest().Deputy(null)).ThrowExactly<ArgumentNullException>();

    var request = new DeputyTranscriptApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Deputy((IDeputy) null!).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().BeNull();

    request.Deputy(new Deputy(new {Id = 1})).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["deputy"].Should().Be(1L);
  }
}