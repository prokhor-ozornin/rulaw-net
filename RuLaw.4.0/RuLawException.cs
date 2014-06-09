﻿using System;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Base exception that represents a failure in the process of RuLaw API method call.</para>
  /// </summary>
  public sealed class RuLawException : Exception
  {
    /// <summary>
    ///   <para>Initializes a new instance of the exception with a specified error message and a reference to the inner exception that is the cause of this exception.</para>
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a <c>null</c> reference if no inner exception is specified.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="message"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="message"/> is <see cref="string.Empty"/> string.</exception>
    public RuLawException(string message, Exception innerException = null) : base(message, innerException)
    {
      Assertion.NotEmpty(message);
    }
  }
}