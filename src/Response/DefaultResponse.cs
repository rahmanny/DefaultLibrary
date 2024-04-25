using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
        public Status? Status { get; set; }
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
        public void AddError(string message, string[]? properties = null, string? method = null, string? stackTrace = null)
        {
            _errors.Add(new Error
            {
                Message = message,
                Properties = properties,
                Method = method,
                StackTrace = stackTrace
            });
        }
        
        /// <summary>
        /// Gets the last error message
        /// </summary>
        /// <returns></returns>
        public string GetLastError()
        {
            return !HasErrors ? string.Empty : $"Method:{_errors.Last().Method}, Args:{string.Join(",", _errors.Last().Properties ?? Array.Empty<string>())}, Message:{_errors.Last().Message}, StackTrace:{_errors.Last().StackTrace}";
        }
        
        /// <summary>
        /// Gets all error messages
        /// </summary>
        /// <returns></returns>
        public string GetAllErrors()
        {
            if (!HasErrors)
            {
                return string.Empty;
            }
            var sb = new StringBuilder();
            for (var i = 0; i < _errors.Count; i++)
            {
                sb.Append($"Error[i]: Method:{_errors[i].Method}, Args:{string.Join(",", _errors[i].Properties ?? Array.Empty<string>())}, Message:{_errors[i].Message}, StackTrace:{_errors[i].StackTrace}");
                if (i < _errors.Count - 1)
                {
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }
    }
}