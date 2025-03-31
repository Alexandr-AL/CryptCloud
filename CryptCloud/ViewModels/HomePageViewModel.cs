using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CryptCloud.Models;
using CryptCloud.ViewModels.Home;
using System.Collections.ObjectModel;
using CryptCloud.Infrastructure;
using CryptCloud.Infrastructure.Navigation;

namespace CryptCloud.ViewModels
{
    public partial class HomePageViewModel : ViewModelBase
    {
        private readonly IPageFactory _pageFactory;

        public HomePageViewModel() : this(new PageFactory()){ } //For design mode
        public HomePageViewModel(IPageFactory pageFactory)
        {
            _pageFactory = pageFactory;
            
            CurrentPageForHomePage = _pageFactory.GetPageViewModel<DiskConnectionPageViewModel>();
            
            WeakReferenceMessenger.Default.Register<ConnectDiskChangedMessage>(this, ConnectDiskMessageHandler);
            WeakReferenceMessenger.Default.Register<NavigationForHomePageChangedMessage>(this, NavigationForHomePageMessageHandler);
            WeakReferenceMessenger.Default.Register<ShowTopContentElementChangedMessage>(this, ShowTopContentElementMessageHandler);
        }

        [ObservableProperty]
        public partial ObservableCollection<Disk> Disks { get; set; } =
            [
                new Disk() {Id = 0, Name = "Disk 1", Description = "Description 1", TotalSpaceInMegaBytes = 100000, FreeSpaceInMegaBytes = 50000 },
                new Disk() {Id = 1, Name = "Disk 2", Description = "Description 2", TotalSpaceInMegaBytes = 120000, FreeSpaceInMegaBytes = 60000 },
                new Disk() {Id = 2, Name = "Disk 3", Description = "Description 3", TotalSpaceInMegaBytes = 130000, FreeSpaceInMegaBytes = 45000 },
                new Disk() {Id = 3, Name = "Disk 4", Description = "Description 4", TotalSpaceInMegaBytes = 140000, FreeSpaceInMegaBytes = 77000 }
            ];
        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(LatestPageIsActive))]
        [NotifyPropertyChangedFor(nameof(FilesPageIsActive))]
        [NotifyPropertyChangedFor(nameof(MyDisksPageIsActive))]
        [NotifyPropertyChangedFor(nameof(DownloadsPageIsActive))]
        [NotifyPropertyChangedFor(nameof(SettingsPageIsActive))]
        [NotifyPropertyChangedFor(nameof(TrashCanPageIsActive))]
        public partial ViewModelBase CurrentPageForHomePage {  get; set; }

        [ObservableProperty]
        public partial bool IsVisibleTopContentElement { get; set; }
        
        [ObservableProperty]
        public partial bool MenuIsVisible { get; set; }
        
        private int _selectedDiskItem = -1;
        public int SelectedDiskItem
        {
            get => _selectedDiskItem;
            set
            {
                SetProperty(ref _selectedDiskItem, value);
                MenuIsVisible = _selectedDiskItem > -1;
                GoToFilesPage();
            }
        }

        public bool LatestPageIsActive => CurrentPageForHomePage is LatestPageViewModel;
        public bool FilesPageIsActive => CurrentPageForHomePage is FilesPageViewModel;
        public bool MyDisksPageIsActive => CurrentPageForHomePage is MyDisksPageViewModel;
        public bool DownloadsPageIsActive => CurrentPageForHomePage is DownloadsPageViewModel;
        public bool SettingsPageIsActive => CurrentPageForHomePage is SettingsPageViewModel;
        public bool TrashCanPageIsActive => CurrentPageForHomePage is TrashCanPageViewModel;

        [RelayCommand]
        private void GoToLatestPage() => CurrentPageForHomePage = _pageFactory.GetPageViewModel<LatestPageViewModel>();

        [RelayCommand]
        private void GoToFilesPage() => CurrentPageForHomePage = _pageFactory.GetPageViewModel<FilesPageViewModel>();

        [RelayCommand]
        private void GoToMyDisksPage() => CurrentPageForHomePage = _pageFactory.GetPageViewModel<MyDisksPageViewModel>();
        
        [RelayCommand]
        private void GoToDownloadsPage() => CurrentPageForHomePage = _pageFactory.GetPageViewModel<DownloadsPageViewModel>();
        
        [RelayCommand]
        private void GoToSettingsPage() => CurrentPageForHomePage = _pageFactory.GetPageViewModel<SettingsPageViewModel>();
        
        [RelayCommand]
        private void GoToTrashCanPage() => CurrentPageForHomePage = _pageFactory.GetPageViewModel<TrashCanPageViewModel>();

        private void ConnectDiskMessageHandler(object recipient, ConnectDiskChangedMessage message)
        {
            SelectedDiskItem = message.Value;
            GoToMyDisksPage();
        }
        
        private void NavigationForHomePageMessageHandler(object recipient, NavigationForHomePageChangedMessage message)
        {
            CurrentPageForHomePage = message.Value;
        }
        
        private void ShowTopContentElementMessageHandler(object recipient, ShowTopContentElementChangedMessage message)
        {
            IsVisibleTopContentElement = message.Value;
        }
    }
}
