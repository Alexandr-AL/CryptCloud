using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CryptCloud.Infrastructure.Navigation;

public class ShowTopContentElementChangedMessage : ValueChangedMessage<bool>
{
    public ShowTopContentElementChangedMessage(bool isVisible) : base(isVisible)
    {
    }
}