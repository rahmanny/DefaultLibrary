using System.Diagnostics;

namespace DefaultLibrary.Shared
{
    /// <summary>
    /// Error object
    /// </summary>
    public class Error
    {
        
        /// <summary>
        /// Error message
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// Properties that caused the error
        /// </summary>
        public string[]? Properties { get; set; }
        /// <summary>
        /// Method that caused the error
        /// </summary>
        public string? Method { get; set; }
        /// <summary>
        /// Stack trace of the error
        /// </summary>
        public StackTrace? StackTrace { get; set; }
    }
}