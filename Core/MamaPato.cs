// (c) 2025 PatitosEnLinea Baltasar MIT License <jbgarcia@uvigo.es>


namespace PatitosEnLinea.Core;


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


public class MamaPato: Pato
{
    public MamaPato()
    {
        this._patitos = [];
    }

    public IList<Patito> Patitos
    {
        // get => new List<Patito>( this._patitos );
        get => this._patitos.AsReadOnly();
        set {
            ( (List<Patito>) this._patitos ).AddRange( value );
        }
    }

    public void Motiva()
    {
        Trace.WriteLine( "MamaPato.Motiva()" );
        Trace.Indent();
        Trace.WriteLine( this.ToString() );

        for(int _ = 0; _ < 36; ++_) {
            foreach(Patito patito in this._patitos) {
                if ( !patito.EstaEnLineaCon( this ) )
                {
                    patito.RecibeMotivacion( new Random().Next( 0, 10 ) );
                }
            }
        }

        Trace.Unindent();
        this.TodosPatitosEnLinea();
    }

    [Conditional("DEBUG")]
    private void TodosPatitosEnLinea()
    {
        Trace.WriteLine( this );
        Debug.Assert(
            this._patitos.All( p => p.EstaEnLineaCon( this ) ),
            "patitos fuera de línea" );
    }


    public override string ToString()
    {
        return $"¡CUAC! {this.Dir}º -> "
                + string.Join( " - ", this._patitos );
    }

    private IList<Patito> _patitos;
}
