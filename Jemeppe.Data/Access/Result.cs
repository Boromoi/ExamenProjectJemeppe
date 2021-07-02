using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Data.Access
{
    /// <summary>
    /// Indicates if the action was a success and if not why it failed
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Indicator of success
        /// </summary>
        public bool Successful { get; set; } = true;
        /// <summary>
        /// Message returned
        /// </summary>
        public string Message { get; set; } = "";
        /// <summary>
        /// Returns a failed Result
        /// </summary>
        public static Result Failed(string message)
        {
            return new Result { Message = message, Successful = false };
        }
        /// <summary>
        /// Returns a successful result
        /// </summary>
        /// <returns></returns>
        public static Result Success()
        {
            return new Result();
        }

        /// <summary>
        /// Implicit convertion to boolean
        /// </summary>
        /// <param name="result"></param>
        public static implicit operator bool(Result result)
        {
            return result.Successful;
        }
    }
}
