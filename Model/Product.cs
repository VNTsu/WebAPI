using System.Data.Common;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass2.Model
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string Manufacture { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
    }
}