using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Document.Configurations
{
    public interface IChildDocumentConfiguration<TRootModel, TChildModel> : IDocumentConfiguration<TChildModel>
    {
        string PropertyName { get; }
        IDocumentConfiguration<TRootModel> Root { get; }
    }
}
