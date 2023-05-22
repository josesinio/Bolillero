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
        var copiaBolillero = BolilleroSimulacion.Clonar();
        var simulacion = SimulacionBolillero.SimularSinHilos(copiaBolillero, 1, jugada: new List<int> { 0, 1 });

        Assert.Equal(1, simulacion);
    }

    [Fact]
    public void SimularConHilosTest()
    {
        var cantidadHilos = 6;
        var simulaciones = 50_000_000;
        var resultado = SimulacionBolillero.SimularConHilos
            (Bolillero: BolilleroSimulacion, cantSimulaciones: simulaciones, jugada: new List<int> { 0, 1 }, hilos: cantidadHilos);

        Assert.Equal(cantidadHilos, resultado);
    }
}