using System.Configuration;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IAuthoritiesApiExtensions"/>.</para>
/// </summary>
public sealed class IAuthoritiesApiExtensionsTest : IDisposable
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));
  
  private CancellationToken Cancellation { get; } = new(true);

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
    static void Validate(IEnumerable<IAuthority> sequence)
    {
      sequence.Should().NotBeNullOrEmpty().And.BeOfType<List<FederalAuthority>>();

      var authority = sequence.Single(authority => authority.Id == 6231000);
      authority.Name.Should().Be("Верховный Суд РФ");
      authority.Active.Should().BeTrue();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().BeNull();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Federal(null, new AuthoritiesApiRequest())).ThrowExactly<ArgumentNullException>();

      var authorities = Api.Authorities.Federal(new AuthoritiesApiRequest().Current());
      Validate(authorities);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Federal(null, _ => {})).ThrowExactly<ArgumentNullException>();

      var authorities = Api.Authorities.Federal(request => request.Current());
      Validate(authorities);
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
    static void Validate(IEnumerable<IAuthority> sequence)
    {
      sequence.Should().NotBeNullOrEmpty().And.BeOfType<List<RegionalAuthority>>();

      var authority = sequence.Single(authority => authority.Id == 6217700);
      authority.Name.Should().Be("Агинская Бурятская окружная Дума");
      authority.Active.Should().BeFalse();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().HaveYear(2008).And.HaveMonth(10).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Regional(null, new AuthoritiesApiRequest())).ThrowExactly<ArgumentNullException>();

      var authorities = Api.Authorities.Regional(new AuthoritiesApiRequest().Current(false));
      Validate(authorities);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Regional(null, _ => { })).ThrowExactly<ArgumentNullException>();

      var authorities = Api.Authorities.Regional(request => request.Current(false));
      Validate(authorities);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAuthoritiesApiExtensions.FederalAsync(IAuthoritiesApi, Action{IAuthoritiesApiRequest}, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void FederalAsync_Method()
  {
    static void Validate(IAsyncEnumerable<IAuthority> sequence)
    {
      var authorities = sequence.ToListAsync().Await();

      authorities.Should().NotBeNullOrEmpty().And.BeOfType<List<FederalAuthority>>();

      var authority = authorities.Single(authority => authority.Id == 6231000);
      authority.Name.Should().Be("Верховный Суд РФ");
      authority.Active.Should().BeTrue();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().BeNull();
    }

    AssertionExtensions.Should(() => IAuthoritiesApiExtensions.FederalAsync(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => IAuthoritiesApiExtensions.FederalAsync(Api.Authorities, null, Cancellation)).ThrowExactly<TaskCanceledException>();

    var authorities = Api.Authorities.FederalAsync(new AuthoritiesApiRequest().Current());
    Validate(authorities);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAuthoritiesApiExtensions.RegionalAsync(IAuthoritiesApi, Action{IAuthoritiesApiRequest}, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void RegionalAsync_Method()
  {
    static void Validate(IAsyncEnumerable<IAuthority> sequence)
    {
      var authorities = sequence.ToListAsync().Await();

      authorities.Should().NotBeNullOrEmpty().And.BeOfType<List<RegionalAuthority>>();

      var authority = authorities.Single(authority => authority.Id == 6217700);
      authority.Name.Should().Be("Агинская Бурятская окружная Дума");
      authority.Active.Should().BeFalse();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().HaveYear(2008).And.HaveMonth(10).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    }

    AssertionExtensions.Should(() => IAuthoritiesApiExtensions.RegionalAsync(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => IAuthoritiesApiExtensions.RegionalAsync(Api.Authorities, null, Cancellation)).ThrowExactly<TaskCanceledException>();

    var authorities = Api.Authorities.RegionalAsync(new AuthoritiesApiRequest().Current(false));
    Validate(authorities);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public void Dispose()
  {
    Api.Dispose();
  }
}