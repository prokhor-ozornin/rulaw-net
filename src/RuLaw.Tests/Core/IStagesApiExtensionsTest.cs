using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IStagesApiExtensions"/>.</para>
/// </summary>
public sealed class IStagesApiExtensionsTest : IntegrationTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IStagesApiExtensions.All(IStagesApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IStagesApiExtensions.All(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      Validate(Api.Stages.All());
    }

    return;

    static void Validate(IEnumerable<IPhaseStage> stages)
    {
      stages.Should().BeOfType<List<PhaseStage>>().And.NotBeEmpty();

      var stage = stages.Single(stage => stage.Id == 1);
      stage.Name.Should().Be("Внесение законопроекта в Государственную Думу");
      stage.Phases.Should().BeOfType<List<StagePhase>>().And.HaveCount(3);

      var phase = stage.Phases.ElementAt(0);
      phase.Id.Should().Be(1);
      phase.Name.Should().Be("Регистрация законопроекта и материалов к нему в САДД Государственной Думы");

      phase.Instance.Should().BeOfType<Instance>();
      phase.Instance.Id.Should().Be(173);
      phase.Instance.Name.Should().Be("УДИО ГД");
      phase.Instance.Active.Should().BeTrue();

      phase = stage.Phases.ElementAt(1);
      phase.Id.Should().Be(2);
      phase.Name.Should().Be("Прохождение законопроекта у Председателя Государственной Думы");
      phase.Instance.Should().BeOfType<Instance>();
      phase.Instance.Id.Should().Be(174);
      phase.Instance.Name.Should().Be("Секретариат Председателя ГД");
      phase.Instance.Active.Should().BeTrue();

      phase = stage.Phases.ElementAt(2);
      phase.Id.Should().Be(3);
      phase.Name.Should().Be("Регистрация законопроекта в Секретариате Совета Государственной Думы");
      phase.Instance.Should().BeOfType<Instance>();
      phase.Instance.Id.Should().Be(175);
      phase.Instance.Name.Should().Be("Секретариат Совета ГД");
      phase.Instance.Active.Should().BeTrue();
    }
  }
}