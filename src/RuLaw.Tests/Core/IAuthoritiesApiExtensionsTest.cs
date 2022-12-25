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
  ///     <item><description><see cref="IAuthoritiesApiExtensions.Federal(IAuthoritiesApi, Action{IAuthoritiesApiRequest}?, CancellationToken)"/></description></item>
  ///     <item><description><see cref="IAuthoritiesApiExtensions.Federal(IAuthoritiesApi, out IEnumerable{IAuthority}?, Action{IAuthoritiesApiRequest}?, CancellationToken)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Federal_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Federal(null!)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Authorities.Federal(null, Cancellation)).ThrowExactly<TaskCanceledException>();

      var authorities = Api.Authorities.Federal(request => request.Current()).ToList().Await();
      
      authorities.Should().NotBeNullOrEmpty().And.BeOfType<List<FederalAuthority>>();
      
      var authority = authorities.Single(authority => authority.Id == 6231000);
      authority.Name.Should().Be("Верховный Суд РФ");
      authority.Active.Should().BeTrue();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().BeNull();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Federal(null!, out _)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Authorities.Federal(out _, null, Cancellation)).ThrowExactly<TaskCanceledException>();

      Api.Authorities.Federal(out var authorities).Should().BeTrue();
      
      authorities.Should().NotBeNullOrEmpty().And.BeOfType<List<FederalAuthority>>();
      
      var authority = authorities!.Single(authority => authority.Id == 6231000);
      authority.Name.Should().Be("Верховный Суд РФ");
      authority.Active.Should().BeTrue();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().BeNull();
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IAuthoritiesApiExtensions.Regional(IAuthoritiesApi, Action{IAuthoritiesApiRequest}?, CancellationToken)"/></description></item>
  ///     <item><description><see cref="IAuthoritiesApiExtensions.Regional(IAuthoritiesApi, out IEnumerable{IAuthority}?, Action{IAuthoritiesApiRequest}?, CancellationToken)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Regional_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Regional(null!)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Regional(Api.Authorities, null, Cancellation)).ThrowExactly<TaskCanceledException>();

      var authorities = Api.Authorities.Regional(request => request.Current(false)).ToList().Await();
      
      authorities.Should().NotBeNullOrEmpty().And.BeOfType<List<RegionalAuthority>>();
      
      var authority = authorities.Single(authority => authority.Id == 6217700);
      authority.Name.Should().Be("Агинская Бурятская окружная Дума");
      authority.Active.Should().BeFalse();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().HaveYear(2008).And.HaveMonth(10).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IAuthoritiesApiExtensions.Regional(null!, out _)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Authorities.Regional(out _, null, Cancellation)).ThrowExactly<TaskCanceledException>();

      Api.Authorities.Regional(out var authorities).Should().BeTrue();
      
      authorities.Should().NotBeNullOrEmpty().And.BeOfType<List<RegionalAuthority>>();
      
      var authority = authorities!.Single(authority => authority.Id == 6217700);
      authority.Name.Should().Be("Агинская Бурятская окружная Дума");
      authority.Active.Should().BeFalse();
      authority.FromDate.Should().HaveYear(1994).And.HaveMonth(1).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      authority.ToDate.Should().HaveYear(2008).And.HaveMonth(10).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public void Dispose()
  {
    Api.Dispose();
  }
}