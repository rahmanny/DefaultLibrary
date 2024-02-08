using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using DefaultLibrary.Shared;

namespace DefaultLibrary.Response
{
    public abstract class DefaultResponse
    {
        private readonly List<Error> _errors = new List<Error>();
        
        public bool HasErrors => _errors.Any();
        public Status Status { get; private set; }
        public IImmutableList<Error> Errors => _errors.ToImmutableList();

        protected void AddError(string? message, string[]? properties, string? method)
        {
            _errors.Add(new Error
            {
                Message = message,
                Properties = properties,
                Method = method
            });
        }
        
    }
}