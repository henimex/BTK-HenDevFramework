using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HenDevFramework.Northwind.Business.Constants;
using HenDevFramework.Northwind.Entities.Concrete;

namespace HenDevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(p => p.ProductName).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(p => p.ProductName).Length(2,20).WithMessage(Messages.NotEmpty);
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1).WithMessage(Messages.Price);
            //RuleFor(p => p.ProductName).Must(StartWith);
        }

        private bool StartWith(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
