﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HenDevFramework.Northwind.Entities.Concrete;

namespace InterfaceWeb.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
    }
}