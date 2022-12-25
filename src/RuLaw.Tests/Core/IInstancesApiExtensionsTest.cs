using System.Configuration;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IInstancesApiExtensions"/>.</para>
/// </summary>
public sealed class IInstancesApiExtensionsTest : IDisposable
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  private CancellationToken Cancellation { get; } = new(true);

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IInstancesApiExtensions.Search(IInstancesApi, Action{IInstancesApiRequest}?, CancellationToken)"/></description></item>
  ///     <item><description><see cref="IInstancesApiExtensions.Search(IInstancesApi, out IEnumerable{IInstance}?, Action{IInstancesApiRequest}?, CancellationToken)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Search_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IInstancesApiExtensions.Search(null!)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => IInstancesApiExtensions.Search(Api.Instances, null, Cancellation)).ThrowExactly<TaskCanceledException>();

      var instances = Api.Instances.Search(request => request.Current()).ToList().Await();

      instances.Should().NotBeNullOrEmpty().And.BeOfType<List<Instance>>();
      
      var instance = instances.Single(instance => instance.Id == 177);
      instance.Name.Should().Be("ГД (Пленарное заседание)");
      instance.Active.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IInstancesApiExtensions.Search(null!, out _)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => Api.Instances.Search(out _, null, Cancellation)).ThrowExactly<TaskCanceledException>();

      Api.Instances.Search(out var instances).Should().BeTrue();
      
      instances.Should().NotBeNullOrEmpty().And.BeOfType<List<Instance>>();
      
      var instance = instances.Single(instance => instance.Id == 177);
      instance.Name.Should().Be("ГД (Пленарное заседание)");
      instance.Active.Should().BeTrue();
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