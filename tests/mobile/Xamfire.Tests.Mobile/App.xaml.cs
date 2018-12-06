using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamfire.Tests.Common.Contexts;
using Xamfire.Tests.Mobile.ViewModels;
using Xamfire.Tests.Mobile.ViewModels.Products;
using Xamfire.Tests.Mobile.Views;
using Xamfire.Tests.Mobile.Views.Products;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xamfire.Tests.Mobile
{
    public partial class App 
    {
        public App()
        {
            Initialize();
            InitializeComponent();

            MainPage = new MainView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainView>();
            containerRegistry.RegisterForNavigation<RegisterView, RegisterViewModel>();
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();

            containerRegistry.RegisterForNavigation<ProductsView, ProductsViewModel>("products");
            containerRegistry.RegisterForNavigation<ProductNewView, ProductNewViewModel>("products-new");

            containerRegistry.RegisterSingleton<ProductContext>();
        }

        protected override void OnInitialized()
        {
        }
    }
}
