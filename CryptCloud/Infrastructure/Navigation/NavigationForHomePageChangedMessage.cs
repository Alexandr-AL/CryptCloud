using CommunityToolkit.Mvvm.Messaging.Messages;
using CryptCloud.ViewModels;

namespace CryptCloud.Infrastructure.Navigation;

public class NavigationForHomePageChangedMessage : ValueChangedMessage<ViewModelBase>
{
    public NavigationForHomePageChangedMessage(ViewModelBase value) : base(value)
    {
    }
}