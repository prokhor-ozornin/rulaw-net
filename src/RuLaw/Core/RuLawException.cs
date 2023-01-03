namespace RuLaw;

/// <summary>
///   <para>Base exception that represents a failure in the process of RuLaw API method call.</para>
/// </summary>
public sealed class RuLawException : ApplicationException
{
  /// <summary>
  ///   <para>Error that explains the reason for the exception.</para>
  /// </summary>
  public Error Error { get; }

  /// <summary>
  ///   <para>Initializes a new instance of the exception with a specified error message and a reference to the inner exception that is the cause of this exception.</para>
  /// </summary>
  /// <param name="error">The error that explains the reason for the exception.</param>
  /// <param name="inner">The exception that is the cause of the current exception, or a <c>null</c> reference if no inner exception is specified.</param>
  public RuLawException(Error error = null, Exception inner = null) : base(error?.Text, inner) => Error = error;
}