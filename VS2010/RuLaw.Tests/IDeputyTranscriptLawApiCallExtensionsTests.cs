using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDeputyTranscriptLawApiCallExtensions"/>.</para>
  /// </summary>
  public sealed class IDeputyTranscriptLawApiCallExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputyTranscriptLawApiCallExtensions.Deputy(IDeputyTranscriptLawApiCall, Deputy)"/> method.</para>
    /// </summary>
    [Fact]
    public void Deputy_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyTranscriptLawApiCallExtensions.Deputy(null, new Deputy()));
      Assert.Throws<ArgumentNullException>(() => new DeputyTranscriptLawApiCall().Deputy(null));

      var call = new DeputyTranscriptLawApiCall();
      Assert.False(call.Parameters.ContainsKey("deputy"));
      Assert.True(ReferenceEquals(call, call.Deputy(new Deputy { Id = 1 })));
      Assert.Equal((long) 1, call.Parameters["deputy"]);
    }
  }
}