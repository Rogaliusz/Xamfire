﻿using Xamfire.Contexts;
using Xamfire.Document.Configurations;
using Xamfire.Tests.Common.Models;

namespace Xamfire.Tests.Common.Contexts
{
    public class ProductContext : FirebaseContextBase<Product>
    {
        public override void Configure(IDocumentConfiguration<Product> modelConfiguration)
        {
            modelConfiguration.SetDocumentPath("products")
                .SetPropertyName(product => product.Name, "name_s")
                .SetPropertyName(product => product.Description, "description")
                .SetPropertyName(product => product.Id, "id")
                .SetPropertyName(product => product.Count, "count")
                .SetPrimaryKey(x => x.Id);
        }
    }
}
