// (c) 2025 PatitosEnLinea MIT License <jbgarcia@uvigo.es>


namespace PatitosEnLinea.Core;


using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;


public class MommyDuck {
    private const int NUM_TIMES_MOTIVATION = 32;

    public MommyDuck()
    {
        this._ducklings = new List<Duckling>();
        this.Heading = new Random( DateTime.Now.Ticks.GetHashCode() ).Next( 0, 360 );
    }

    public IList<Duckling> Ducklings {
        get => this._ducklings.AsReadOnly();
        set {
            this._ducklings.Clear();
            ( (List<Duckling>) this._ducklings ).AddRange( value );
        }
    }

    public void Motivate()
    {
        var rnd = new Random( DateTime.Now.Millisecond );

        Trace.WriteLine( "Motivate(): enter" );
        Trace.Indent();
        Trace.WriteLine( this.ToString() );

        for(int i = 0; i < NUM_TIMES_MOTIVATION; ++i) {
            foreach(Duckling duckling in this._ducklings) {
                Debug.Assert( duckling.Heading >= 0 && duckling.Heading <= 360,
                              "ducking wrong heading: " + duckling.Heading );

                if ( !duckling.IsInLine( this.Heading ) ) {
                    duckling.ReceiveMotivation( rnd.Next( 0, 10 ) );
                }
            }

            Trace.WriteLine( $"Motivation/{i} {this.ToString()}" );
        }

        this.AllInLine();
    }

    [Conditional("DEBUG")]
    private void AllInLine()
    {
        Trace.WriteLine( "AllInLine(): enter" );
        Trace.Indent();

        Trace.WriteLine( this.ToString() );
        Debug.Assert( this._ducklings.All( p => p.IsInLine( this.Heading ) ),
                      "ducklings not inline" );

        Trace.Unindent();
        Trace.WriteLine( "AllInLine(): finished" );
    }

    public override string ToString()
    {
        return $"Mommy duck {this.Heading}º -> " + string.Join( " - ", this._ducklings );
    }

    public int Heading { get; private set; }

    private IList<Duckling> _ducklings;
}
