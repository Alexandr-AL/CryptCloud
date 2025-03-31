using Avalonia.Controls;
using CommunityToolkit.Mvvm.Messaging;
using CryptCloud.Infrastructure.Navigation;

namespace CryptCloud.Views;

public partial class TopContentElementView : UserControl
{
    public TopContentElementView()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        WeakReferenceMessenger.Default.Send(new ShowTopContentElementChangedMessage(false));
    }
}