﻿using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawSubject"/>.</para>
/// </summary>
public sealed class LawSubjectTest : UnitTest<LawSubject>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawSubject.Departments"/> property.</para>
  /// </summary>
  [Fact]
  public void Departments_Property()
  {
    var subject = new LawSubject(new {});
    subject.Departments.Should().BeEmpty();

    var department = new Authority(new {});

    var departments = subject.Departments.To<List<Authority>>();
    departments.Add(department);
    subject.Departments.Should().ContainSingle().Which.Should().BeSameAs(department);
    departments.Remove(department);
    subject.Departments.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawSubject.Deputies"/> property.</para>
  /// </summary>
  [Fact]
  public void Deputies_Property()
  {
    var subject = new LawSubject(new {});
    subject.Deputies.Should().BeEmpty();

    var deputy = new Deputy(new {});

    var deputies = subject.Deputies.To<List<Deputy>>();

    deputies.Add(deputy);
    subject.Deputies.Should().ContainSingle().Which.Should().BeSameAs(deputy);
    deputies.Remove(deputy);
    subject.Deputies.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawSubject(IEnumerable{IAuthority}?, IEnumerable{IDeputy}?)"/>
  /// <seealso cref="LawSubject(LawSubject.Info)"/>
  /// <seealso cref="LawSubject(object)"/>
  [Fact]
  public void Constructors()
  {
    var subject = new LawSubject();
    subject.Departments.Should().BeEmpty();
    subject.Deputies.Should().BeEmpty();

    subject = new LawSubject(new LawSubject.Info());
    subject.Departments.Should().BeEmpty();
    subject.Deputies.Should().BeEmpty();

    subject = new LawSubject(new {});
    subject.Departments.Should().BeEmpty();
    subject.Deputies.Should().BeEmpty();
  }
}

/// <summary>
///   <para>Tests set for class <see cref="LawSubject.Info"/>.</para>
/// </summary>
public sealed class LawSubjectInfoTests : UnitTest<LawSubject.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LawSubject.Info.Departments"/> property.</para>
  /// </summary>
  [Fact]
  public void Departments_Property()
  {
    var departments = new List<Authority>();
    new LawSubject.Info {Departments = departments}.Departments.Should().BeSameAs(departments);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawSubject.Info.Deputies"/> property.</para>
  /// </summary>
  [Fact]
  public void Deputies_Property()
  {
    var deputies = new List<Deputy>();
    new LawSubject.Info {Deputies = deputies}.Deputies.Should().BeSameAs(deputies);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawSubject.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new LawSubject.Info();
    info.Departments.Should().BeNull();
    info.Deputies.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawSubject.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    var result = new LawSubject.Info().ToResult();
    result.Should().NotBeNull().And.BeOfType<LawSubject>();
    result.Departments.Should().BeEmpty();
    result.Deputies.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new LawSubject.Info
    {
      Departments = new List<Authority> {new(new {Id = 1})},
      Deputies = new List<Deputy> {new(new {Id = 2})}
    };

    info.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}