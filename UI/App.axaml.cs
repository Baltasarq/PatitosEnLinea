// (c) 2025 PatitosEnLinea Baltasar MIT License <jbgarcia@uvigo.es>


namespace PatitosEnLinea.UI;


using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;


public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindowCore().Vista;
        }

        base.OnFrameworkInitializationCompleted();
    }
}