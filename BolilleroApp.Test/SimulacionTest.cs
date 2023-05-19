using BolilleroApp.core;

namespace BolilleroApp.Test;

public class SimulacionTest
{
    public Bolillero BolilleroSimulacion { get; set; }
    public Simulacion SimulacionBolillero { get; set; }
    public SimulacionTest()
    {
        BolilleroSimulacion = new Bolillero(10, new AzarPrimero());
        SimulacionBolillero = new Simulacion();
    }

    [Fact]
    public void SimularSinHilostest()
    {
        var copiaBolillero= BolilleroSimulacion.Clonar();
        var simulacion = SimulacionBolillero.SimularSinHilos(copiaBolillero, 1, jugada: new List<int> {0,1});

        Assert.Equal(1, simulacion);
    }

    [Fact]
    public void SimularConHilosTest()
    {
        var simulacionHilos = SimulacionBolillero.SimularConHilos(BolilleroSimulacion,8, Jugada: new List<int> {0,1},4);

        Assert.Equal(8, simulacionHilos);
    }
}