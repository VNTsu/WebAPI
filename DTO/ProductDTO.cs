using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass2.DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public string Manufacture { get; set; }
        public Guid CategoryID { get; set; }
    }
}