// (c) 2025 PatitosEnLinea MIT License <jbgarcia@uvigo.es>


namespace PatitosEnLinea.Core;


using System;


public class Duckling {
    private const int MAX_DEGREES = 20;

    public Duckling()
    {
        this.Id = ++Num;
        this.Heading = new Random( DateTime.Now.Ticks.GetHashCode() ).Next( 0, 360 );
    }

    /// <summary>Receives motivation from mommy duck.</summary>
    /// <param name="force">The force of the motivation, from 0 to 10.</param>
    public void ReceiveMotivation(int force)
    {
        this.Heading = ( this.Heading + ( (int) ( ( ( force / 10.0 ) * MAX_DEGREES ) ) ) ) % 360;
    }

    public bool IsInLine(int mommyHeading)
    {
        int delta = (int) ( MAX_DEGREES * 1.5 );

        return ( this.Heading >= ( mommyHeading  - delta )
              && this.Heading <= ( mommyHeading  + delta ) );
    }

    public int Heading { get; private set; }
    public int Id { get; private set; }

    public override string ToString()
    {
        return $"{this.Id}/Cuac! {this.Heading}º";
    }

    private static int Num = 0;
}
