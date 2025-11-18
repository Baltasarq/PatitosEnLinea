

using System;
using System.Diagnostics;

namespace PatitosEnLinea.Core;


public class Pato
{
    public Pato()
    {
        this.Dir = new Random( DateTime.Now.Microsecond ).
                            Next( 0, 360 );
    }

    public override string ToString()
    {
        return $"¡Cuac! {this.Dir}º";
    }

    public int Dir {
        get => field;
        protected set {
            Debug.Assert( value >= 0 && value < 360,
                            $"0 <= {value} < 360!!" );
            field = value;
        }
    }
}
