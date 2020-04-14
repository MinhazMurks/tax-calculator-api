﻿namespace TaxCalculator.Responses
{
    /// <summary>
    /// A response that is sent when there is an error.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The message of the error.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Constructor to create a new <see cref="ErrorResponse"/>.
        /// </summary>
        /// <param name="message">The message explaining the error.</param>
        public ErrorResponse(string message)
        {
            ErrorMessage = message;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return ErrorMessage == ((ErrorResponse) obj).ErrorMessage;
        }

        public override int GetHashCode()
        {
            return (ErrorMessage != null ? ErrorMessage.GetHashCode() : 0);
        }
    }
}