using System.Configuration;
using Catharsis.Extensions;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IInstancesApiExtensions"/>.</para>
/// </summary>
public sealed class IInstancesApiExtensionsTest : UnitTest
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IInstancesApiExtensions.Search(IInstancesApi, IInstancesApiRequest)"/></description></item>
  ///     <item><description><see cref="IInstancesApiExtensions.Search(IInstancesApi, Action{IInstancesApiRequest})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Search_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IInstancesApiExtensions.Search(null, new InstancesApiRequest())).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      var instances = Api.Instances.Search(new InstancesApiRequest().Current());
      Validate(instances);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IInstancesApiExtensions.Search(null, _ => {})).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      var instances = Api.Instances.Search(request => request.Current());
      Validate(instances);
    }

    return;

    static void Validate(IEnumerable<IInstance> sequence)
    {
      sequence.Should().NotBeNullOrEmpty().And.BeOfType<List<Instance>>();

      var instance = sequence.Single(instance => instance.Id == 177);
      instance.Name.Should().Be("ГД (Пленарное заседание)");
      instance.Active.Should().BeTrue();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IInstancesApiExtensions.SearchAsync(IInstancesApi, Action{IInstancesApiRequest}, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void SearchAsync_Method()
  {
    AssertionExtensions.Should(() => IInstancesApiExtensions.SearchAsync(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");
    AssertionExtensions.Should(() => IInstancesApiExtensions.SearchAsync(Api.Instances, null, Cancellation)).ThrowExactly<OperationCanceledException>();

    var instances = Api.Instances.SearchAsync(request => request.Current()).ToListAsync().Await();

    var instance = instances.Single(instance => instance.Id == 177);
    instance.Name.Should().Be("ГД (Пленарное заседание)");
    instance.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    Api.Dispose();
  }
}