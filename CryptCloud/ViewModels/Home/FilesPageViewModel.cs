using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CryptCloud.Infrastructure.Navigation;
using CryptCloud.Models;

namespace CryptCloud.ViewModels.Home
{
    public partial class FilesPageViewModel : ViewModelBase
    {
        public FilesPageViewModel()
        {
            foreach (var item in FilesCollection) 
                Files.Add(item);
            
            Files.Add(new AddButton());

            foreach (var item in FilesCollection.Take(4))
                FilesLasts.Add(item);
        }
        
        private List<object> FilesCollection { get; set; } = 
        [
            new Folder() { Id = 0, Name = "Folder 1" },
            new Folder() { Id = 1, Name = "Folder 2" },
            new Folder() { Id = 2, Name = "Folder 3" },
            new File() { Id = 3, Name = "File 1.png" },
            new File() { Id = 4, Name = "File 2.png" },
        ];
        
        [ObservableProperty]
        public partial Disk Disk { get; set; } =
            new(){ Id = 0, Name = "Disk 1", Description = "Description 1", TotalSpaceInMegaBytes = 100000, FreeSpaceInMegaBytes = 50000 };

        [ObservableProperty] 
        public partial ObservableCollection<object> Files { get; set; } = [];

        [ObservableProperty] 
        public partial ObservableCollection<object> FilesLasts { get; set; } = [];

        [RelayCommand]
        private void ShowTopContentElement(object parameter)
        {
            WeakReferenceMessenger.Default.Send(new ShowTopContentElementChangedMessage(true));
        }
    }
}
