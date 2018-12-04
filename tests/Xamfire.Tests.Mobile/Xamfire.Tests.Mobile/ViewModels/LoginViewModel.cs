using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace Xamfire.Tests.Mobile.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _email;
        private string _password;

        public string Email { get => _email; set => SetProperty(ref _email, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public ICommand LoginCommand => new Command(async () => await LoginAsync());

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private async Task LoginAsync()
        {
            await Xamfire.AuthenticationContext.LoginUserAsync(Email, Password);
        }
    }
}
