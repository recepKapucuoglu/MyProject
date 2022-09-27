using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {       //olasılıklar. kullanıcı data verip mesaj vermemesi ,hiç birini vermemesi gibi olasılıkları hesaplayıp yazdık.
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)    // default=data ya karşılık gelir.datada bişey döndürmek istenmediğinde 
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
