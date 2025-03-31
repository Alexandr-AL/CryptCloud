using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CryptCloud.ViewModels;

namespace CryptCloud
{
    public class ViewLocator : IDataTemplate
    {

        public Control? Build(object? param)
        {
            if (param is null)
                return null;

            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type is null)
                return new TextBlock { Text = "Not Found: " + name };

            return (Control)Activator.CreateInstance(type)!;
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
