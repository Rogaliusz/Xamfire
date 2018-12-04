using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Xamfire.Tests.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand GoToLoginTestCommand => new DelegateCommand(async () => await NavigateToViewModel<LoginViewModel>());
        public ICommand GoToRegisterTestCommand => new DelegateCommand(async () => await NavigateToViewModel<RegisterViewModel>());
        public ICommand GoToAuthTestCommand => new DelegateCommand(async () => await NavigateToViewModel<LoginViewModel>());

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

    }
}
