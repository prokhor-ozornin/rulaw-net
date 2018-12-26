namespace RuLaw
{
  using System;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Base exception that represents a failure in the process of RuLaw API method call.</para>
  /// </summary>
  public sealed class RuLawException : ApplicationException
  {
    /// <summary>
    ///   <para>Initializes a new instance of the exception with a specified error message and a reference to the inner exception that is the cause of this exception.</para>
    /// </summary>
    /// <param name="error">The error that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a <c>null</c> reference if no inner exception is specified.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="error"/> is a <c>null</c> reference.</exception>
    public RuLawException(Error error, Exception innerException = null) : base(error != null ? error.Text : string.Empty, innerException)
    {
      Assertion.NotNull(error);

      Error = error;
    }

    /// <summary>
    ///   <para>Error that explains the reason for the exception.</para>
    /// </summary>
    public Error Error { get; private set; }
  }
}