using Xamfire.Document.Configurations;

namespace Xamfire.Document.Builders
{
    public interface IDocumentModelBuilder<TModel>
    {
        IDocumentModelBuilder<TModel> SetModelConfiguration(IDocumentConfiguration<TModel> modelConfiguration);
        string BuildFirebaseDocument(TModel model);
        TModel BuildModel(string document, string address);
        string GetDocumentPath();
        string GetDocumentPath(object key);
        string GetDocumentPath(TModel model);
    }
}
