// (c) 2025 PatitosEnLinea Baltasar MIT License <jbgarcia@uvigo.es>


namespace PatitosEnLinea.UI;

using System.Diagnostics;
using Avalonia.Controls;
using PatitosEnLinea.Core;


public class MainWindowCore {
    public MainWindowCore()
    {
        Trace.Listeners.Add( new ConsoleTraceListener() );
        Trace.Listeners.Add( new TextWriterTraceListener( "patitos.log" ) );

        this.Vista = new MainWindow();
        this._edLog = this.Vista.GetControl<TextBox>( "EdLog" );
        this.Init();

        this.Vista.Closing += (_, _) => this.Quit();
    }

    private void Quit()
    {
        Trace.Close();
    }

    private void Init()
    {
        var mp = new MamaPato();
        var p1 = new Patito();
        var p2 = new Patito();
        var p3 = new Patito();

        mp.Patitos = [ p1, p2, p3 ];
        this._edLog.Text += mp.ToString() + "\n";

        for(int _ = 0; _ < 15; ++_ ) {
            mp.Motiva();
            this._edLog.Text += mp + "\n";
        }
    }

    public MainWindow Vista { get; private set; }
    private TextBox _edLog;
}
