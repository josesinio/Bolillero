namespace BolilleroApp.core;
public class Bolillero
{
    public List<int> Adentro { get; set; }
    public List<int> Afuera { get; set; }
    public IAzar Random { get; set; }
    public Bolillero(int bolillas, IAzar random)
    {
        Adentro = new List<int>();
        CrearBolillas(bolillas);
        this.Afuera = new List<int>();
        Random = random;
    }

    private Bolillero(Bolillero original)
    {
        Adentro = new List<int>(original.Adentro);
        Afuera = new List<int>(original.Afuera);
        Random = original.Random;
    }

    public Bolillero Clonar()
    => new Bolillero(this);


    private void CrearBolillas(int bolillas)
    {
        for (int i = 0; i < bolillas; i++)
            Adentro.Add(i);
    }

    public int SacarBolilla()
    {
        var indice = Random.SacarIndice(this.Adentro);
        var elemento = Adentro[indice];


        this.Afuera.Add(elemento);
        this.Adentro.RemoveAt(indice);
        return elemento;
    }
    public bool Jugar(List<int> jugada)
    {
        var ax = 0;

        for (ax = 0; ax < jugada.Count; ax++)
        {
            var bolilla = SacarBolilla();
            if (bolilla != jugada[ax])
            {
                return false;
            }

        }

        return true;
    }

    public int JugarNVeces(List<int> jugada, int cantidad)
    {
        var Victoria = 0;
        for (int i = 0; i < cantidad; i++)
        {
            ReingresarBolillas();
            var intento = Jugar(jugada);

            if (intento == true)
            {
                Victoria = +1;
            }
        }
        return Victoria;
    }
    public void ReingresarBolillas()
    {
        Adentro.AddRange(Afuera);
        Afuera.Clear();
    }


}
