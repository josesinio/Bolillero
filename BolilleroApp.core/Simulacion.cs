namespace BolilleroApp.core;

public class Simulacion
{
    public long SimularSinHilos(Bolillero copia, int cantSimulaciones, List<int> jugada)
    => copia.JugarNVeces(jugada, cantSimulaciones);

    public long SimularConHilos(Bolillero Bolillero, int cantSimulaciones, List<int> jugada, int hilos)
    {
        Task<long>[] Simulaciones = new Task<long>[hilos];

        var tarea = cantSimulaciones / hilos;


        for (int i = 0; i < hilos; i++)
        {
            var BolilleroCopia = Bolillero.Clonar();
            Simulaciones[i] = Task<long>.Run(() => (long)BolilleroCopia.JugarNVeces(jugada, tarea));

        }
        Task<long>.WaitAll(Simulaciones);


        return Simulaciones.Sum(s => s.Result);
    }
}
