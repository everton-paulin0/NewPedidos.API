﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class CreateProductInputModel
    {
        [Required]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public int OrderId { get; set; }


        public Product ToEntityProduct()
            => new Product(ProductName, Quantity, Price, OrderId);
    }
}
