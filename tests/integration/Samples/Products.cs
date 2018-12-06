using System;
using System.Collections.Generic;
using Xamfire.Tests.Common.Models;
using Xunit;

namespace Xamfire.Tests.Integration
{
    public static class Products
    {
        public static IList<Product> SamplesProducts => new List<Product>
        {
            new Product
            {
                Id = new Guid("8c3f2669-18a1-448c-8a46-e2fe56a2fd8f"),
                Name = "Awesome product",
                Count = 11,
                Description = "My awesome product for first milion Polskich dolarów"
            },
            new Product
            {
                Id = new Guid("f1bdab0c-bef6-415b-8691-6eeaaeebba93"),
                Name = "Super product",
                Count = 0,
                Description = "My super product for first milion Polskich dolarów"
            },
            new Product
            {
                Id = new Guid("db758a16-4a55-40d6-b18a-f59fc2d7b3de"),
                Name = "Oh Product",
                Count = 5,
                Description = "My oh product for first milion Polskich dolarów"
            },
        };
            

    }
}
