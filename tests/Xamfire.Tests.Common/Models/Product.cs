using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Tests.Common.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
    }
}
