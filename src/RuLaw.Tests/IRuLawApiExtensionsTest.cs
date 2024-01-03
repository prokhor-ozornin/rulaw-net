﻿using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IRuLawApiExtensions"/>.</para>
/// </summary>
public sealed class IRuLawApiExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IRuLawApiExtensions.Configure(IRuLawApi, Action{IApiConfigurator})"/> method.</para>
  /// </summary>
  [Fact]
  public void Configure_Method()
  {
    AssertionExtensions.Should(() => IRuLawApiExtensions.Configure(null, _ => {})).ThrowExactly<ArgumentNullException>().WithParameterName("api");
    AssertionExtensions.Should(() => IRuLawApiExtensions.Configure(RuLaw.Api, null)).ThrowExactly<ArgumentNullException>().WithParameterName("action");
    AssertionExtensions.Should(() => RuLaw.Api.Configure(_ => {})).ThrowExactly<InvalidOperationException>();

    var api = RuLaw.Api.Configure(configurator => configurator.ApiKey("apiKey").AppKey("appKey"));
    api.Should().NotBeNull().And.BeOfType<Api>();
    api.GetPropertyValue<string>("ApiToken").Should().Be("apiKey");
    api.GetPropertyValue<string>("AppToken").Should().Be("appKey");
  }
}