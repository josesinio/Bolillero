namespace BolilleroApp.core;

public class Simulacion
{
    long SimularSinHilos(Bolillero copia, int cantSimulaciones, List<int> jugada)
    => copia.JugarNVeces(jugada, cantSimulaciones);

    long SimularConHilos(Bolillero copia, int cantSimulaciones, List<int> Jugada, int hilos)
    {
        Task<long>[] Simulaciones = new Task<long>[hilos];
        
        var division = cantSimulaciones/hilos;


        for(int i = 0 ;i <= cantSimulaciones-1; i++)
        {
            var BolilleroCopia = copia.Clonar();
            
            Simulaciones[i] = Task<long>.Run(()=> (long)BolilleroCopia.JugarNVeces(Jugada, 10000));

        }
        Task<long>.WaitAll(Simulaciones);


        return 0;

    }
}
