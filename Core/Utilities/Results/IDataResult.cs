using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult    // sen hem bir T datası döndür hemde ıresult verilerni döndür.success ve meessage
    {                   //interface interfaceyi iplemente ettiğinde veriyi kullanır .ama buraya  düşmez.
        

        //alınacak data bilgisi 
        T Data { get; }
    }
}
