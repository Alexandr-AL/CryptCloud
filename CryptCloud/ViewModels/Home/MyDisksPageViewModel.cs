using CommunityToolkit.Mvvm.ComponentModel;
using CryptCloud.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CryptCloud.Infrastructure;
using CryptCloud.Infrastructure.Navigation;

namespace CryptCloud.ViewModels.Home
{
    public partial class MyDisksPageViewModel : ViewModelBase
    {
        private readonly IPageFactory _pageFactory;

        public MyDisksPageViewModel() : this(default!) { } //For design mode
        public MyDisksPageViewModel(IPageFactory pageFactory)
        {
            _pageFactory = pageFactory;
        }
        
        [ObservableProperty]
         public partial ObservableCollection<object> Disks { get; set; } =
             [
                 new Disk() {Id = 0, Name = "Disk 1", Description = "Description 1", TotalSpaceInMegaBytes = 100000, FreeSpaceInMegaBytes = 50000 },
                 new Disk() {Id = 1, Name = "Disk 2", Description = "Description 2", TotalSpaceInMegaBytes = 120000, FreeSpaceInMegaBytes = 60000 },
                 new Disk() {Id = 2, Name = "Disk 3", Description = "Description 3", TotalSpaceInMegaBytes = 130000, FreeSpaceInMegaBytes = 45000 },
                 new Disk() {Id = 3, Name = "Disk 4", Description = "Description 4", TotalSpaceInMegaBytes = 140000, FreeSpaceInMegaBytes = 77000 },
                 new AddButton()
             ];

        [RelayCommand]
        private void GoToFilesPage()
        {
            WeakReferenceMessenger.Default.Send(
                new NavigationForHomePageChangedMessage(_pageFactory.GetPageViewModel<FilesPageViewModel>()));
        }
    }
}
