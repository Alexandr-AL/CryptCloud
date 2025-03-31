using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CryptCloud.Infrastructure;
using CryptCloud.Infrastructure.Navigation;
using CryptCloud.Infrastructure.Validators;
using CryptCloud.Models;
using FluentValidation.Results;

namespace CryptCloud.ViewModels
{
    public partial class LoginPageViewModel : ViewModelBase
    {
        private readonly IPageFactory _pageFactory;
        private readonly UserValidator _userValidator;

        public LoginPageViewModel() : this(default!, default!){ } //For design mode
        public LoginPageViewModel(IPageFactory pageFactory, UserValidator userValidator)
        {
            _pageFactory = pageFactory;
            _userValidator = userValidator;
        }
        
        [ObservableProperty]
        public partial string Email { get; set; } = string.Empty;
        
        [ObservableProperty]
        public partial string Password { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string ErrorText { get; set; } = string.Empty;

        [RelayCommand]
        private void Login()
        {
            ErrorText = string.Empty;
            User user = new() {Email = Email, Password = Password };

            ValidationResult result = _userValidator.Validate(user);

            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                    ErrorText += item.ErrorMessage + "\n";
                
                return;
            }
            
            WeakReferenceMessenger.Default.Send(new NavigationForMainWindowChangedMessage(_pageFactory.GetPageViewModel<HomePageViewModel>()));
        }

        [RelayCommand]
        private void LoginWithGoogle()
        {
            WeakReferenceMessenger.Default.Send(new NavigationForMainWindowChangedMessage(_pageFactory.GetPageViewModel<HomePageViewModel>()));
        }
    }
}
