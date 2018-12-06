using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Contexts;
using Xamfire.Contexts.Configurations;
using Xamfire.Tests.Mobile.Models;

namespace Xamfire.Tests.Mobile.Contexts
{
    public class ProductContext : FirebaseContextBase<Product>
    {
        public override void Configure(IModelConfiguration<Product> modelConfiguration)
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
