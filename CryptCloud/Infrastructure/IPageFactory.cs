using CryptCloud.ViewModels;

namespace CryptCloud.Infrastructure;

public interface IPageFactory
{
    ViewModelBase GetPageViewModel<T>() where T : ViewModelBase;
}