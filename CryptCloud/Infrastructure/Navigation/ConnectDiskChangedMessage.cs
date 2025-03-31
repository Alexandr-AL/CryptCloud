using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CryptCloud.Infrastructure.Navigation
{
    public class ConnectDiskChangedMessage : ValueChangedMessage<int>
    {
        public ConnectDiskChangedMessage(int connectDisc) : base(connectDisc) { }
    }
}
