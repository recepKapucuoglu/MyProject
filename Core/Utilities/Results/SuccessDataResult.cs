using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{           //DataResult ilede yapılabilir altyapıyı geliştirmek için bu şekide succes ve error için 2 farklı durum clasları kullanıldı.
    public class SuccessDataResult<T>:DataResult<T> 
    {       //olasılıklar. kullanıcı data verip mesaj vermemesi ,hiç birini vermemesi gibi olasılıkları hesaplayıp yazdık.
        public SuccessDataResult(T data ,string message):base(data,true,message)
        {

        }
        public SuccessDataResult(T data):base(data,true)
        {

        }
        public SuccessDataResult(string message):base(default,true,message)    // default=data ya karşılık gelir.datada bişey döndürmek istenmediğinde 
        {

        }
        public SuccessDataResult():base(default,true) 
        {

        }
    }
}
