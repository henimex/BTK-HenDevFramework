using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Core.Entities;

namespace HenDevFramework.Northwind.Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
