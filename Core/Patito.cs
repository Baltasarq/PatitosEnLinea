// (c) 2025 PatitosEnLinea Baltasar MIT License <jbgarcia@uvigo.es>


namespace PatitosEnLinea.Core;


using System.Diagnostics;


public class Patito: Pato {
    private const int CAMBIO_DIR = 20;
    private const int TOLERANCIA = 30;

    public Patito()
    {
        this.Id = ++numPatitos;
    }

    public int Id { get; private set; }

    /// <summary>Recibe motivación hacia una dirección.</summary>
    /// <param name="fuerza">Fuerza entre 0 y 10.</param>
    public void RecibeMotivacion(int fuerza)
    {
        Debug.Assert( fuerza >= 0 && fuerza < 10,
                    "fuerza incorrecta: " + fuerza );

        if ( fuerza == 0 ) {
            fuerza = 1;
        }

        Trace.WriteLine( $"{this} motivado con fuerza {fuerza}" );

        this.Dir = ( this.Dir
                + (int) ( ( fuerza / 10.0 ) * CAMBIO_DIR ) ) % 360;

        Trace.WriteLine( $"{this} tras ser motivado con fuerza {fuerza}" );
    }

    public bool EstaEnLineaCon(Pato pato)
    {
        return ( this.Dir >= ( pato.Dir - TOLERANCIA )
              && this.Dir <= ( pato.Dir + TOLERANCIA ) );
    }

    public override string ToString()
    {
        return $"{this.Id}/{base.ToString()}";
    }

    private static int numPatitos = 0;
}

