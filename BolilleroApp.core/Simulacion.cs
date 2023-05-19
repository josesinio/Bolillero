namespace BolilleroApp.core;

public class Simulacion
{
    public long SimularSinHilos(Bolillero copia, int cantSimulaciones, List<int> jugada)
    => copia.JugarNVeces(jugada, cantSimulaciones);

    public long SimularConHilos(Bolillero copia, int cantSimulaciones, List<int> Jugada, int hilos)
    {
        Task<long>[] Simulaciones = new Task<long>[hilos];

        var division = cantSimulaciones / hilos;


        for (int i = 0; i < cantSimulaciones - 1; i++)
        {
            var BolilleroCopia = copia.Clonar();

            Simulaciones[i] = Task<long>.Run(() => (long)BolilleroCopia.JugarNVeces(Jugada, division));

        }
        Task<long>.WaitAll(Simulaciones);


        return Simulaciones.Sum(s => s.Result);

    }
}
