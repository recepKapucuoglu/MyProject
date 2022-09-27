using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //temel voidler için başlangıç
        public Result(bool success, string message):this(success)  // this(success) => this= bu class.  this(success) =>bu clasdaki success constructor'ı.
                                                                                //hem suucess hem message isterse messagejı buradan succesi alttaki constructordan alsın
                                                                                   // diye this(success) yazdık
        {
            Message = message;
        }

        public Result(bool success)   // message girmesini istemezse const. overloadingden  bunu seçer.
        { 
            Success = success;   
        }

        //CONSTRUCTOR.




        public bool Success { get; }

        public string Message { get; }  //bilgi==>Constructor yapıları === set; özelliği olmayan sadece get özelliği olan degişkenleri set edebilir.! 
                                        // set koymamamızın nedeni => yapıyı bozamasın  degisik kodlar yazılamasın. 
                                               
                                                                                    
    }
}