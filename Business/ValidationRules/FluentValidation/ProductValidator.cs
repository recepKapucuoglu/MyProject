using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product> //abstracvalidation içinde ıvalidator interfacesidir. o yuüzdden referansını kullancaz.
    {
          
         
        public ProductValidator()  //kurallar CONSTRUCTOR iiçine yazılır 
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            //kendimiz kural ekleyelim;  (productname'in A ile başlamasını kurgulayalım)
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("'A' harfi ile başlamalı.");
        }


        private bool StartWithA(string arg)   
        {
            return arg.StartsWith("A");
        }
    }
}
