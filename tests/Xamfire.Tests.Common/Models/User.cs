using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Tests.Common.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; }
    }
}
