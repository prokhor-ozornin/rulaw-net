using System.Configuration;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IStagesApiExtensions"/>.</para>
/// </summary>
public sealed class IStagesApiExtensionsTest : UnitTest
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of <see cref="IStagesApiExtensions.All(IStagesApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    AssertionExtensions.Should(() => IStagesApiExtensions.All(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");

    var stages = Api.Stages.All();

    stages.Should().NotBeNullOrEmpty().And.BeOfType<List<PhaseStage>>();
    
    var stage = stages.Single(stage => stage.Id == 1);
    stage.Name.Should().Be("Внесение законопроекта в Государственную Думу");
    stage.Phases.Should().NotBeNullOrEmpty().And.HaveCount(3).And.BeOfType<List<StagePhase>>();

    var phase = stage.Phases.ElementAt(0);
    phase.Id.Should().Be(1);
    phase.Name.Should().Be("Регистрация законопроекта и материалов к нему в САДД Государственной Думы");

    phase.Instance.Should().NotBeNull().And.BeOfType<Instance>();
    phase.Instance.Id.Should().Be(173);
    phase.Instance.Name.Should().Be("УДИО ГД");
    phase.Instance.Active.Should().BeTrue();

    phase = stage.Phases.ElementAt(1);
    phase.Id.Should().Be(2);
    phase.Name.Should().Be("Прохождение законопроекта у Председателя Государственной Думы");
    phase.Instance.Should().NotBeNull().And.BeOfType<Instance>();
    phase.Instance.Id.Should().Be(174);
    phase.Instance.Name.Should().Be("Секретариат Председателя ГД");
    phase.Instance.Active.Should().BeTrue();

    phase = stage.Phases.ElementAt(2);
    phase.Id.Should().Be(3);
    phase.Name.Should().Be("Регистрация законопроекта в Секретариате Совета Государственной Думы");
    phase.Instance.Should().NotBeNull().And.BeOfType<Instance>();
    phase.Instance.Id.Should().Be(175);
    phase.Instance.Name.Should().Be("Секретариат Совета ГД");
    phase.Instance.Active.Should().BeTrue();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    Api.Dispose();
  }
}