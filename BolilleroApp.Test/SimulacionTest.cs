using BolilleroApp.core;

namespace BolilleroApp.Test;

public class SimulacionTest
{
    public Bolillero BolilleroSimulacion { get; set; }
    public Simulacion simulacionBolillero { get; set; }
    public SimulacionTest()
    {
        BolilleroSimulacion = new Bolillero(10, new AzarPrimero());
        simulacionBolillero = new Simulacion();
    }

    [Fact]
    public void SimularSinHilos()
    {
        var simular = simulacionBolillero.si

    }
}