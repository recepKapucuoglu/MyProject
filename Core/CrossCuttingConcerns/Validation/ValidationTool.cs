using Core.Utilities.Results;
using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool  
    {
        public static void Validate(IValidator valitator,object entity)   //IVALİDATOR ==PRODUCTVALİDATİON (abstractVALİDATORDE F12 İLE GEZERSEN GÖRÜRSÜN )   ,OBJECT= PRODUCT
        {
            //soyutlayıp merkezi yapı halinde.

            var context = new ValidationContext<object>(entity);  // product listeme validation uygula dedik. ve 2. productta productu paramametre olarak verdik.
            var result = valitator.Validate(context); //kurallarımızı ilgili context'e (product nesnemize) uygula.
            if (!result.IsValid)// resul geçerli degilse .
            {
                throw new ValidationException(result.Errors);   // hata fırlat.
            }




            // Soyutlama olmadan.

            //var context = new ValidationContext<Product>(product);  // product listeme validation uygula dedik. ve 2. productta productu paramametre olarak verdik.
            //ProductValidator productValidator = new ProductValidator();  //kurallarını yazıdıgmız validationu cagırdık.
            //var result = productValidator.Validate(context); //kurallarımızı ilgili context'e (product nesnemize) uygula.
            //if (!result.IsValid)// resul geçerli degilse .s
            //{
            //    throw new ValidationException(result.Errors);   // hata fırlat.
            //}

        }
    }

}