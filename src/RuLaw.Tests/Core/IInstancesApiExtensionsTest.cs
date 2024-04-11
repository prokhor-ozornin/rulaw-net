using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IInstancesApiExtensions"/>.</para>
/// </summary>
public sealed class IInstancesApiExtensionsTest : IntegrationTest
{
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

      Validate(Api.Instances.Search(new InstancesApiRequest().Current()));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IInstancesApiExtensions.Search(null, _ => {})).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      Validate(Api.Instances.Search(request => request.Current()));
    }

    return;

    static void Validate(IEnumerable<IInstance> instances)
    {
      instances.Should().BeOfType<List<Instance>>().And.NotBeEmpty();

      var instance = instances.Single(instance => instance.Id == 177);
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IInstancesApiExtensions.SearchAsync(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");
      AssertionExtensions.Should(() => IInstancesApiExtensions.SearchAsync(Api.Instances, null, Attributes.CancellationToken())).ThrowExactly<OperationCanceledException>();

      Validate(Api.Instances.SearchAsync(request => request.Current()).ToArray());
    }

    return;

    static void Validate(IEnumerable<IInstance> instances)
    {
      instances.Should().BeOfType<List<Instance>>().And.NotBeEmpty();

      var instance = instances.Single(instance => instance.Id == 177);
      instance.Name.Should().Be("ГД (Пленарное заседание)");
      instance.Active.Should().BeTrue();
    }
  }
}