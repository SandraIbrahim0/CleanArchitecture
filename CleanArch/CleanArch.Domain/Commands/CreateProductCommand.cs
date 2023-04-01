using CleanArch.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands
{
    public class CreateProductCommand : ProductCommand
    {
        public CreateProductCommand(string name, string description, int quantity, float price)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
        }
    }
}
