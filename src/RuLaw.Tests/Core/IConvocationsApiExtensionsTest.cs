using System.Configuration;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="IConvocationsApiExtensions"/>.</para>
/// </summary>
public sealed class IConvocationsApiExtensionsTest : UnitTest
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of <see cref="IConvocationsApiExtensions.All(IConvocationsApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IConvocationsApiExtensions.All(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      var convocations = Api.Convocations.All();

      convocations.Should().NotBeNullOrEmpty().And.BeOfType<List<Convocation>>();

      var convocation = convocations.Single(convocation => convocation.Id == 82100004);
      convocation.Name.Should().Be("4-ый созыв");
      convocation.FromDate.Should().HaveYear(2003).And.HaveMonth(12).And.HaveDay(29).And.HaveOffset(TimeSpan.Zero);
      convocation.ToDate.Should().HaveYear(2007).And.HaveMonth(12).And.HaveDay(23).And.HaveOffset(TimeSpan.Zero);
      convocation.Sessions.Should().NotBeNullOrEmpty().And.HaveCount(8).And.BeOfType<List<Session>>();

      var session = convocation.Sessions.ElementAt(0);
      session.Id.Should().Be(82200021);
      session.Name.Should().Be("Весенняя сессия 2004 г.");
      session.FromDate.Should().HaveYear(2004).And.HaveMonth(1).And.HaveDay(12).And.HaveOffset(TimeSpan.Zero);
      session.ToDate.Should().HaveYear(2004).And.HaveMonth(7).And.HaveDay(10).And.HaveOffset(TimeSpan.Zero);

      session = convocation.Sessions.ElementAt(1);
      session.Id.Should().Be(82200022);
      session.Name.Should().Be("Осенняя сессия 2004 г.");
      session.FromDate.Should().HaveYear(2004).And.HaveMonth(9).And.HaveDay(1).And.HaveOffset(TimeSpan.Zero);
      session.ToDate.Should().HaveYear(2004).And.HaveMonth(12).And.HaveDay(31).And.HaveOffset(TimeSpan.Zero);
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose() => Api.Dispose();
}