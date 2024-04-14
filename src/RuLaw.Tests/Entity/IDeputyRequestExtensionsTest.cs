﻿using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
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
      AssertionExtensions.Should(() => Enumerable.Empty<IDeputyRequest>().Initiator(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");
      AssertionExtensions.Should(() => Enumerable.Empty<IDeputyRequest>().Initiator(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("text");

      Enumerable.Empty<IDeputyRequest>().Initiator("initiator").Should().NotBeNull().And.BeEmpty();

      var first = new DeputyRequest {Initiator = "FIRST"};
      var second = new DeputyRequest {Initiator = "Second"};
      var requests = first.ToSequence(second, null);
      requests.Initiator("first").Should().NotBeNullOrEmpty().And.Equal(first);
      requests.Initiator("second").Should().NotBeNullOrEmpty().And.Equal(second);
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputyRequestExtensions.Answer{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Answer_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyRequestExtensions.Answer<IDeputyRequest>(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("requests");
      AssertionExtensions.Should(() => Enumerable.Empty<IDeputyRequest>().Answer(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");
      AssertionExtensions.Should(() => Enumerable.Empty<IDeputyRequest>().Answer(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("text");

      Enumerable.Empty<IDeputyRequest>().Answer("answer").Should().NotBeNull().And.BeEmpty();

      var first = new DeputyRequest {Answer = "FIRST"};
      var second = new DeputyRequest {Answer = "Second"};
      var requests = first.ToSequence(second, null);
      requests.Answer("first").Should().NotBeNullOrEmpty().And.Equal(first);
      requests.Answer("second").Should().NotBeNullOrEmpty().And.Equal(second);
    }

    return;

    static void Validate()
    {

    }
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

      var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

      var first = new DeputyRequest {SignDate = DateTimeOffset.MinValue};
      var second = new DeputyRequest {SignDate = date};
      var third = new DeputyRequest {SignDate = DateTimeOffset.MaxValue};

      var requests = first.ToSequence(second, third, null);
      requests.SignDate(date).Should().NotBeNullOrEmpty().And.Equal(first, second);
      requests.SignDate(null, date).Should().NotBeNullOrEmpty().And.Equal(first, second);
      requests.SignDate(DateTimeOffset.MinValue, DateTimeOffset.MaxValue).Should().NotBeNullOrEmpty().And.Equal(first, second, third);
    }

    return;

    static void Validate()
    {

    }
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

      Enumerable.Empty<IDeputyRequest>().ControlDate().Should().NotBeNull().And.BeEmpty();

      var date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero);

      var first = new DeputyRequest { ControlDate = DateTimeOffset.MinValue };
      var second = new DeputyRequest { ControlDate = date };
      var third = new DeputyRequest { ControlDate = DateTimeOffset.MaxValue };

      var requests = first.ToSequence(second, third, null);
      requests.ControlDate(date).Should().NotBeNullOrEmpty().And.Equal(second, third);
      requests.ControlDate(null, date).Should().NotBeNullOrEmpty().And.Equal(first, second);
      requests.ControlDate(DateTimeOffset.MinValue, DateTimeOffset.MaxValue).Should().NotBeNullOrEmpty().And.Equal(first, second, third);
    }

    return;

    static void Validate()
    {

    }
  }
}