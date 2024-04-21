using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDeputyRequestExtensions"/>.</para>
/// </summary>
public sealed class IDeputyRequestExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyRequestExtensions.Initiator{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Initiator_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyRequestExtensions.Initiator<IDeputyRequest>(null, "initiator")).ThrowExactly<ArgumentNullException>().WithParameterName("requests");

      Validate([], [], null);
      Validate([], [], "initiator");

      var first = new DeputyRequest { Initiator = "first" };
      var second = new DeputyRequest { Initiator = "second" };
      Validate([], [null], null);
      Validate([first], [null, first, second, null], first.Initiator);
    }

    return;

    static void Validate(IEnumerable<IDeputyRequest> result, IEnumerable<IDeputyRequest> requests, string initiator) => requests.Initiator(initiator).Should().BeAssignableTo<IEnumerable<IDeputyRequest>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyRequestExtensions.Answer{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Answer_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyRequestExtensions.Answer<IDeputyRequest>(null, "answer")).ThrowExactly<ArgumentNullException>().WithParameterName("requests");

      Validate([], [], null);
      Validate([], [], "answer");

      var first = new DeputyRequest { Answer = "first" };
      var second = new DeputyRequest { Answer = "second" };
      Validate([], [null], null);
      Validate([first], [null, first, second, null], first.Answer);
    }

    return;

    static void Validate(IEnumerable<IDeputyRequest> result, IEnumerable<IDeputyRequest> requests, string answer) => requests.Answer(answer).Should().BeAssignableTo<IEnumerable<IDeputyRequest>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyRequestExtensions.SignDate{TEntity}(IEnumerable{TEntity}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void SignDate_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyRequestExtensions.SignDate<IDeputyRequest>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("requests");

      Validate([], []);

      var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

      var first = new DeputyRequest { SignDate = DateTimeOffset.MinValue };
      var second = new DeputyRequest { SignDate = date };
      var third = new DeputyRequest { SignDate = DateTimeOffset.MaxValue };
      var requests = new List<IDeputyRequest> { null, first, second, third, null };

      Validate([first, second], requests, date);
      Validate([first, second], requests, null, date);
      Validate([first, second, third], requests, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    }

    return;

    static void Validate(IEnumerable<IDeputyRequest> result, IEnumerable<IDeputyRequest> requests, DateTimeOffset? from = null, DateTimeOffset? to = null) => requests.SignDate(from, to).Should().BeAssignableTo<IEnumerable<IDeputyRequest>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyRequestExtensions.ControlDate{TEntity}(IEnumerable{TEntity}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ControlDate_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyRequestExtensions.ControlDate<IDeputyRequest>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("requests");

      Validate([], []);

      var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

      var first = new DeputyRequest { ControlDate = DateTimeOffset.MinValue };
      var second = new DeputyRequest { ControlDate = date };
      var third = new DeputyRequest { ControlDate = DateTimeOffset.MaxValue };
      var requests = new List<IDeputyRequest> { null, first, second, third, null };

      Validate([first, second], requests, date);
      Validate([first, second], requests, null, date);
      Validate([first, second, third], requests, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    }

    return;

    static void Validate(IEnumerable<IDeputyRequest> result, IEnumerable<IDeputyRequest> requests, DateTimeOffset? from = null, DateTimeOffset? to = null) => requests.ControlDate(from, to).Should().BeAssignableTo<IEnumerable<IDeputyRequest>>().And.Equal(result);
  }
}