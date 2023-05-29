namespace BolilleroApp.core;

public class Simulacion
{
    public long SimularSinHilos(Bolillero copia, int cantSimulaciones, List<int> jugada)
    => copia.JugarNVeces(jugada, cantSimulaciones);

    public long SimularConHilos(Bolillero bolillero, int cantSimulaciones, List<int> jugada, int hilos)
    {
        var Simulaciones = ListaProcesos(bolillero, cantSimulaciones, jugada, hilos);
        Task<long>.WaitAll(Simulaciones);


        return Simulaciones.Sum(s => s.Result);
    }

    public async Task<long> SimularConHilosAsync(Bolillero bolillero, int cantSimulaciones, List<int> jugada, int hilos)
    {

        var Simulaciones = ListaProcesos(bolillero, cantSimulaciones, jugada, hilos);
        await Task.WhenAll(Simulaciones);


        return Simulaciones.Sum(s => s.Result);
    }
    public Task<long>[] ListaProcesos(Bolillero bolillero, int cantSimulaciones, List<int> jugada, int hilos)
    {
        Task<long>[] Simulaciones = new Task<long>[hilos];

        var tareas = cantSimulaciones / hilos;

        for (int i = 0; i < hilos; i++)
        {
            var BolilleroCopia = bolillero.Clonar();
            Simulaciones[i] = Task<long>.Run(() => (long)BolilleroCopia.JugarNVeces(jugada, tareas));

        }

        return Simulaciones;
    }
}
