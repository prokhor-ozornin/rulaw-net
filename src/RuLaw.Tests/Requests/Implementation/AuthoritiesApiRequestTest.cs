using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="AuthoritiesApiRequest"/>.</para>
/// </summary>
public sealed class AuthoritiesApiRequestTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputiesApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(DeputiesApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<IDeputiesApiRequest>();

    var request = new AuthoritiesApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AuthoritiesApiRequest.Current(bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Current_Method()
  {
    using (new AssertionScope())
    {
      var request = new AuthoritiesApiRequest();
      
      Validate(null, request);
      Validate(true, request);
      Validate(false, request);
    }

    return;

    static void Validate(bool? current, IAuthoritiesApiRequest request) => request.Current(current).Should().BeSameAs(request).And.BeOfType<AuthoritiesApiRequest>().Which.Parameters["current"].Should().Be(current?.ToString().ToLowerInvariant());
  }
}