using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity        // tüm katmanların erişmesi için PUBLİC.
        //IEntity Productin referansını tutabiliyor artık.
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }

        public short UnitsInStock { get; set; }

        public decimal  UnitPrice { get; set; }

    }
}
