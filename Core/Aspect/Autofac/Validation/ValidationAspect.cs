using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofac.Validation
{

    public class ValidationAspect : MethodInterception   //ASPECT==METOTUN BASINDA SONUNDA YADA HATA VERDİĞİNDE CALISACAK YAPI.  
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)  //validatorType = add metutunun üstünde tanımlanan productValidator
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))  // IVALİDATOR= PRODUCTVALİDATİON İNTERFACESİDİR.


            {
                throw new System.Exception("bu bir dogrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);  
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)  
                ValidationTool.Validate(validator, entity); 
            }
        }
    }
}
