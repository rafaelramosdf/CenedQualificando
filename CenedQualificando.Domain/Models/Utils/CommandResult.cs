using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Models.Utils
{
    public class CommandResult
    {
        public CommandResult()
        {
        }

        public CommandResult(int statusCode)
        {
            StatusCode = statusCode;
        }

        public CommandResult(int statusCode, string error)
        {
            StatusCode = statusCode;
            SetError(error);
        }

        public CommandResult(int statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public CommandResult(int statusCode, object data, string error)
        {
            StatusCode = statusCode;
            Data = data;
            SetError(error);
        }

        public object Data { get; set; }
        public int StatusCode { get; set; }
        public ICollection<string> Errors { get; private set; } = new List<string>();
        public bool HasError => Errors.Any();

        public void SetError(string message) 
        {
            if(!string.IsNullOrEmpty(message))
                Errors.Add(message);
        }
        public void SetErrors(List<string> messages)
        {
            foreach (var m in messages)
            {
                Errors.Add(m);
            }
        }
    }
}
