using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Document.Configurations
{
    public class ChildDocumentConfiguration<TRootModel, TChildModel> : DocumentConfiguration<TChildModel>, IChildDocumentConfiguration<TRootModel, TChildModel>
    {
        public string PropertyName { get; }
        public IDocumentConfiguration<TRootModel> Root { get; }

        public ChildDocumentConfiguration(IDocumentConfiguration<TRootModel> root, string propertyName)
        {
            Root = root;
            PropertyName = propertyName;
        }
    }
}
