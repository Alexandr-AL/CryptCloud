using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CryptCloud.Infrastructure;
using CryptCloud.Infrastructure.Navigation;

namespace CryptCloud.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() : this(default!) { } //For design mode
        public MainWindowViewModel(IPageFactory pageFactory)
        {
            CurrentPage = pageFactory.GetPageViewModel<LoginPageViewModel>();

            WeakReferenceMessenger.Default.Register<NavigationForMainWindowChangedMessage>(this, NavigationForMainWindowMessageHandler);
        }

        [ObservableProperty]
        public partial ViewModelBase CurrentPage { get; set; }

        private void NavigationForMainWindowMessageHandler(object recipient, NavigationForMainWindowChangedMessage message)
        {
            CurrentPage = message.Value;
        }
    }
}
