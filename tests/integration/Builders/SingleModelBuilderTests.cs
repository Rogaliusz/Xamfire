using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamfire.Contexts.Configurations;
using Xamfire.Tests.Common.Models;
using Xunit;

namespace Xamfire.Tests.Integration.Builders
{
    public class SingleModelBuilderTests : IntergationTestBase<Product>
    {
        [Fact]
        public void document_builder_should_generate_correct_json()
        {
            var documentBuilder = GetBuilder();
            var product = Products.SamplesProducts[0];
            var address = $"{FirebaseSettingsMock.Url}/products/{product.Id}.json/?auth={FirebaseSettingsMock.UserToken}";

            documentBuilder.SetModelConfiguration(GetModelConfiguration());

            var json = File.ReadAllText(Path.Combine("Samples", "ProductDocument.txt"));
            var model = documentBuilder.BuildModel(json, address);

            model.Id.Should().Be(product.Id);
            model.Name.Should().Be(product.Name);
            model.Count.Should().Be(product.Count);
            model.Description.Should().Be(product.Description);
        }

        protected override IModelConfiguration<Product> GetModelConfiguration()
        {
            return new ModelConfiguration<Product>()
                .SetDocumentPath("products")
                .SetPrimaryKey(product => product.Id);
        }
    }
}
