using CleanArch.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
