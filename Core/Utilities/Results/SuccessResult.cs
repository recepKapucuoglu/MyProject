using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {       
        public SuccessResult(string message) : base(true, message)                //base: inherit aldıgı clas =Result klasındaki true ve message olan constructor.
        {
            
        }
        
        public SuccessResult() : base(true)         // base clasındaki=result clasındaki ; true constructoru             
        {

        }
        //CONSTRUCTOR İnheritten dolayı kullanıldı
    }
}
