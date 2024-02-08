using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using DefaultLibrary.Shared;

namespace DefaultLibrary.Response
{
    /// <summary>
    /// Abstract class for response objects
    /// </summary>
    public abstract class DefaultResponse
    {
        private readonly List<Error> _errors = new List<Error>();
        
        /// <summary>
        /// Indicates if the response has errors
        /// </summary>
        public bool HasErrors => _errors.Any();
        /// <summary>
        /// Status of the response
        /// </summary>
        public Status Status { get; private set; }
        /// <summary>
        /// List of errors
        /// </summary>
        public IImmutableList<Error> Errors => _errors.ToImmutableList();

        /// <summary>
        /// Adds an error to the response
        /// </summary>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        /// <param name="method"></param>
        /// <param name="stackTrace"></param>
        public void AddError(string message, string[]? properties = null, string? method = null, StackTrace? stackTrace = null)
        {
            _errors.Add(new Error
            {
                Message = message,
                Properties = properties,
                Method = method,
                StackTrace = stackTrace
            });
            Status = Status.Error;
        }
    }
}