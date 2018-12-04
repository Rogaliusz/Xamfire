using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamfire.Tests.Mobile.ViewModels;
using Xamfire.Tests.Mobile.Views;

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
        }

        protected override void OnInitialized()
        {
        }
    }
}
