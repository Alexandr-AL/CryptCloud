using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CryptCloud.Infrastructure.Navigation;

namespace CryptCloud.ViewModels.Home
{
    public partial class DiskConnectionPageViewModel :ViewModelBase
    {
        [RelayCommand]
        private void ConnectDisk()
        {
            WeakReferenceMessenger.Default.Send(new ConnectDiskChangedMessage(0));
        }
    }
}
