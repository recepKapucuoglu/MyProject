using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{ // data da döndüren metotlar için;
    public class DataResult<T> : Result, IDataResult<T>
    {                                                               //result kodlarını tekrar burada yazmayalım diye base seklinde gönderdik.
        public DataResult(T data,bool success,string message):base(success,message)  // message girilmisse contructor bunu seçer. base : result
        {
            Data = data; 
        }
        public DataResult(T data,bool success):base(success) // girilmemisse bunu secer.    OVERLOADİNG DURUMU.
        {
            Data = data;
        }
        public T Data { get; }
    }
}
