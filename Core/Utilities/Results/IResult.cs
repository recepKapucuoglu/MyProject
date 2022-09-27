using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {       
            // temel alınacak bilgiler
         bool Success { get;  }

         string Message { get; }
    }
}
