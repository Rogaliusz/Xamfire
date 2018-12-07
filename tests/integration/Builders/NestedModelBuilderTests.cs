using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamfire.Contexts.Configurations;
using Xamfire.Tests.Common.Models;
using Xamfire.Tests.Integration.Samples;
using Xunit;

namespace Xamfire.Tests.Integration.Builders
{
    public class NestedModelBuilderTests : IntegrationTestBase<User>
    {
        [Fact]
        public void document_builder_for_nested_object_should_generate_nested_json()
        {
            var documentBuilder = GetBuilder();
            var user = Users.GetUser();

            documentBuilder.SetModelConfiguration(GetModelConfiguration());

            var json = documentBuilder.BuildFirebaseDocument(user);
            var expectedJson = File.ReadAllText(Path.Combine("Samples", "UserDocument.txt"));

            json.Should().Be(expectedJson);
        }


        protected override IModelConfiguration<User> GetModelConfiguration()
        {
            return new ModelConfiguration<User>()
                .SetDocumentPath("users")
                .SetPrimaryKey(user => user.Id);
        }
    }
}
