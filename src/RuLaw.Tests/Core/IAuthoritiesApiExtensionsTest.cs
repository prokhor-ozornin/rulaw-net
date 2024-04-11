using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IAuthoritiesApiExtensions"/>.</para>
/// </summary>
public sealed class IAuthoritiesApiExtensionsTest : IntegrationTest
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IAuthoritiesApiExtensions.Federal(IAuthoritiesApi, IAuthoritiesApiRequest)"/></description></item>
  ///     <item><description><see cref="IAuthoritiesApiExtensions.Federal(IAuthoritiesApi, Action{IAuthoritiesApiRequest})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Federal_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Federal(null, new AuthoritiesApiRequest())).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      Validate(Api.Authorities.Federal(new AuthoritiesApiRequest().Current()));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Federal(null, _ => {})).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      Validate(Api.Authorities.Federal(request => request.Current()));
    }

    return;

    static void Validate(IEnumerable<IAuthority> authorities)
    {
      authorities.Should().BeOfType<List<FederalAuthority>>().And.NotBeEmpty();

      var authority = authorities.Single(authority => authority.Id == 6231000);
      authority.Name.Should().Be("Верховный Суд РФ");
      authority.Active.Should().BeTrue();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().BeNull();
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IAuthoritiesApiExtensions.Regional(IAuthoritiesApi, IAuthoritiesApiRequest)"/></description></item>
  ///     <item><description><see cref="IAuthoritiesApiExtensions.Regional(IAuthoritiesApi, Action{IAuthoritiesApiRequest})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Regional_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Regional(null, new AuthoritiesApiRequest())).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      Validate(Api.Authorities.Regional(new AuthoritiesApiRequest().Current(false)));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Regional(null, _ => { })).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      Validate(Api.Authorities.Regional(request => request.Current(false)));
    }

    return;

    static void Validate(IEnumerable<IAuthority> authorities)
    {
      authorities.Should().BeOfType<List<RegionalAuthority>>().And.NotBeEmpty();

      var authority = authorities.Single(authority => authority.Id == 6217700);
      authority.Name.Should().Be("Агинская Бурятская окружная Дума");
      authority.Active.Should().BeFalse();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().HaveYear(2008).And.HaveMonth(10).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAuthoritiesApiExtensions.FederalAsync(IAuthoritiesApi, Action{IAuthoritiesApiRequest}, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void FederalAsync_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.FederalAsync(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.FederalAsync(Api.Authorities, null, Attributes.CancellationToken())).ThrowExactly<OperationCanceledException>();

      Validate(Api.Authorities.FederalAsync(new AuthoritiesApiRequest().Current()).ToArray());
    }

    return;

    static void Validate(IEnumerable<IAuthority> authorities)
    {
      authorities.Should().BeOfType<List<FederalAuthority>>().And.NotBeEmpty();

      var authority = authorities.Single(authority => authority.Id == 6231000);
      authority.Name.Should().Be("Верховный Суд РФ");
      authority.Active.Should().BeTrue();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().BeNull();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAuthoritiesApiExtensions.RegionalAsync(IAuthoritiesApi, Action{IAuthoritiesApiRequest}, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegionalAsync_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.RegionalAsync(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.RegionalAsync(Api.Authorities, null, Attributes.CancellationToken())).ThrowExactly<OperationCanceledException>();

      Validate(Api.Authorities.RegionalAsync(new AuthoritiesApiRequest().Current(false)).ToArray());
    }

    return;

    static void Validate(IEnumerable<IAuthority> authorities)
    {
      authorities.Should().BeOfType<List<RegionalAuthority>>().And.NotBeEmpty();

      var authority = authorities.Single(authority => authority.Id == 6217700);
      authority.Name.Should().Be("Агинская Бурятская окружная Дума");
      authority.Active.Should().BeFalse();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().HaveYear(2008).And.HaveMonth(10).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    }
  }
}