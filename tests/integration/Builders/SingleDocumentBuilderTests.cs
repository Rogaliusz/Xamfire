using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamfire.Document.Configurations;
using Xamfire.Tests.Common.Models;
using Xunit;

namespace Xamfire.Tests.Integration.Builders
{
    public class SingleDocumentBuilderTests : IntegrationTestBase<Product>
    {
        [Fact]
        public void document_builder_should_generate_correct_insert_path()
        {
            var documentBuilder = GetBuilder();
            var product = Products.SamplesProducts[0];

            documentBuilder.SetModelConfiguration(GetModelConfiguration());

            var insertPath  = documentBuilder.GetDocumentPath(product);

            insertPath.Should().Be($"{FirebaseSettingsMock.Url}/products/{product.Id}.json/?auth={FirebaseSettingsMock.UserToken}");   
        }

        [Fact]
        public void document_builder_should_generate_correct_get_path()
        {
            var documentBuilder = GetBuilder();
            var product = Products.SamplesProducts[0];

            documentBuilder.SetModelConfiguration(GetModelConfiguration());

            var getPath = documentBuilder.GetDocumentPath();

            getPath.Should().Be($"{FirebaseSettingsMock.Url}/products.json/?auth={FirebaseSettingsMock.UserToken}");
        }

        [Fact]
        public void document_builder_for_simple_should_generate_correct_json()
        {
            var documentBuilder = GetBuilder();
            var product = Products.SamplesProducts[0];

            documentBuilder.SetModelConfiguration(GetModelConfiguration());

            var json = documentBuilder.BuildFirebaseDocument(product);
            var expectedJson = File.ReadAllText(Path.Combine("Samples", "ProductDocument.txt"));

            json.Should().Be(expectedJson);
        }

        protected override IDocumentConfiguration<Product> GetModelConfiguration()
        {
            return new DocumentConfiguration<Product>()
                .SetDocumentPath("products")
                .SetPrimaryKey( product => product.Id);
        }
    }
}
