using CommunityToolkit.Mvvm.Messaging.Messages;
using CryptCloud.ViewModels;

namespace CryptCloud.Infrastructure.Navigation
{
    public class NavigationForMainWindowChangedMessage : ValueChangedMessage<ViewModelBase>
    {
        public NavigationForMainWindowChangedMessage(ViewModelBase currentPage) : base(currentPage) { }
    }
}
