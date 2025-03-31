using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using CryptCloud.ViewModels;
using CryptCloud.ViewModels.Home;

namespace CryptCloud.Infrastructure;

public class PageFactory : IPageFactory
{
    public ViewModelBase GetPageViewModel<T>() where T : ViewModelBase
    {
        var pageType = Ioc.Default.GetService<T>();
        
        if (pageType == null) throw new InvalidOperationException();
        
        return pageType;
    }
}