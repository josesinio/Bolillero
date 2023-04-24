namespace BolilleroApp.core;
public class Bolillero
{
    public List<int> Adentro { get; set; }
    public List<int> Jugada { get; set; }
    public List<int> Afuera { get; set; }
    public IAzar Random { get; set; }
    public Bolillero(int bolillas, IAzar random)
    {
        this.Adentro = new List<int>(bolillas);
        this.Jugada = new List<int>();
        this.Afuera = new List<int>();
        Random = random;
    }
    public int SacarBolillas()
    {
        var indice = Random.SacarIndice(this.Adentro);
        var elemento = Adentro[indice];

        this.Afuera.Add(elemento);
        this.Adentro.RemoveAt(indice);
        return elemento;
    }
    public bool Jugar(List<int> Jugada)
    {
        var ax = 0;

        for (ax = 0; ax <= Jugada.Count(); ax++)
        {
            var indice = SacarBolillas();
            if (indice != Jugada[ax])
            {
                return false;
            }

        }

        return true;
    }

    public int JugarNVeces(List<int> Jugada, int cantidad)
    {
        var Victoria = 0;
        for (int i = 0; i <= cantidad; i++)
        {
            var intento = Jugar(Jugada);

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
